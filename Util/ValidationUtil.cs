using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using McClean_Teeth.Util.UI_Components.Inputs.types;

namespace McClean_Teeth
{
    class ValidationUtil
    {
        // Regex's to validate password, email and postcode formats
        private static string PASSWORD_REGEX = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,28}$";
        private static string EMAIL_REGEX = "^[^@]+@[^@]+\\.[^@]+$";
        private static string POSTCODE_REGEX = @"^(GIR 0AA|[A-Z]{1,2}\d[A-Z\d]?\s?\d[A-Z]{2})$";

        /*
         * Validates that a field is not null or empty
         */
        public static bool isValidField(string fieldText)
        {
            return !string.IsNullOrEmpty(fieldText);
        }

        /*
         * Validates that a list of inputs fields
         * are not null or empty
         */
        public static bool isNullOrEmpty(params TextBoxInput[] boxes)
        {
            foreach (TextBoxInput item in boxes)
            {
                if (string.IsNullOrEmpty(item.Control.Text))
                {
                    return true;
                }
            }

            return false;
        }

        /*
         * Validates that a string matches the
         * required password regex
         */
        public static bool isValidPassword(string password)
        {
            return Regex.IsMatch(password, PASSWORD_REGEX);
        }

        /*
         * Validates that a string matches the
         * required email regex
         */
        public static bool isValidEmailAddress(string emailAddress)
        {
            return  Regex.IsMatch(emailAddress, EMAIL_REGEX);
        }

        /*
         * Validates that a string matches the
         * required postcode regex
         */
        public static bool isValidPostcode(string postcode)
        {
            return Regex.IsMatch(postcode, POSTCODE_REGEX);
        }

        /*
         * Validates that two strings match
         */
        public static bool isMatching(string arg1, string arg2)
        {
            return arg1 == arg2;
        }

    }
}