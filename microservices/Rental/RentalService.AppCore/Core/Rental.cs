using System;
using System.Collections.Generic;
using Store.IntegrationEvents.Rental;
using Commerce.Core.Domain;

namespace RentalService.AppCore.Core
{
    public class Rental : EntityRootBase
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReturnDueTime { get; set; }
        public bool IsReturned { get; set; }
        public decimal RentalCost { get; set; }

        public static Rental Create(Guid customerId, Guid productId, DateTime beginTime, DateTime endTime, DateTime returnDueTime, bool isReturned, decimal rentalCost)
        {
            return Create(Guid.NewGuid(), customerId, productId, beginTime, endTime, returnDueTime, isReturned, rentalCost);
        }

        public static Rental Create(Guid id, Guid customerId, Guid productId, DateTime beginTime, DateTime endTime, DateTime returnDueTime, bool isReturned, decimal rentalCost)
        {
            Rental Rental = new()
            {
                Id = id,
                CustomerId = customerId,
                ProductId = productId,
                BeginTime = beginTime,
                EndTime = endTime,
                ReturnDueTime = returnDueTime,
                IsReturned = isReturned,
                RentalCost = rentalCost
            };

            Rental.AddDomainEvent(new RentalCreatedIntegrationEvent
            {
                Id = Rental.Id,
                CustomerId = Rental.CustomerId,
                ProductId = Rental.ProductId,
                BeginTime = Rental.BeginTime,
                EndTime = Rental.EndTime,
                ReturnDueTime = Rental.ReturnDueTime,
                IsReturned = Rental.IsReturned,
                RentalCost = Rental.RentalCost
            });

            return Rental;
        }
    }
}
