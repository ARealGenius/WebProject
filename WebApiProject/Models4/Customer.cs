using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiProject.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int CustomerId { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
