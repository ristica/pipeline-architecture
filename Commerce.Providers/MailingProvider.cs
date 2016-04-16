using System;
using Commerce.Common;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Providers
{
    public class MailingProvider : IMailingProvider
    {
        #region Properties

        public string FromAddress { get; set; }

        public string SmtpServer { get; set; }

        #endregion

        #region Methods

        public void SendInvoiceEmail(OrderData orderData)
        {
            Console.WriteLine($"\tInvoice mailed to {orderData.CustomerEmail}.");
        }

        public void SendRejectionEmail(OrderData orderData)
        {
            Console.WriteLine($"\tI'm sorry {orderData.CustomerEmail}, your order could not be processed at this time.");
        }

        #endregion
    }
}
