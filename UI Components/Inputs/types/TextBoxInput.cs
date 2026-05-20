using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    public class TextBoxInput : SingleInput<TextBox>
    {
        public TextBoxInput(string label, int x, int y, int width) : base(label, x, y, width)
        {
            control = new TextBox();
            control.Size = new Size(width, 50);
            control.Location = new Point(x, y);
            control.Font = new Font("Segoe UI", 24);
            control.BorderStyle = BorderStyle.FixedSingle;
            control.BackColor = Color.White;
        }

        public override object GetValue()
        {
            return control.Text;
        }
    }
}
