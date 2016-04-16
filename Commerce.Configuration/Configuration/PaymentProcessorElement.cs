using System.Configuration;

namespace Commerce.Configuration
{
    // <paymentProcessor></paymentProcessor>
    public class PaymentProviderElement : ProviderTypeElement
    {
        [ConfigurationProperty("login", IsRequired = true)]
        public string Login
        {
            get { return (string)base["login"]; }
            set { base["login"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)base["password"]; }
            set { base["password"] = value; }
        }
    }
}