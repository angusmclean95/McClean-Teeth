using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    public class PasswordInput : TextBoxInput
    {
        private PictureBox toggle;
        private bool visible;

        public PasswordInput(string label, int x, int y, int width) : base(label, x, y, width)
        {
            Control.UseSystemPasswordChar = true;

            toggle = new PictureBox();
            toggle.Size = new Size(32, 32);
            toggle.BackColor = Color.White;
            toggle.SizeMode = PictureBoxSizeMode.Zoom;

            UpdateTogglePosition();

            toggle.Image = Properties.Resources.visibility_off;

            toggle.Click += (s, e) =>
            {
                visible = !visible;

                Control.UseSystemPasswordChar = !visible;
                toggle.Image = visible ? Properties.Resources.visibility_on : Properties.Resources.visibility_off;
            };
        }

        public new TextBox Control => control;

        private void UpdateTogglePosition()
        {
            toggle.Location = new Point(control.Location.X + control.Width - 38, control.Location.Y + 9);
        }

        public override void AddToPanel(Panel panel)
        {
            base.AddToPanel(panel);
            panel.Controls.Add(toggle);
            toggle.BringToFront();
        }
    }
}
