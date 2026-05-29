using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McClean_Teeth.Util
{
    internal class FormatUtil
    {
        /*
         * Formats a date in a dd/MM/yyyy hh:mm tt format.
         * day/month/year hour:minute am/pm
         */
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy hh:mm tt");
        }
    }
}
