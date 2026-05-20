using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    using System.Drawing;
    using System.Windows.Forms;

    namespace McClean_Teeth
    {
        public class PasswordInput : TextBoxInput
        {
            private PictureBox _toggle;
            private bool _visible;

            public PasswordInput(
                string label,
                int x,
                int y,
                int width
            ) : base(label, x, y, width)
            {
                Control.UseSystemPasswordChar = true;

                _toggle = new PictureBox();
                _toggle.Size = new Size(32, 32);
                _toggle.BackColor = Color.White;
                _toggle.SizeMode = PictureBoxSizeMode.Zoom;

                UpdateTogglePosition();

                _toggle.Image = Properties.Resources.visibility_off;

                _toggle.Click += (s, e) =>
                {
                    _visible = !_visible;

                    Control.UseSystemPasswordChar = !_visible;

                    _toggle.Image = _visible
                        ? Properties.Resources.visibility_on
                        : Properties.Resources.visibility_off;
                };
            }

            public new TextBox Control => _control;

            private void UpdateTogglePosition()
            {
                _toggle.Location = new Point(
                    _control.Location.X + _control.Width - 38,
                    _control.Location.Y + 9
                );
            }

            public override void AddToPanel(Panel panel)
            {
                base.AddToPanel(panel);

                panel.Controls.Add(_toggle);

                _toggle.BringToFront();
            }
        }
    }
}
