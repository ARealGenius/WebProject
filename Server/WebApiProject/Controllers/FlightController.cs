using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        IFlightBL iFlightBL;
        IMapper _mapper;
        public FlightController(IFlightBL iFlightBL, IMapper mapper)
        {
            this.iFlightBL = iFlightBL;
            this._mapper = mapper;
        }
        // GET: api/<FlightController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDTO>>> Get()
        {
            var flights = await iFlightBL.Get();
            return Ok(_mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDTO>>(flights));
        }

        ////GET api/<FlightController>/5
        [HttpGet("{sourceCountry}")]
        public async Task<ActionResult<IEnumerable<FlightDTO>>> Get(string sourceCountry, [FromQuery] string destinationCountry, [FromQuery] float cost, [FromQuery] DateTime from, [FromQuery] DateTime until)
        {
            var flights = await iFlightBL.Get(sourceCountry, destinationCountry, cost, from, until);

            return Ok(_mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDTO>>(flights));
        }

        //  [HttpGet("[action]/{customerId}")]


        //        // POST api/<FlightController>
        [HttpPost]
        public async Task<ActionResult<Flight>> Post([FromBody] Flight flight)
        {
            return Ok(await iFlightBL.Post(flight));
        }


        [HttpPost("{customerId}/{flightId}")]
        //public async Task<ActionResult<PassengerDTO>> Post([FromBody] Passenger passengerDTO)
        //{
        //    Passenger passenger = _mapper.Map<PassengerDTO, Passenger>(passengerDTO);
        //    var p = await iFlightBL.Post(passenger);
        //    return Ok(_mapper.Map<Passenger, PassengerDTO>(p));

        //}

        //        //PUT api/<FlightController>/5
        //        //[HttpPut ("{flightId}")]
        //        //public async void Put( int flightId, int numOfseats)
        //        //{
        //        //    iFlightBL.Put(flightId, numOfseats);
        //        //}
        //        [HttpPut("{flightId}")]
        //        public async Task<Flight> Put(int flightId, int numOfseats)
        //        {
        //            return await iFlightBL.Put(flightId, numOfseats);

        //        }

        // DELETE api/<FlightController>/5
        [HttpDelete]
        public async Task Delete()
        {
             await iFlightBL.Delete();
        }
    }
}
