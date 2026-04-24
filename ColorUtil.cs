using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McClean_Teeth
{
    internal class ColorUtil
    {

        /**
         * This method takes a color and a percentage and returns a darker version of the color.
         * The percentage should be between 0 and 100, where 0 means no change and 100 means completely black.
         */
        public static Color Lighter(Color orignal, int percentage)
        {
            int r = orignal.R + (255 - orignal.R) * percentage / 100;
            int g = orignal.G + (255 - orignal.G) * percentage / 100;
            int b = orignal.B + (255 - orignal.B) * percentage / 100;
            return Color.FromArgb(orignal.A, r, g, b);
        }

        /**
          * This method takes a color and a percentage and returns a darker version of the color.
          * The percentage should be between 0 and 100, where 0 means no change and 100 means completely black.
          */
        public static Color Darker(Color orignal, int percentage)
        {
            int r = orignal.R - orignal.R * percentage / 100;
            int g = orignal.G - orignal.G * percentage / 100;
            int b = orignal.B - orignal.B * percentage / 100;
            return Color.FromArgb(orignal.A, r, g, b);
        }
    }
}
