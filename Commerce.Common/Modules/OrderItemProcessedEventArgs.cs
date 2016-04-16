using System.ComponentModel;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Common.Modules
{
    public class OrderItemProcessedEventArgs : CancelEventArgs
    {
        public OrderItemProcessedEventArgs(
            Customer customer,
            OrderLineItemData orderLineItemData,
            string message)
        {
            this.Customer = customer;
            this.OrderLineItemData = orderLineItemData;
            this.Message = message;
        }

        public Customer Customer { get; set; }
        public OrderLineItemData OrderLineItemData { get; set; }
        public string Message { get; set; }
    }
}