using Entities;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using DL;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        public async Task<User> Get(string email, string password)
        {
            String filepath = "M:/WebApiProject/WebApiProject/users.txt";
            using (StreamReader reader = System.IO.File.OpenText(filepath))
            {
                string currentUser;
                
                while ((currentUser = reader.ReadLine()) != null)
                {

                    User user = 
                        
                        JsonSerializer. Deserialize<User>(currentUser);
                    if (user.Email == email && user.Password == password)
                        return user;
                }
            }
            return null;
        }

        public async Task<User> Post(User user)
        {
            String filepath = "M:/WebApiProject/WebApiProject/users.txt";
            int numberOfUsers = System.IO.File.ReadLines(filepath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filepath, userJson + Environment.NewLine);
            return user;
        }

        public async void Put(int id, User userToUpdate)
        {
            String filepath = "M:/WebApiProject/WebApiProject/users.txt";
            string textToReplace = "";
            using (StreamReader reader = System.IO.File.OpenText(filepath))
            {
                string currentUser;
                while ((currentUser = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUser);
                    if (user.UserId == id)
                        textToReplace = currentUser;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filepath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filepath, text);
            }

        }

    }
}
