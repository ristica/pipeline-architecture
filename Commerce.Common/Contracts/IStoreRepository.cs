using System.Collections.Generic;
using Commerce.Entities;

namespace Commerce.Common.Contracts
{
    public interface IStoreRepository
    {
        List<Product> Products { get; }
        List<Inventory> ProductInventory { get; }
        List<Customer> Customers { get; }
        Customer GetCustomerByEmail(string email);
    }
}