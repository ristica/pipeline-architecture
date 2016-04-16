using System;
using System.Collections.Specialized;
using Commerce.Common.Modules;

namespace Commerce.Modules
{
    public class SendNotificationModule : ICommerceModule
    {
        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            events.SendNotification += args =>
            {
                Console.WriteLine("");
                Console.WriteLine("send invoice email");
                Console.WriteLine("#################");
                Console.WriteLine("");

                args.MailingProvider.SendInvoiceEmail(args.OrderData);
            };
        }
    }
}
