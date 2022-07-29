using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiProject.Models
{
    public partial class CreditDetail
    {
        public CreditDetail()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int CreditDedailsId { get; set; }
        public string OwnerId { get; set; }
        public string CreditNumber { get; set; }
        public string Validity { get; set; }
        public string Cvv { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
