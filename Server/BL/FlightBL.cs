using DL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FlightBL : IFlightBL
    {
        IFlightDL iFlightDL;
        public FlightBL(IFlightDL iFlightDL)
        {
            this.iFlightDL = iFlightDL;
        }

        public async Task<IEnumerable<Flight>> Get()
        {
            return await iFlightDL.Get();
        }

        public async Task<IEnumerable<Flight>> Get(string sourceCountry, string destinationCountry, float cost, DateTime from, DateTime until)
        {
            return await iFlightDL.Get(sourceCountry, destinationCountry, cost, from, until);
        }

        public async Task<IEnumerable<Flight>> Get(int id)
        {
            return await iFlightDL.Get(id);
        }

        public async Task<Flight> Post(Flight flight)

        {
            return await iFlightDL.Post(flight);
        }

        //public async Task<Flight> Put(int flightId, int numOfseats)
        //{
        //    return await iFlightDL.Put(flightId, numOfseats);
        //}
        public async Task Delete()
        {
            await iFlightDL.Delete();
        }


    }
}
