using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    public class MonthCalendarInput : SingleControlInput<ScalableCalendar>
    {
        public MonthCalendarInput(
            string label,
            int x,
            int y,
            int width
        ) : base(label, x, y, width)
        {
            _control = new ScalableCalendar();
            _control.Location = new Point(x, y);
            _control.Size = new Size(width, _control.Size.Height);
        }

        public override object GetValue()
        {
            return _control.SelectedDate;
        }
    }
}
