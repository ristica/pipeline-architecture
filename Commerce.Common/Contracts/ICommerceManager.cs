using Commerce.Entities;

namespace Commerce.Common.Contracts
{
    public interface ICommerceManager
    {
        void ProcessOrder(OrderData orderData);
    }
}