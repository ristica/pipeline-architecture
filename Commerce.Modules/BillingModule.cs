using System;
using System.Collections.Specialized;
using System.Linq;
using Commerce.Common.Modules;

namespace Commerce.Modules
{
    public class BillingModule : ICommerceModule
    {
        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            events.BillingCart += args =>
            {
                Console.WriteLine("");
                Console.WriteLine("process customer credit card");
                Console.WriteLine("#################");
                Console.WriteLine("");

                var amount = args.OrderData.LineItems.Sum(lineItem => (lineItem.PurchasePrice * lineItem.Quantity));
                amount += args.ShippingCost;

                var paymentSuccess = args.PaymentProvider.ProcessCreditCard(
                    args.Customer.Name, args.OrderData.CreditCard, args.OrderData.ExpirationDate, amount);
                if (!paymentSuccess)
                {
                    throw new ApplicationException($"\tCredit card {args.OrderData.CreditCard} could not be processed.");
                }
            };
        }
    }
}
