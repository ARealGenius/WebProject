using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public int? CustomerId { get; set; }
        public int? FlightId { get; set; }
        public int? CreditDedailsId { get; set; }
        [JsonIgnore]
        public virtual CreditDetails CreditDedails { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public virtual Flight Flight { get; set; }
    }
}
