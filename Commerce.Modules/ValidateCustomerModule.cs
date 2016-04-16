using System;
using System.Collections.Specialized;
using Commerce.Common.Modules;

namespace Commerce.Modules
{
    public class ValidateCustomerModule : ICommerceModule
    {
        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            events.ValidateCustomer += args =>
            {
                var customer = args.StoreRepository.GetCustomerByEmail(args.OrderData.CustomerEmail);
                if (customer == null)
                {
                    throw new ArgumentNullException($"no customer with the email {args.OrderData.CustomerEmail}");
                }

                Console.WriteLine("");
                Console.WriteLine("customer validation");
                Console.WriteLine("#################");
                Console.WriteLine("");
                Console.WriteLine("\tCustomer has benn validazed.");

                args.Customer = customer;
            };
        }
    }
}
