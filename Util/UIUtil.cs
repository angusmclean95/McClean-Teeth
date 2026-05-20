using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth
{
    internal class UIUtil
    {

        public static Button CreateConfirmButton(Panel panel, string text, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size((int)(panel.Width * 0.9), 60);
            button.Location = new Point(0, y);
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 24);
            button.BackColor = Color.FromArgb(196, 178, 141);
            button.ForeColor = Color.White;
            panel.Controls.Add(button);

            return button;
        }

        public static Button CreateSecondaryButton(Panel panel, string text, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size((int)(panel.Width * 0.9), 60);
            button.Location = new Point(0, y);
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 24);
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(94, 95, 94);
            panel.Controls.Add(button);

            return button;
        }
    }
}
