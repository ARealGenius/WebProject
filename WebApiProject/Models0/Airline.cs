using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiProject.Models
{
    public partial class Airline
    {
        public Airline()
        {
            Flights = new HashSet<Flight>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
