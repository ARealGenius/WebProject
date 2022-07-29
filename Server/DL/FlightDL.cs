using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class FlightDL : IFlightDL
    {
        TravelsAgencyContext travelsAgencyContext;
        public FlightDL(TravelsAgencyContext travelsAgencyContext)
        {
            this.travelsAgencyContext = travelsAgencyContext;
        }//c'tor

        public async Task<IEnumerable<Flight>> Get()
        {
            return await travelsAgencyContext.Flights.Include(f => f.SourceCountry).Include(f => f.DestinationAirport).Include(f => f.DestinationCountry)
                .Include(f => f.SourceAirport).Include(f => f.Company).ToListAsync();
        }//get all the flights

        public async Task<IEnumerable<Flight>> Get(string sourceCountry, string destinationCountry, float cost, DateTime from, DateTime until)
        {
            var flights = await travelsAgencyContext.Flights.Include(f => f.SourceCountry).Include(f => f.DestinationAirport).Include(f => f.DestinationCountry)
                .Include(f => f.SourceAirport).Include(f => f.Company).Where(f => f.SourceCountry.CountryName == sourceCountry).Where(f=>f.Seats>=1).ToListAsync();
            if (destinationCountry != null)
            {
                flights = flights.Where(f => f.DestinationCountry.CountryName == destinationCountry).ToList();
            }
            if (cost != 0)
            {
                flights = flights.Where(f => (float)f.CostOneWay <= cost || (float)f.CostTwoWay <= cost).ToList();
            }
            if (from != default(DateTime))
            {
                flights = flights.Where(f => f.LeavingTime > from).ToList();
            }
            if (until != default(DateTime))
            {
                flights = flights.Where(f => f.LeavingTime < until).ToList();
            }
            if (from != default(DateTime) && until != default(DateTime))
            {
                flights = flights.Where(f => f.LeavingTime > from && f.LeavingTime < until).ToList();
            }
            return flights;

        }//filter flights

        public async Task<IEnumerable<Flight>> Get(int id)
        {
            Customer c = await travelsAgencyContext.Customers.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
            return c.Passengers.Select(p => p.Flight);

        }//get the all flight of specific passenger.

        public async Task<Flight> Post(Flight flight)
        {
            await travelsAgencyContext.Flights.AddAsync(flight);
            await travelsAgencyContext.SaveChangesAsync();
            return flight;
        }//add flight(unnecessury)

        //public async Task<Flight> Put(int flightId, int numOfseats)
        //{

        //    var flight = await travelsAgencyContext.Flights.FirstOrDefaultAsync(f => f.FlightId == flightId);

        //    if (flight.Seats >= numOfseats)
        //    {
        //        flight.Seats = flight.Seats - numOfseats;
        //        travelsAgencyContext.Flights.Update(flight);
        //        await travelsAgencyContext.SaveChangesAsync();
        //    }
        //    return flight;
        //}//update num of sests in flight
        public async Task Delete()
        {
            var flights = await travelsAgencyContext.Flights.Include(f=>f.Passengers).Where(f => f.LeavingTime < DateTime.Now).ToListAsync();
           

            travelsAgencyContext.Flights.RemoveRange(flights);
            await travelsAgencyContext.SaveChangesAsync();

        }

    }
}
