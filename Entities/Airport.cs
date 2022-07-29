using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Airport
    {
        public Airport()
        {
            FlightDestinationAirports = new HashSet<Flight>();
            FlightSourceAirports = new HashSet<Flight>();
        }

        public int AirportId { get; set; }
        public int? CountryId { get; set; }
        public string AirportName { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Flight> FlightDestinationAirports { get; set; }
        public virtual ICollection<Flight> FlightSourceAirports { get; set; }
    }
}
