using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICreditDetailsDL
    {
        
        Task<CreditDetails> Get(string ownerId);
        Task<CreditDetails> Post( CreditDetails creditDetails);
        Task Put(string ownerId, CreditDetails creditDetails);
        Task Delete(int id);
    }
}