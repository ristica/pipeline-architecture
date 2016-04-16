namespace Commerce.Common.Modules
{
    public class CommerceEvents
    {
        public CommerceModuleDelegate<OrderItemProcessedEventArgs> OrderItemProcessed { get; set; }
        public CommerceModuleDelegate<ValidateCustomerEventArgs> ValidateCustomer { get; set; }
        public CommerceModuleDelegate<AdjustOrderEventArgs> AdjustOrder { get; set; } 
        public CommerceModuleDelegate<ShippingCostEventArgs> SetShippingCost { get; set; } 
        public CommerceModuleDelegate<UpdateCustomerEventArgs> UpdateCart { get; set; } 
        public CommerceModuleDelegate<BillingEventArgs> BillingCart { get; set; }
        public CommerceModuleDelegate<SendNotificationEventArgs> SendNotification { get; set; } 
    }
}