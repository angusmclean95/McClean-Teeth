using System;

namespace McClean_Teeth
{
    public class Customer
    {
        public int CustomerID { get; }
        public string Forename { get; }
        public string Surname { get; }
        public string Email { get; }

        /*
         * Creates a username for the customer
         * with the format of forename inital and
         * the surname.
         */
        public string Username
        {
            get
            {
                return Forename.Substring(0, 1).ToUpper() + ". " + Surname;
            }
        }

        public Customer(int customerId, string forename, string surname, string email)
        {
            this.CustomerID = customerId;
            this.Forename = forename;
            this.Surname = surname;
            this.Email = email;
        }
    }
}