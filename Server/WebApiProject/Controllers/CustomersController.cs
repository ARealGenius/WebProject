using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]

    public class CustomersController : ControllerBase
    {
        ICustomerBL iCustomerBL;
        IMapper _mapper;
        public CustomersController(ICustomerBL iCustomerBL, IMapper mapper)
        {
            this.iCustomerBL = iCustomerBL;
            _mapper = mapper;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}/{password}")]
        //[AllowAnonymous]

        public async Task<ActionResult<Customer>> Get(string id, string password)
        {
            var customer = await iCustomerBL.Get(id, password);
            //  if (customer != null)
            //  {
            return Ok(customer);
            //  }
            // return NoContent();
        }

        // POST api/<CustomersController> 
        [AllowAnonymous]
        [HttpPost]
        public async Task<Customer> Post([FromBody] CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            return await iCustomerBL.Post(customer);


        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        // [Route("[action]")]
        public async Task<Customer> Put(string id, [FromBody] CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            return await iCustomerBL.Put(id, customer);

        }

        [HttpPut("{id}/{flight_id}")]
        public async Task<Customer> Put(string id, int flight_id)
        {
            // var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            return await iCustomerBL.Put(id, flight_id);

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}/{flight_id}")]
        public async Task Delete(string id, int flight_id)
        {
            await iCustomerBL.Delete(id, flight_id);
        }
    }
}
