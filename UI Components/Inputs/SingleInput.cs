using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs
{
    public abstract class SingleInput<T> : UIInput where T : Control
    {
        protected T control;

        protected int x;
        protected int y;
        protected int width;

        public T Control => control;

        public SingleInput(string labelText, int x, int y, int width)
        {
            this.x = x;
            this.y = y;
            this.width = width;

            label = new Label();
            label.Text = labelText;
            label.ForeColor = Variables.FOREGROUND_COLOUR;
            label.Font = new Font("Segoe UI", 24);
            label.AutoSize = true;
            label.Location = new Point(x - 5, y - 50);
        }

        public override void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;

            label.Location = new Point(x - 5, y - 50);
            control.Location = new Point(x, y);
        }

        public override void AddToPanel(Panel panel)
        {
            panel.Controls.Add(label);
            panel.Controls.Add(control);
        }
    }
}
