using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs
{
    public abstract class SingleControlInput<T> : UIInput where T : Control
    {
        protected T _control;

        protected int _x;
        protected int _y;
        protected int _width;

        public T Control => _control;

        public SingleControlInput(string labelText, int x, int y, int width)
        {
            _x = x;
            _y = y;
            _width = width;

            _label = new Label();
            _label.Text = labelText;
            _label.ForeColor = Variables.FOREGROUND_COLOUR;
            _label.Font = new Font("Segoe UI", 24);
            _label.AutoSize = true;
            _label.Location = new Point(x - 5, y - 50);
        }

        public override void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;

            _label.Location = new Point(x - 5, y - 50);
            _control.Location = new Point(x, y);
        }

        public override void AddToPanel(Panel panel)
        {
            panel.Controls.Add(_label);
            panel.Controls.Add(_control);
        }
    }
}
