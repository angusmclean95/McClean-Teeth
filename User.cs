using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McClean_Teeth
{
    public class User
    {
        private string username, password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }

        public string Password { get => password; set => password = value; }
    }
}
