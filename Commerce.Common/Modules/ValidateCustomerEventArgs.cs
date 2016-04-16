using System.ComponentModel;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Common.Modules
{
    public class ValidateCustomerEventArgs : CancelEventArgs
    {
        public ValidateCustomerEventArgs(OrderData orderData, IStoreRepository storeRepository)
        {
            this.OrderData = orderData;
            this.StoreRepository = storeRepository;
        }

        public Customer Customer { get; set; }
        public OrderData OrderData { get; set; }
        public IStoreRepository StoreRepository { get; set; }
    }
}
