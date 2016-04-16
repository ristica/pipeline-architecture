using System;
using System.Transactions;
using Commerce.Common.Contracts;
using Commerce.Common.Modules;
using Commerce.Entities;

namespace Commerce.Engine
{
    public class CommerceManager : ICommerceManager
    {
        #region Fields

        private readonly IStoreRepository _storeRepository;
        private readonly IMailingProvider _mailingProvider;
        private readonly IPaymentProvider _paymentProvider;
        private readonly IShippingProvider _shippingProvider;
        private readonly CommerceEvents _commerceEvents;

        #endregion

        #region C-Tor

        public CommerceManager(IStoreRepository storeRepository, IConfigurationFactory configurationFactory)
        {
            this._storeRepository = storeRepository;

            this._mailingProvider = configurationFactory.GetMailer();
            this._paymentProvider = configurationFactory.GetPaymentProcessor();
            this._shippingProvider = configurationFactory.GetShippingProcessor();
            this._commerceEvents = configurationFactory.GetCommerceEvents();
        }

        #endregion

        #region Main process

        public void ProcessOrder(OrderData orderData)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    // 1
                    Customer customer = null;
                    if (this._commerceEvents.ValidateCustomer != null)
                    {
                        var args = new ValidateCustomerEventArgs(orderData, this._storeRepository);
                        this._commerceEvents.ValidateCustomer(args);
                        customer = args.Customer;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("starting process");
                    Console.WriteLine("#################");
                    Console.WriteLine("");

                    // 2
                    if (this._commerceEvents.AdjustOrder != null)
                    {
                        var args = new AdjustOrderEventArgs(customer, orderData, this._storeRepository);
                        this._commerceEvents.AdjustOrder(args);
                    }

                    // 3
                    var shippingCost = 0;
                    if (this._commerceEvents.SetShippingCost != null)
                    {
                        var args = new ShippingCostEventArgs(orderData, this._commerceEvents, this._shippingProvider);
                        this._commerceEvents.SetShippingCost(args);
                        shippingCost = args.ShippingCost;
                    }

                    // 4
                    if (this._commerceEvents.UpdateCart != null)
                    {
                        var args = new UpdateCustomerEventArgs(customer, orderData);
                        this._commerceEvents.UpdateCart(args);
                    }

                    // 5
                    if (this._commerceEvents.BillingCart != null)
                    {
                        var args = new BillingEventArgs(customer, orderData, shippingCost, this._paymentProvider);
                        this._commerceEvents.BillingCart(args);
                    }

                    scope.Complete();
                }

                // 6
                if (this._commerceEvents.SendNotification != null)
                {
                    var args = new SendNotificationEventArgs(orderData, this._mailingProvider);
                    this._commerceEvents.SendNotification(args);
                }
            }
            catch (Exception ex)
            {
                // 7
                if (this._commerceEvents.SendNotification != null)
                {
                    var args = new SendNotificationEventArgs(orderData, this._mailingProvider);
                    this._commerceEvents.SendNotification(args);
                }

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
