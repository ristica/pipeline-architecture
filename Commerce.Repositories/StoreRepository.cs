using System.Collections.Generic;
using System.Linq;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        #region Fields

        private List<Product> _products;
        private List<Inventory> _productInventory;
        private List<Customer> _customers;

        #endregion

        #region Properties

        public List<Product> Products
        {
            get { return this._products; }
        }

        public List<Inventory> ProductInventory
        {
            get { return this._productInventory; }
        }

        public List<Customer> Customers
        {
            get { return this._customers; }
        }

        #endregion

        #region C-Tor
        
        public StoreRepository()
        {
            this.Initialize();
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            this._products = new List<Product>
            {
                new Product { Sku = 101, Description = "Asus GX 780ti GPU", UnitPrice = 659.00 },
                new Product { Sku = 102, Description = "Asus Rampage IV Black Motherboard", UnitPrice = 479.00 },
                new Product { Sku = 103, Description = "Intel I7 4930 Ivy Bridge CPU", UnitPrice = 529.00 },
                new Product { Sku = 104, Description = "Dell U2713 Monitor", UnitPrice = 609.00 },
                new Product { Sku = 105, Description = "Dell U3014 Monitor", UnitPrice = 1059.00 },
                new Product { Sku = 106, Description = "Samsung 840EVO SSD 1TB", UnitPrice = 589.00 },
                new Product { Sku = 107, Description = "Samsung 840EVO SSD 500GB", UnitPrice = 359.00 },
                new Product { Sku = 108, Description = "Cooler Master Cosmos II Tower Case", UnitPrice = 329.00 }
            };

            this._productInventory = new List<Inventory>
            {
                new Inventory { Sku = 101, QuantityInStock = 5 },
                new Inventory { Sku = 102, QuantityInStock = 2 },
                new Inventory { Sku = 103, QuantityInStock = 10 },
                new Inventory { Sku = 104, QuantityInStock = 15 },
                new Inventory { Sku = 105, QuantityInStock = 12 },
                new Inventory { Sku = 106, QuantityInStock = 8 },
                new Inventory { Sku = 107, QuantityInStock = 8 },
                new Inventory { Sku = 108, QuantityInStock = 3 }
            };

            this._customers = new List<Customer>
            {
                new Customer { Email = "aleksandar@ristic.com", Name = "Aleksandar Ristic", Purchases = new List<PurchasedItem>() },
                new Customer { Email = "denis@straus.com", Name = "Denis Straus", Purchases = new List<PurchasedItem>() },
                new Customer { Email = "pingo@pongo.com", Name = "Pingo Pongo", Purchases = new List<PurchasedItem>() }
            };
        }

        public Customer GetCustomerByEmail(string email)
        {
            return this._customers.FirstOrDefault(item => item.Email == email);
        }

        #endregion
    }
}
