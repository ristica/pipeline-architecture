using System.ComponentModel;
using Commerce.Entities;

namespace Commerce.Common.Modules
{
    public class UpdateCustomerEventArgs : CancelEventArgs
    {
        public Customer Customer { get; set; }
        public OrderData OrderData { get; set; }

        public UpdateCustomerEventArgs(Customer customer, OrderData orderData)
        {
            this.Customer = customer;
            this.OrderData = orderData;
        }
    }
}
