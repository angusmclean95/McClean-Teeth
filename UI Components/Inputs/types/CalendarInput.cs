using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    public class CalendarInput : SingleInput<Calendar>
    {
        public CalendarInput(string label, int x, int y, int width) : base(label, x, y, width)
        {
            control = new Calendar();
            control.Location = new Point(x, y);
            control.Size = new Size(width, control.Size.Height);
        }

        public override object GetValue()
        {
            return control.SelectedDate;
        }
    }
}
