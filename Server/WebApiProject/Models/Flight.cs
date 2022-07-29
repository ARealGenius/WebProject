using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiProject.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int FlightId { get; set; }
        public int? CompanyId { get; set; }
        public int? SourceCountryId { get; set; }
        public int? SourceAirportId { get; set; }
        public int? DestinationCountryId { get; set; }
        public int? DestinationAirportId { get; set; }
        public decimal? CostOneWay { get; set; }
        public decimal? CostTwoWay { get; set; }
        public DateTime? LeavingTime { get; set; }
        public DateTime? LandingTime { get; set; }
        public int? Seats { get; set; }

        public virtual Airline Company { get; set; }
        public virtual Airport DestinationAirport { get; set; }
        public virtual Country DestinationCountry { get; set; }
        public virtual Airport SourceAirport { get; set; }
        public virtual Country SourceCountry { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
