using System;
using Commerce.Common;
using Commerce.Common.Contracts;

namespace Commerce.Providers
{
    public class PaymentProvider : IPaymentProvider
    {
        #region Properties

        public string Login { get; set; }
        public string Password { get; set; }

        #endregion

        #region Methods

        public bool ProcessCreditCard(string customerName, string creditCard, string expirationDate, double amount)
        {
            // process credit card using Acme Payment Gateway and return success or failure
            Console.WriteLine("\tCredit card ({1}) processed for {0:N2}.", amount, creditCard);

            return true;
        }

        #endregion
    }
}
