using System.Collections.Generic;

namespace Commerce.Entities
{
    public class Customer
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<PurchasedItem> Purchases { get; set; }
    }
}
