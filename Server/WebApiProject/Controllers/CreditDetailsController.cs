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
    public class CreditDetailsController : ControllerBase
    {
        ICreditDetailsBL iCreditDetailsBL;
        IMapper _mapper;
        public CreditDetailsController(ICreditDetailsBL iCreditDetailsBL, IMapper mapper) {
            this.iCreditDetailsBL = iCreditDetailsBL;
            this._mapper = mapper;
        }
        // GET: api/<CreditDetailsController>
      
        //public async Task<CreditDetails> Get()
        //{
        //}

        // GET api/<CreditDetailsController>/5
        [HttpGet("{ownerId}")]
        public async Task<CreditDetailsDTO> Get(string ownerId)
        {
            var creditDetails = await iCreditDetailsBL.Get(ownerId);

            return _mapper.Map<CreditDetails, CreditDetailsDTO>(creditDetails);
        }

        // POST api/<CreditDetailsController>
        [HttpPost]
        public async Task<CreditDetails> Post([FromBody] CreditDetailsDTO creditDetailsDTO)
        {
            var creditDetails = _mapper.Map<CreditDetailsDTO,CreditDetails>(creditDetailsDTO);
            return await iCreditDetailsBL.Post(creditDetails);
        }

        // PUT api/<CreditDetailsController>/5
        [HttpPut("{ownerId}")]
        public async Task Put(string ownerId, [FromBody] CreditDetailsDTO creditDetailsDTO)
        {
            var creditDetails = _mapper.Map<CreditDetailsDTO, CreditDetails>(creditDetailsDTO);
            await iCreditDetailsBL.Put(ownerId, creditDetails);
        }

        // DELETE api/<CreditDetailsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await iCreditDetailsBL.Delete(id);
        }
    }
}
