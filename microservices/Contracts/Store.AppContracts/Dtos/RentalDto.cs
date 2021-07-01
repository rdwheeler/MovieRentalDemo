using System;
using System.Collections.Generic;

namespace Store.AppContracts.Dtos
{
    public class RentalDto
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReturnDueTime { get; set; }
        public bool IsReturned { get; set; }
        public decimal RentalCost { get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
