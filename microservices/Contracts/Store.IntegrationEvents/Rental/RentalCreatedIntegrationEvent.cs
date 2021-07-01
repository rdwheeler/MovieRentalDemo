using System;
using Commerce.Core.Domain;

namespace Store.IntegrationEvents.Rental
{
    public class RentalCreatedIntegrationEvent : EventBase
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReturnDueTime { get; set; }
        public bool IsReturned { get; set; }
        public decimal RentalCost { get; set; }

        public override void Flatten()
        {
            MetaData.Add("RentalId", Id);
            MetaData.Add("RentalCustomerId", CustomerId);
            MetaData.Add("RentalProductId", ProductId);
            MetaData.Add("RentalBeginTime", BeginTime);
            MetaData.Add("RentalEndTime", EndTime);
            MetaData.Add("RentalReturnDueTime", ReturnDueTime);
            MetaData.Add("RentalIsReturned", IsReturned);
            MetaData.Add("RentalCost", RentalCost);
        }
    }
}
