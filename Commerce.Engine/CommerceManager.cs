using System;
using System.Transactions;
using Commerce.Common.Contracts;
using Commerce.Common.Modules;
using Commerce.Common.Pipeline;
using Commerce.Entities;
using Pipeline;

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
                var commerceContext = new CommerceContext
                {
                    OrderData = orderData,
                    MailingProvider = this._mailingProvider,
                    PaymentProvider = this._paymentProvider,
                    StoreRepository = this._storeRepository,
                    ShippingProvider = this._shippingProvider,
                    CommerceEvents = this._commerceEvents
                };

                var backbone = new Backbone<CommercePipelineEvents, CommerceContext>("commerce");
                backbone.Execute(backbone.Initialize(), commerceContext);
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
