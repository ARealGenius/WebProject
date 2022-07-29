using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task<User> Get(string email, string password);
        Task<User> Post(User user);
        void Put(int id, User userToUpdate);
    }
}