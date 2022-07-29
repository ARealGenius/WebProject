using DL;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CustomerBL : ICustomerBL
    {
        ICustomerDL iCustomerDL;
        IConfiguration _configuration;

        public CustomerBL(ICustomerDL iCustomerDL, IConfiguration configuration)
        {
            this.iCustomerDL = iCustomerDL;
            _configuration = configuration;

        }

        public async Task<Customer> Get(string id, string password)
        {
            Customer customer= await iCustomerDL.Get(id,password);
            if (customer == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customer.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            customer.Token = tokenHandler.WriteToken(token);
            return WithoutPassword(customer);

        }

        public static List<Customer> WithoutPasswords(List<Customer> customer)
        {
            return customer.Select(x => WithoutPassword(x)).ToList();
        }

        public static Customer WithoutPassword(Customer customer)
        {
            customer.Password = null;
            return customer;
        }

        public async Task<Customer> Post(Customer customer)
        {
            return await iCustomerDL.Post(customer);
        }

        public async Task<Customer> Put(string id, Customer customer)
        {
          return  await iCustomerDL.Put(id, customer);
        }

        public async Task<Customer> Put(string id, int flight_id)
        {
            return await iCustomerDL.Put(id, flight_id);

        }

        public async Task Delete(string id, int flight_id)
        {
          await iCustomerDL.Delete(id, flight_id);
        }

        
    }


    
}
