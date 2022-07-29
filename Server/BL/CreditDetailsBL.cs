using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CreditDetailsBL : ICreditDetailsBL
    {
        ICreditDetailsDL iCreditDetailsDL;
        public CreditDetailsBL(ICreditDetailsDL iCreditDetailsDL)
        {
            this.iCreditDetailsDL = iCreditDetailsDL;
        }
        public async Task<CreditDetails> Get(string ownerId)
        {
            return await iCreditDetailsDL.Get(ownerId);
        }

        public async Task<CreditDetails> Post(CreditDetails creditDetails)
        {
            return await iCreditDetailsDL.Post(creditDetails);
        }

        public async Task Put(string ownerId, CreditDetails creditDetails)
        {

            await iCreditDetailsDL.Put(ownerId, creditDetails);
        }
        public async Task Delete(int id)
        {
            await iCreditDetailsDL.Delete(id);
        }
    }
}
