using System;
using System.Collections.Specialized;
using Commerce.Common.Pipeline;
using Pipeline;

namespace Commerce.Modules
{
    public class ValidateCustomerModule : PipelineModule<CommercePipelineEvents>
    {
        public override void Initialize(CommercePipelineEvents events, NameValueCollection parameters)
        {
            events.ValidateCustomer += context =>
            {
                var customer = context.StoreRepository.GetCustomerByEmail(context.OrderData.CustomerEmail);
                if (customer == null)
                {
                    throw new ArgumentNullException($"no customer with the email {context.OrderData.CustomerEmail}");
                }

                Console.WriteLine("");
                Console.WriteLine("customer validation");
                Console.WriteLine("#################");
                Console.WriteLine("");
                Console.WriteLine("\tCustomer has benn validazed.");

                context.Customer = customer;
            };
        }
    }
}
