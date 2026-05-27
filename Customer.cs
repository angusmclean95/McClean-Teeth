using System;

namespace McClean_Teeth
{
    public class Customer
    {
        public string Forename { get; }
        public string Surname { get; }
        public string Email { get; }

        public string Username
        {
            get
            {
                return Forename.Substring(0, 1).ToUpper() +
                       ". " +
                       Surname;
            }
        }

        public Customer(string forename, string surname, string email)
        {
            this.Forename = forename;
            this.Surname = surname;
            this.Email = email;
        }
    }
}