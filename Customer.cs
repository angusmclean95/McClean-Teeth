using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McClean_Teeth
{
    public class Customer
    {
        public string Username { get; }
        public string Password { get; }

        public Customer(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
