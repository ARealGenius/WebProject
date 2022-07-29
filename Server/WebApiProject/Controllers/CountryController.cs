using BL;
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
    public class CountryController : ControllerBase

    {

        ICountryBL ICountryBL;
        public CountryController(ICountryBL iCountryBL)
        {
           ICountryBL = iCountryBL;
        }


        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult< IEnumerable<Country>>> Get()
        {
            return Ok(await ICountryBL.Get());
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult< string>> Get(int id)
        {
            return Ok(await ICountryBL.Get(id));
        }

    }
}
