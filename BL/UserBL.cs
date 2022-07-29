using Entities;
using System;
using DL;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL iUserDL;
        public UserBL(IUserDL iuserDL)
        {
            this.iUserDL = iuserDL;
        }
        public async Task< User> Get(string email, string password)
        {
            return await iUserDL.Get(email, password);
        }

        public async Task<User> Post(User user)
        {
            return await iUserDL.Post(user);
        }

        public async void Put(int id, User userToUpdate)
        {
              iUserDL.Put(id, userToUpdate);
        }


    }
}
