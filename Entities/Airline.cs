using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Airline
    {
        public Airline()
        {
            Flights = new HashSet<Flight>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
