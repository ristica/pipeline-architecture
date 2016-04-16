using Commerce.Common.Modules;

namespace Commerce.Common.Contracts
{
    public interface IConfigurationFactory
    {
        IPaymentProvider GetPaymentProcessor();
        IMailingProvider GetMailer();
        IShippingProvider GetShippingProcessor();
        CommerceEvents GetCommerceEvents();
    }
}