using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class FlightDTO 
    {
        public int FlightId { get; set; }
        public string SourceCountry { get; set; }
        public string SourceAirport { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationAirport { get; set; }
        public string CompanyName { get; set; }
        public decimal? CostOneWay { get; set; }
        public decimal? CostTwoWay { get; set; }
        public DateTime? LeavingTime { get; set; }
        public DateTime? LandingTime { get; set; }
        public float Duration { get; set; }
        //public float? DuringTime { get; set; }

    }
}
