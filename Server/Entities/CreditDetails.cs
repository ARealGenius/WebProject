using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Entities
{
    public partial class CreditDetails
    {
        public CreditDetails()
        {
            Passengers = new HashSet<Passenger>();
        }
        
        public int CreditDedailsId { get; set; }
       
        [StringLength(9)]
        public string OwnerId { get; set; }

        [StringLength(16)] [CreditCard]
        public string CreditNumber { get; set; }
      
        [StringLength(4)]
        public string Validity { get; set; }
       
        [StringLength(3)]
        public string Cvv { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
