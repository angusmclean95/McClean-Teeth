using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth
{
    class ValidatorUtil
    {
        private static string PASSWORD_REGEX = "((?=.*\\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\\W)\\w.{8,28}\\w)";
        private static string EMAIL_REGEX = "^[^@]+@[^@]+\\.[^@]+$";

        public static bool isValidField(string fieldText)
        {
            return !string.IsNullOrEmpty(fieldText);
        }

        public static bool isNullOrEmpty(params TextBox[] boxes)
        {
            foreach (TextBox item in boxes)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool isValidPassword(string password)
        {
            return isValidField(password) && Regex.IsMatch(password, PASSWORD_REGEX);
        }

        public static bool isValidEmailAddress(string emailAddress)
        {
            return isValidField(emailAddress) && Regex.IsMatch(emailAddress, EMAIL_REGEX);
        }

        public static bool isMatching(string arg1, string arg2)
        {
            return arg1 == arg2;
        }
    }
}