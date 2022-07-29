using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<User> Get(string email, string password);
        Task<User> Post(User user);
        void Put(int id, User userToUpdate);

    }
}