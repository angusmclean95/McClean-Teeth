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
        private static int PAIR_SPACING = 10;

        /**
         * Creates a new input TextBox that has a label above,
         * and then a TextBox below. You can specify the y level
         * of where the input field should be located.
         */
        public static TextBox CreateInput(Panel panel, string placeholder, int y)
        {
            Label label = new Label();
            label.BackColor = Color.Transparent;
            label.Text = placeholder;
            label.ForeColor = Variables.FOREGROUND_COLOUR;
            label.Font = new Font("Segoe UI", 24);
            label.Location = new Point(-5, y - 50);
            label.AutoSize = true;

            TextBox box = new TextBox();
            box.Size = new Size((int)(panel.Width * 0.9), 50);
            box.Location = new Point(0, y);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = new Font("Segoe UI", 24);
            box.BackColor = Color.FromArgb(255, 255, 255);

            // Add the label and text box to the panel
            panel.Controls.Add(label);
            panel.Controls.Add(box);

            return box;
        }

        public static InputPair CreateInputPair(Panel panel, string placeholder1, string placeholder2, int y)
        {
            int totalSpacing = PAIR_SPACING;
            int width = ((int)(panel.Width * 0.9) - totalSpacing) / 2;

            int x1 = 0;
            int x2 = width + PAIR_SPACING;

            // First input
            Label label1 = new Label();
            label1.BackColor = Color.Transparent;
            label1.Text = placeholder1;
            label1.ForeColor = Variables.FOREGROUND_COLOUR;
            label1.Font = new Font("Segoe UI", 24);
            label1.Location = new Point(x1, y - 50);
            label1.AutoSize = true;

            TextBox box1 = new TextBox();
            box1.Size = new Size(width, 50);
            box1.Location = new Point(x1, y);
            box1.BorderStyle = BorderStyle.FixedSingle;
            box1.Font = new Font("Segoe UI", 24);
            box1.BackColor = Color.FromArgb(255, 255, 255);

            // Second input
            Label label2 = new Label();
            label2.BackColor = Color.Transparent;
            label2.Text = placeholder2;
            label2.ForeColor = Variables.FOREGROUND_COLOUR;
            label2.Font = new Font("Segoe UI", 24);
            label2.Location = new Point(x2, y - 50);
            label2.AutoSize = true;

            TextBox box2 = new TextBox();
            box2.Size = new Size(width, 50);
            box2.Location = new Point(x2, y);
            box2.BorderStyle = BorderStyle.FixedSingle;
            box2.Font = new Font("Segoe UI", 24);
            box2.BackColor = Color.FromArgb(255, 255, 255);

            panel.Controls.Add(label1);
            panel.Controls.Add(box1);
            panel.Controls.Add(label2);
            panel.Controls.Add(box2);

            return new InputPair(box1, box2);
        }

        /**
         * Creates a new input TextBox that has a label above,
         * and then a TextBox below. You can specify the y level
         * of where the input field should be located.
         * 
         * This is method also provides a toggle icon which
         * changes the visibility of the inputted text.
         */
        public static TextBox CreatePasswordInput(Panel panel, string placeholder, int y)
        {
            Label label = new Label();
            label.BackColor = Color.Transparent;
            label.Text = placeholder;
            label.ForeColor = Variables.FOREGROUND_COLOUR;
            label.Font = new Font("Segoe UI", 24);
            label.Location = new Point(-5, y - 50);
            label.AutoSize = true;

            TextBox box = new TextBox();
            box.Size = new Size((int)(panel.Width * 0.9), 50);
            box.Location = new Point(0, y);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = new Font("Segoe UI", 24);
            box.BackColor = Color.FromArgb(255, 255, 255);

            PictureBox toggle = new PictureBox();
            toggle.Size = new Size(32, 32);
            toggle.Location = new Point(
                box.Location.X + box.Width - 38,
                box.Location.Y + (box.Height - toggle.Height) / 2
            );
            toggle.SizeMode = PictureBoxSizeMode.Zoom;
            toggle.Image = Properties.Resources.visibility_off;

            bool visible = false;
            toggle.Click += (s, e) =>
            {
                visible = !visible;
                box.UseSystemPasswordChar = !visible;

                toggle.Image = visible ? Properties.Resources.visibility_on : Properties.Resources.visibility_off;
            };

            panel.Controls.Add(label);
            panel.Controls.Add(box);
            panel.Controls.Add(toggle);

            toggle.BringToFront();

            return box;
        }

        public static InputPair CreatePasswordInputPair(Panel panel, string placeholder1, string placeholder2, int y)
        {
            int width = ((int)(panel.Width * 0.9) - PAIR_SPACING) / 2;

            int x1 = 0;
            int x2 = width + PAIR_SPACING;

            TextBox box1 = CreatePasswordInputAt(panel, placeholder1, x1, y, width);
            TextBox box2 = CreatePasswordInputAt(panel, placeholder2, x2, y, width);

            return new InputPair(box1, box2);
        }

        private static TextBox CreatePasswordInputAt(Panel panel, string placeholder, int x, int y, int width)
        {
            Label label = new Label();
            label.BackColor = Color.Transparent;
            label.Text = placeholder;
            label.ForeColor = Variables.FOREGROUND_COLOUR;
            label.Font = new Font("Segoe UI", 24);
            label.Location = new Point(x - 5, y - 50);
            label.AutoSize = true;

            TextBox box = new TextBox();
            box.Size = new Size(width, 50);
            box.Location = new Point(x, y);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = new Font("Segoe UI", 24);
            box.BackColor = Color.FromArgb(255, 255, 255);
            box.UseSystemPasswordChar = true;

            PictureBox toggle = new PictureBox();
            toggle.Size = new Size(32, 32);
            toggle.Location = new Point(
                x + width - 38,
                y + (50 - toggle.Height) / 2
            );
            toggle.SizeMode = PictureBoxSizeMode.Zoom;
            toggle.Image = Properties.Resources.visibility_off;

            bool visible = false;

            toggle.Click += (s, e) =>
            {
                visible = !visible;
                box.UseSystemPasswordChar = !visible;

                toggle.Image = visible
                    ? Properties.Resources.visibility_on
                    : Properties.Resources.visibility_off;
            };

            panel.Controls.Add(label);
            panel.Controls.Add(box);
            panel.Controls.Add(toggle);

            toggle.BringToFront();

            return box;
        }

        public static Button CreateInputConfirmButton(Panel panel, string text, int y)
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

        public static Button CreateInputSecondaryButton(Panel panel, string text, int y)
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
