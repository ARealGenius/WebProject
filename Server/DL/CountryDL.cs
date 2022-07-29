using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CountryDL : ICountryDL
    {
        TravelsAgencyContext travelsAgencyContext;
        public CountryDL(TravelsAgencyContext travelsAgencyContext)
        {
            this.travelsAgencyContext = travelsAgencyContext;
        }

        public async Task<IEnumerable<string>> Get()
        {
            return await travelsAgencyContext.Countries.Select(c=>c.CountryName).ToListAsync();

        }//get all the countries...

        public async Task<string> Get(int id)
        {
            Country country = await travelsAgencyContext.Countries.FindAsync(id);
            return country.Information;
        }
    }
}
