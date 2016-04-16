using Commerce.Entities;

namespace Commerce.Common.Contracts
{
    public interface IShippingProvider
    {
        int GetShippingCost(OrderData orderData);
    }
}
