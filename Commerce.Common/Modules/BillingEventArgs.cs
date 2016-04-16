using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Common.Modules
{
    public class BillingEventArgs : CancelEventArgs
    {
        public Customer Customer { get; set; }
        public OrderData OrderData { get; set; }
        public int ShippingCost { get; set; }
        public IPaymentProvider PaymentProvider { get; set; }

        public BillingEventArgs(Customer customer, OrderData orderData, int shippingCost, IPaymentProvider paymentProvider)
        {
            this.Customer = customer;
            this.OrderData = orderData;
            this.ShippingCost = shippingCost;
            this.PaymentProvider = paymentProvider;
        }
    }
}
