namespace Commerce.Common.Modules
{
    public class CommerceEvents
    {
        public CommerceModuleDelegate<OrderItemProcessedEventArgs> OrderItemProcessed { get; set; }
        public CommerceModuleDelegate<SendNotificationEventArgs> SendNotification { get; set; } 
    }
}