using System;
using System.Collections.Generic;
using Commerce.Common.Contracts;
using Commerce.Configuration;
using Commerce.Engine;
using Commerce.Entities;
using Commerce.Repositories;
using Microsoft.Practices.Unity;

namespace Commerce.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container
                .RegisterType<IStoreRepository, StoreRepository>()
                .RegisterType<ICommerceManager, CommerceManager>()
                .RegisterType<IConfigurationFactory, ConfigurationFactory>();  

            var orderData = new OrderData
            {
                CustomerEmail = "aleksandar@ristic.com",
                LineItems = new List<OrderLineItemData>
                {
                    new OrderLineItemData { Sku = 102, PurchasePrice = 479.00, Quantity = 1 },
                    new OrderLineItemData { Sku = 101, PurchasePrice = 659.00, Quantity = 2 },
                    new OrderLineItemData { Sku = 103, PurchasePrice = 529.00, Quantity = 1 },
                    new OrderLineItemData { Sku = 104, PurchasePrice = 609.00, Quantity = 3 }
                },
                CreditCard = "1234123412341234",
                ExpirationDate = "1217"
            };

            var commerceEngine = container.Resolve<ICommerceManager>();
            commerceEngine.ProcessOrder(orderData);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}
