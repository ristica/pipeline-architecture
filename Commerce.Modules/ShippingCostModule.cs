using System;
using System.Collections.Specialized;
using Commerce.Common.Modules;

namespace Commerce.Modules
{
    public class ShippingCostModule : ICommerceModule
    {
        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            events.SetShippingCost += args =>
            {
                Console.WriteLine("");
                Console.WriteLine("#################");
                Console.WriteLine("get shipping cost");
                Console.WriteLine("");

                args.ShippingCost = args.ShippingProvider.GetShippingCost(args.OrderData);
            };
        }
    }
}
