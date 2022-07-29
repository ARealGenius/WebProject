using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICustomerBL
    {
        Task<Customer> Get(string id, string password);
        Task<Customer> Post(Customer customer);
        Task<Customer> Put(string id, Customer customer);
        Task<Customer> Put(string id, int flight_id);
        Task Delete(string id, int flight_id);
    }
}
