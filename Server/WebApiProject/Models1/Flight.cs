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
        public int? SourceCountry { get; set; }
        public int? DestinationCountry { get; set; }
        public decimal? CostOneWay { get; set; }
        public decimal? CostTwoWay { get; set; }
        public DateTime? FlightDate { get; set; }
        public TimeSpan? LeavingTime { get; set; }
        public TimeSpan? LandingTime { get; set; }
        public int? Seats { get; set; }

        public virtual Company Company { get; set; }
        public virtual Country DestinationCountryNavigation { get; set; }
        public virtual Country SourceCountryNavigation { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
