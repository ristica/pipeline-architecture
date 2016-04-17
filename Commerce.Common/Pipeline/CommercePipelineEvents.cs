using Pipeline;

namespace Commerce.Common.Pipeline
{
    public class CommercePipelineEvents : PipelineEvents
    {
        [PipelineEvent(Order = 0, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineContext<CommerceContext> ValidateCustomer { get; set; }

        [PipelineEvent(Order = 1, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineContext<CommerceContext> AdjustOrder { get; set; }

        [PipelineEvent(Order = 2, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineContext<CommerceContext> UpdateOrder { get; set; }

        [PipelineEvent(Order = 3, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineContext<CommerceContext> ShippingCost { get; set; }

        [PipelineEvent(Order = 4, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineContext<CommerceContext> ProcessBilling { get; set; }

        [PipelineEvent(Order = 5, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineContext<CommerceContext> SendNotification { get; set; }
    }
}
