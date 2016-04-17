using System;
using System.Collections.Specialized;
using System.Linq;
using Commerce.Common.Pipeline;
using Pipeline;

namespace Commerce.Modules
{
    public class ProcessBillingModule : PipelineModule<CommercePipelineEvents>
    {
        public override void Initialize(CommercePipelineEvents events, NameValueCollection parameters)
        {
            events.ProcessBilling += context =>
            {
                Console.WriteLine("");
                Console.WriteLine("process customer credit card");
                Console.WriteLine("#################");
                Console.WriteLine("");

                var amount = context.OrderData.LineItems.Sum(lineItem => (lineItem.PurchasePrice * lineItem.Quantity));
                amount += context.ShippingCost;

                var paymentSuccess = context.PaymentProvider.ProcessCreditCard(
                    context.Customer.Name, context.OrderData.CreditCard, context.OrderData.ExpirationDate, amount);
                if (!paymentSuccess)
                {
                    throw new ApplicationException($"\tCredit card {context.OrderData.CreditCard} could not be processed.");
                }
            };
        }
    }
}
