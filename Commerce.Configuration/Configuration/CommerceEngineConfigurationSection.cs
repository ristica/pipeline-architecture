using System.Configuration;

namespace Commerce.Configuration
{
    // <commerceEngine></commerceEngine>
    public class CommerceEngineConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("paymentProvider", IsRequired = true)]
        public PaymentProviderElement PaymentProvider
        {
            get { return (PaymentProviderElement)base["paymentProvider"]; }
            set { base["paymentProvider"] = value; }
        }

        [ConfigurationProperty("mailingProvider", IsRequired = true)]
        public MailingProviderElement MailingProvider
        {
            get { return (MailingProviderElement)base["mailingProvider"]; }
            set { base["mailingProvider"] = value; }
        }

        [ConfigurationProperty("shippingProvider", IsRequired = true)]
        public ShippingProviderElement ShippingProvider
        {
            get { return (ShippingProviderElement)base["shippingProvider"]; }
            set { base["shippingProvider"] = value; }
        }

        [ConfigurationProperty("modules", IsRequired = true)]
        public ProviderSettingsCollection Modules
        {
            get { return (ProviderSettingsCollection)base["modules"]; }
            set { base["modules"] = value; }
        }
    }
}
