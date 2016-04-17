using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commerce.Common.Contracts;
using Commerce.Common.Modules;
using Commerce.Entities;
using Pipeline;

namespace Commerce.Common.Pipeline
{
    public class CommerceContext : PipelineContext
    {
        public Customer Customer { get; set; }
        public OrderData OrderData { get; set; }
        public IStoreRepository StoreRepository { get; set; }
        public IPaymentProvider PaymentProvider { get; set; }
        public IMailingProvider MailingProvider { get; set; }
        public IShippingProvider ShippingProvider { get; set; }
        public CommerceEvents CommerceEvents { get; set; }
        public int ShippingCost { get; set; }
    }
}
