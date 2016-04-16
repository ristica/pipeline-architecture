using System;
using System.Collections.Specialized;
using Commerce.Common.Modules;
using Commerce.Entities;

namespace Commerce.Modules
{
    public class UpdateCartModule : ICommerceModule
    {
        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            events.UpdateCart += args =>
            {
                Console.WriteLine("");
                Console.WriteLine("update customer records with purchase");
                Console.WriteLine("#################");
                Console.WriteLine("");
                foreach (var lineItem in args.OrderData.LineItems)
                {
                    for (var i = 0; i < lineItem.Quantity; i++)
                    {
                        args.Customer.Purchases.Add(
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
