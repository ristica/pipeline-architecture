using Commerce.Entities;

namespace Commerce.Common.Contracts
{
    public interface IMailingProvider
    {
        void SendInvoiceEmail(OrderData orderData);
        void SendRejectionEmail(OrderData orderData);

        string FromAddress { get; set; }
        string SmtpServer { get; set; }
    }
}