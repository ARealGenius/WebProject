using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CreditDetailsDL : ICreditDetailsDL
    {
        TravelsAgencyContext travelsAgencyContext;

        public CreditDetailsDL(TravelsAgencyContext travelsAgencyContext)
        {
            this.travelsAgencyContext = travelsAgencyContext;
        }

        public async Task<CreditDetails> Get(string ownerId)
        {
            return await travelsAgencyContext.CreditDetails.Where(c => c.OwnerId == ownerId).FirstOrDefaultAsync();
        }

        public async Task<CreditDetails> Post(CreditDetails creditDetails)
        {
            await travelsAgencyContext.CreditDetails.AddAsync(creditDetails);
            await travelsAgencyContext.SaveChangesAsync();
            return creditDetails;
        }

        public async Task Put(string ownerId, CreditDetails creditDetails)
        {
            var c=  await travelsAgencyContext.CreditDetails.Where(c => c.OwnerId == ownerId).FirstOrDefaultAsync();
            c.CreditNumber = creditDetails.CreditNumber;
            c.Cvv = creditDetails.Cvv;
            c.Validity = creditDetails.Validity;
         //   travelsAgencyContext.CreditDetails.Update(creditDetails);
            await travelsAgencyContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            CreditDetails creditDetails = await travelsAgencyContext.CreditDetails.Where(c => c.CreditDedailsId == id).FirstOrDefaultAsync();
            travelsAgencyContext.CreditDetails.Remove(creditDetails);
            await travelsAgencyContext.SaveChangesAsync();
        }

    }
}
