using Commerce.Core.Domain;

namespace Store.IntegrationEvents.Customer
{
    [DaprPubSubName(PubSubName = "pubsub")]
    public class CustomerCreatedIntegrationEvent : EventBase
    {
        public override void Flatten()
        {
        }
    }
}
