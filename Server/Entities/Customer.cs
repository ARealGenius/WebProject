using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int CustomerId { get; set; }
        [Required] [StringLength(9)]
        public string Id { get; set; }
        [MinLength(4)]
        public string Password { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Mail { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        [NotMapped]
        public string Token { get; set; }

    }
}
