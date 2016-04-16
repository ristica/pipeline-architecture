using System.ComponentModel;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Common.Modules
{
    public class ShippingCostEventArgs : CancelEventArgs
    {
        public OrderData OrderData { get; set; }
        public CommerceEvents CommerceEvents { get; set; }
        public IShippingProvider ShippingProvider { get; set; }
        public int ShippingCost { get; set; }

        public ShippingCostEventArgs(OrderData orderData, CommerceEvents commerceEvents, IShippingProvider shippingProvider)
        {
            this.OrderData = orderData;
            this.CommerceEvents = commerceEvents;
            this.ShippingProvider = shippingProvider;
        }
    }
}
