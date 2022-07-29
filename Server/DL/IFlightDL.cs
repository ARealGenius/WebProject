using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IFlightDL
    {
        Task<IEnumerable<Flight>> Get();
        Task<IEnumerable<Flight>> Get(string sourceCountry, string destinationCountry, float cost, DateTime from, DateTime until);
        Task<IEnumerable<Flight>> Get(int id);
        Task<Flight> Post(Flight Flight);

        // Task<Flight> Put(int flightId, int numOfseats);

        Task Delete();


    }
}
