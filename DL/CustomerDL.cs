using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CustomerDL : ICustomerDL

    {
        TravelsAgencyContext travelsAgencyContext;
        public CustomerDL(TravelsAgencyContext travelsAgencyContext)
        {
            this.travelsAgencyContext = travelsAgencyContext;
        }

        public async Task<Customer> Get(string id, string password)
        {
            return await travelsAgencyContext.Customers.Include(c => c.Passengers).Where(c => c.Id.Equals(id)&&c.Password.Equals(password)).FirstOrDefaultAsync();
        }

        public async Task<Customer> Post(Customer customer)
        {
            await travelsAgencyContext.Customers.AddAsync(customer);
            await travelsAgencyContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Put(string id, Customer customerToUpdate)
        {
            Customer customer = await travelsAgencyContext.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (customer == null)
            {
                return null;
            }

            travelsAgencyContext.Entry(customer).CurrentValues.SetValues(customerToUpdate);
            await travelsAgencyContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Put(string id, int flight_id)
        {
            Customer customer = await travelsAgencyContext.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            Flight f = await travelsAgencyContext.Flights.Where(f => f.FlightId == flight_id).FirstOrDefaultAsync();
            if (f.Seats < 1)
            {
                throw new Exception("there is no seats");
            }
            f.Seats--;
            Passenger p = new Passenger();
            p.Flight = f;
            p.FlightId = f.FlightId;
            p.CustomerId = customer.CustomerId;
            p.Customer = customer;
            customer.Passengers.Add(p);
            // travelsAgencyContext.Customers.Update(customer);
            await travelsAgencyContext.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(string id, int flight_id)
        {
            Customer customer = await travelsAgencyContext.Customers.Include(c => c.Passengers).Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
            Flight f = await travelsAgencyContext.Flights.Where(f => f.FlightId == flight_id).FirstOrDefaultAsync();
            Passenger p = customer.Passengers.Where(p => p.FlightId == flight_id).FirstOrDefault();
            f.Seats++;
            customer.Passengers.Remove(p);
            // f.Seats++;
            //travelsAgencyContext.Entry(customer).CurrentValues.SetValues(customer);
            travelsAgencyContext.Passengers.Remove(p);
            await travelsAgencyContext.SaveChangesAsync();
        }

    }
}
