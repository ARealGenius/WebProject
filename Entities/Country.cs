using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Country
    {
        public Country()
        {
            Airports = new HashSet<Airport>();
            FlightDestinationCountries = new HashSet<Flight>();
            FlightSourceCountries = new HashSet<Flight>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int? ContinentCode { get; set; }
        public string Information { get; set; }

        public virtual Continent ContinentCodeNavigation { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
        public virtual ICollection<Flight> FlightDestinationCountries { get; set; }
        public virtual ICollection<Flight> FlightSourceCountries { get; set; }
    }
}
