using System;
using System.Linq;
using Commerce.Common;
using Commerce.Common.Contracts;
using Commerce.Entities;

namespace Commerce.Providers
{
    public class ShippingProvider : IShippingProvider
    {
        public int GetShippingCost(OrderData orderData)
        {
            var summ = orderData.LineItems.Sum(lineItem => (lineItem.PurchasePrice * lineItem.Quantity));
            var result = 0;

            if (summ <= 1000)
            {
                result = 20;
            }
            if (summ > 1000 && summ <= 2000)
            {
                result = 15;
            }
            if (summ > 2000 && summ <= 4000)
            {
                result = 10;
            }
            if (summ > 4000 && summ <= 5000)
            {
                result = 5;
            }

            Console.WriteLine($"\tShipping: {result:N2}");

            return result;
        }
    }
}
