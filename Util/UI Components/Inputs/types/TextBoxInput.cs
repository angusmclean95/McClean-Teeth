using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    public class TextBoxInput : SingleControlInput<TextBox>
    {
        public TextBoxInput(
            string label,
            int x,
            int y,
            int width
        ) : base(label, x, y, width)
        {
            _control = new TextBox();
            _control.Size = new Size(width, 50);
            _control.Location = new Point(x, y);
            _control.Font = new Font("Segoe UI", 24);
            _control.BorderStyle = BorderStyle.FixedSingle;
            _control.BackColor = Color.White;
        }

        public override object GetValue()
        {
            return _control.Text;
        }
    }
}
