using System;
using System.Collections.Specialized;
using System.Linq;
using Commerce.Common.Modules;

namespace Commerce.Modules
{
    public class AdjustInventoryModule : ICommerceModule
    {
        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            events.AdjustOrder += args =>
            {
                foreach (var lineItem in args.OrderData.LineItems)
                {
                    #region 1 - Check for promotion

                    if (events.OrderItemProcessed != null)
                    {
                        var e = new OrderItemProcessedEventArgs(args.Customer, lineItem, null);
                        events.OrderItemProcessed(e);

                        if (e.Cancel)
                        {
                            // do something important
                            throw new ApplicationException(e.Message);
                        }
                    }

                    #endregion

                    #region 2 - Get product

                    var product =
                        args.StoreRepository.Products.FirstOrDefault(item => item.Sku == lineItem.Sku);
                    if (product == null)
                    {
                        throw new ApplicationException($"Sku {lineItem.Sku} not found in store inventory.");
                    }

                    #endregion

                    #region 3 - Get line item by sku

                    var inventoryOnHand =
                        args.StoreRepository.ProductInventory.FirstOrDefault(
                            item => item.Sku == lineItem.Sku);
                    if (inventoryOnHand == null)
                    {
                        throw new ApplicationException(
                            $"Error attempting to determine on-hand inventory quantity for product {lineItem.Sku}.");
                    }

                    #endregion

                    #region 4 - Check if line item in stock

                    if (inventoryOnHand.QuantityInStock < lineItem.Quantity)
                    {
                        throw new ApplicationException(
                            $"Not enough quantity on-hand to satisfy product {lineItem.Sku} purchase of {lineItem.Quantity} units.");
                    }

                    #endregion

                    #region 5 - Change stock of the line item

                    inventoryOnHand.QuantityInStock -= lineItem.Quantity;

                    Console.WriteLine(
                        $"\tInventory for product {lineItem.Sku} reduced by {lineItem.Quantity} units.");
                    Console.WriteLine();

                    #endregion
                }
            };
        }
    }
}
