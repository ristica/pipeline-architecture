using System;
using System.Collections.Specialized;
using Commerce.Common.Pipeline;
using Commerce.Entities;
using Pipeline;

namespace Commerce.Modules
{
    public class UpdateCartModule : PipelineModule<CommercePipelineEvents>
    {
        public override void Initialize(CommercePipelineEvents events, NameValueCollection parameters)
        {
            events.UpdateOrder += context =>
            {
                Console.WriteLine("");
                Console.WriteLine("update customer records with purchase");
                Console.WriteLine("#################");
                Console.WriteLine("");
                foreach (var lineItem in context.OrderData.LineItems)
                {
                    for (var i = 0; i < lineItem.Quantity; i++)
                    {
                        context.Customer.Purchases.Add(
                            new PurchasedItem
                            {
                                Sku = lineItem.Sku,
                                PurchasePrice = lineItem.PurchasePrice,
                                PurchasedOn = DateTime.Now
                            });
                    }
                    Console.WriteLine($"\tAdded {lineItem.Quantity} unit(s) or product {lineItem.Sku} to customer's purchase history.");
                }
            };
        }
    }
}
