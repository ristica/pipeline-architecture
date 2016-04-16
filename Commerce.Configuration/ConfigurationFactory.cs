using System;
using System.Configuration;
using Commerce.Common.Contracts;
using Commerce.Common.Modules;

namespace Commerce.Configuration
{
    public class ConfigurationFactory : IConfigurationFactory
    {
        #region Fields

        private readonly IPaymentProvider _paymentProvider;
        private readonly IMailingProvider _mailingProvider;
        private readonly IShippingProvider _shippingProvider;
        private CommerceEvents _commerceEvents;

        #endregion

        #region C-Tor

        public ConfigurationFactory(IStoreRepository storeRepository)
        {
            var config = ConfigurationManager.GetSection("commerceEngine") as CommerceEngineConfigurationSection;
            if (config == null) return;

            this._paymentProvider = Activator.CreateInstance(Type.GetType(config.PaymentProvider.Type)) as IPaymentProvider;
            if (this._paymentProvider != null)
            {
                this._paymentProvider.Login = config.PaymentProvider.Login;
                this._paymentProvider.Password = config.PaymentProvider.Password;
            }

            this._mailingProvider = Activator.CreateInstance(Type.GetType(config.MailingProvider.Type)) as IMailingProvider;
            if (this._mailingProvider != null)
            {
                this._mailingProvider.FromAddress = config.MailingProvider.FromAddress;
                this._mailingProvider.SmtpServer = config.MailingProvider.SmtpServer;
            }   
            
            this._shippingProvider = Activator.CreateInstance(Type.GetType(config.ShippingProvider.Type)) as IShippingProvider;

            this._commerceEvents = new CommerceEvents();
            foreach (ProviderSettings element in config.Modules)
            {
                var module = Activator.CreateInstance(Type.GetType(element.Type)) as ICommerceModule;
                module?.Initialize(this._commerceEvents, element.Parameters);
            }
        }

        #endregion

        #region Methods

        public IPaymentProvider GetPaymentProcessor()
        {
            return this._paymentProvider;
        }

        public IMailingProvider GetMailer()
        {
            return this._mailingProvider;
        }

        public IShippingProvider GetShippingProcessor()
        {
            return this._shippingProvider;
        }

        public CommerceEvents GetCommerceEvents()
        {
            return _commerceEvents;
        }

        #endregion
    }
}
