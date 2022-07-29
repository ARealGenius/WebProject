using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{

    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


    }
}
