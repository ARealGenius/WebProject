using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IUserBL iuserBL;
        public ProjectController(IUserBL iuserBL)
        {
            this.iuserBL=  iuserBL;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public string Get()
        {
            string name = HttpContext.User.Identity.Name;
            if (name == null)
            {
                return "anonimous";
            }
            return name;
        }

        [HttpGet("{email}/{password}")]
        public async Task<User> Get(string email, string password)
        {
            User user = await iuserBL. Get(email, password);
            if (user == null)
            {
                return null;
            }
            else
                return user;

        }


        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "id";
        }

        [HttpPost]
        public async Task <User> Post([FromBody] User user)
        {
            return await iuserBL.Post(user);
        }


        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {

            iuserBL.Put(id, userToUpdate);
       
        }


        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
