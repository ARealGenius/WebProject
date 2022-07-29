using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiProject.Models
{
    public partial class Country
    {
        public Country()
        {
            Airports = new HashSet<Airport>();
            FlightDestinationCountryNavigations = new HashSet<Flight>();
            FlightSourceCountryNavigations = new HashSet<Flight>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int? ContinentCode { get; set; }
        public string Information { get; set; }

        public virtual Continent ContinentCodeNavigation { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
        public virtual ICollection<Flight> FlightDestinationCountryNavigations { get; set; }
        public virtual ICollection<Flight> FlightSourceCountryNavigations { get; set; }
    }
}
