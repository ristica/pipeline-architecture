using System;
using System.Collections.Specialized;
using System.Linq;
using Commerce.Common.Modules;
using Commerce.Common.Pipeline;
using Pipeline;

namespace Commerce.Modules
{
    public class AdjustInventoryModule : PipelineModule<CommercePipelineEvents>
    {
        public override void Initialize(CommercePipelineEvents events, NameValueCollection parameters)
        {
            events.AdjustOrder += context =>
            {
                foreach (var lineItem in context.OrderData.LineItems)
                {
                    #region 1 - Check for promotion

                    if (context.CommerceEvents.OrderItemProcessed != null)
                    {
                        var e = new OrderItemProcessedEventArgs(context.Customer, lineItem, null);
                        context.CommerceEvents.OrderItemProcessed(e);

                        if (e.Cancel)
                        {
                            // do something important
                            throw new ApplicationException(e.Message);
                        }
                    }

                    #endregion

                    #region 2 - Get product

                    var product = context.StoreRepository.Products.FirstOrDefault(item => item.Sku == lineItem.Sku);
                    if (product == null)
                    {
                        throw new ApplicationException($"Sku {lineItem.Sku} not found in store inventory.");
                    }

                    #endregion

                    #region 3 - Get line item by sku

                    var inventoryOnHand = context.StoreRepository.ProductInventory.FirstOrDefault(
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
                    inventoryOnHand.QuantityInStock -= lineItem.Quantity;

                    Console.WriteLine($"\tInventory for product {lineItem.Sku} reduced by {lineItem.Quantity} units.");
                    Console.WriteLine();

                    #endregion
                }
            };
        }
    }
}
