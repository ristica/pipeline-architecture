using System.ComponentModel;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Common.Modules
{
    public class SendNotificationEventArgs : CancelEventArgs
    {
        public OrderData OrderData { get; set; }
        public IMailingProvider MailingProvider { get; set; }

        public SendNotificationEventArgs(OrderData orderData, IMailingProvider mailingProvider)
        {
            this.OrderData = orderData;
            this.MailingProvider = mailingProvider;
        }
    }
}
