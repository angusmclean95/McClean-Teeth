using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McClean_Teeth.Util
{
    internal class FormatUtil
    {
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy hh:mm tt");
        }
    }
}
