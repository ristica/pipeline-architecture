using System;
using System.Collections.Specialized;
using Commerce.Common.Pipeline;
using Pipeline;

namespace Commerce.Modules
{
    public class SendNotificationModule : PipelineModule<CommercePipelineEvents>
    {
        public override void Initialize(CommercePipelineEvents events, NameValueCollection parameters)
        {
            events.SendNotification += context =>
            {
                Console.WriteLine("");
                Console.WriteLine("send invoice email");
                Console.WriteLine("#################");
                Console.WriteLine("");

                context.MailingProvider.SendInvoiceEmail(context.OrderData);
            };
        }
    }
}
