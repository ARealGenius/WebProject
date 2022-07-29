using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CountryBL : ICountryBL
    {
        ICountryDL iCountryDL;
        public CountryBL(ICountryDL iCountryDL)
        {
            this.iCountryDL = iCountryDL;
        }

        public async Task<IEnumerable<string>> Get()
        {
            return await iCountryDL.Get();

        }//get all the countries...

        public async Task<string> Get(int id)
        {
            return await iCountryDL.Get(id);

        }
    }
}
