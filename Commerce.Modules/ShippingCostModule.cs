using System;
using System.Collections.Specialized;
using Commerce.Common.Pipeline;
using Pipeline;

namespace Commerce.Modules
{
    public class ShippingCostModule : PipelineModule<CommercePipelineEvents>
    {
        public override void Initialize(CommercePipelineEvents events, NameValueCollection parameters)
        {
            events.ShippingCost += context =>
            {
                Console.WriteLine("");
                Console.WriteLine("#################");
                Console.WriteLine("get shipping cost");
                Console.WriteLine("");

                context.ShippingCost = context.ShippingProvider.GetShippingCost(context.OrderData);
            };
        }
    }
}
