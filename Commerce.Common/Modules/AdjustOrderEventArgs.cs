using System.ComponentModel;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Common.Modules
{
    public class AdjustOrderEventArgs : CancelEventArgs
    {
        public Customer Customer { get; set; }
        public OrderData OrderData { get; set; }
        public IStoreRepository StoreRepository { get; set; }

        public AdjustOrderEventArgs(Customer customer, OrderData orderData, IStoreRepository storeRepository)
        {
            this.Customer = customer;
            this.OrderData = orderData;
            this.StoreRepository = storeRepository;
        }
    }
}