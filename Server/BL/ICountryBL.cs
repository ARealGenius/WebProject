using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICountryBL
    {
        Task<IEnumerable<string>> Get();
        Task<string> Get(int id);
    }
}