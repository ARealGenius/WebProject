using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiProject.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public int? CustomerId { get; set; }
        public int? FlightId { get; set; }
        public int? CreditDedailsId { get; set; }

        public virtual CreditDetail CreditDedails { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
