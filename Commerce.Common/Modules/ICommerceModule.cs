using System.Collections.Specialized;

namespace Commerce.Common.Modules
{
    public interface ICommerceModule
    {
        void Initialize(CommerceEvents events, NameValueCollection config);
    }
}