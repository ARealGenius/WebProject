using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICountryDL
    {
        Task<IEnumerable<string>> Get();
        Task<string> Get(int id);
    }
}