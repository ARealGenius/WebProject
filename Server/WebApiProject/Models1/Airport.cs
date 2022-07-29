using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiProject.Models
{
    public partial class Airport
    {
        public int AirportId { get; set; }
        public int? CountryId { get; set; }
        public string AirportName { get; set; }

        public virtual Country Country { get; set; }
    }
}
