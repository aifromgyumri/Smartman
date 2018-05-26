using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Username { get; set; }

        public int Rating { get; set; }

        public string  Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; internal set; }

    }
}
