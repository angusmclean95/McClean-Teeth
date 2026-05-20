using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McClean_Teeth.Util.UI_Components.Inputs.types;
using System.Windows.Forms;
using System.Drawing;

namespace McClean_Teeth.Util.UI_Components.Inputs
{
    public static class UIInputFactory
    {
        private static readonly int PAIR_SPACING = 10;

        /*
         * Gets 90% of a panels width.
         * Helper for adding padding to edges
         * of panels or controls
         */
        private static int GetFullWidth(Panel panel)
        {
            return (int)(panel.Width * 0.9);
        }

        /*
         * Gets 90% width of a panel but splitting it
         * into two so that two controls can be added
         * but take up the same amount of space as a
         * single control would.
         */
        private static int GetPairWidth(Panel panel)
        {
            return (GetFullWidth(panel) - PAIR_SPACING) / 2;
        }

        /*
         * Creates a new instance of one of the UIInput types
         * and adds it to the given panel.
         */
        private static T CreateSingle<T>(Panel panel, Func<int, T> creator) where T : UIInput
        {
            int width = GetFullWidth(panel);

            T input = creator(width);
            input.AddToPanel(panel);

            return input;
        }

        /*
         * Creates two new instances of one of the UIInput types
         * and adds them to the given panel.
         */
        private static InputPair<T> CreatePair<T>(Panel panel, Func<int, int, T> creator) where T : UIInput
        {
            int width = GetPairWidth(panel);

            T first = creator(0, width);
            T second = creator(width + PAIR_SPACING, width);

            first.AddToPanel(panel);
            second.AddToPanel(panel);

            return new InputPair<T>(first, second);
        }

        public static TextBoxInput CreateTextBox(Panel panel, string label, int y)
        {
            return CreateSingle(
                panel,
                width => new TextBoxInput(label, 0, y, width)
            );
        }

        public static InputPair<TextBoxInput> CreateTextBoxPair(Panel panel, string label1, string label2, int y)
        {
            int index = 0;

            return CreatePair(
                panel,
                (x, width) =>
                {
                    string label = index++ == 0 ? label1 : label2;
                    return new TextBoxInput(label, x, y, width);
                }
            );
        }

        public static PasswordInput CreatePasswordInput(Panel panel, string label, int y)
        {
            return CreateSingle(
                panel,
                width => new PasswordInput(label, 0, y, width)
            );
        }

        public static InputPair<PasswordInput> CreatePasswordInputPair(Panel panel, string label1, string label2, int y)
        {
            int index = 0;

            return CreatePair(
                panel,
                (x, width) =>
                {
                    string label = index++ == 0 ? label1 : label2;
                    return new PasswordInput(label, x, y, width);
                }
            );
        }

        public static ComboBoxInput CreateComboBox(Panel panel, string label, List<string> items, int y)
        {
            return CreateSingle(
                panel,
                width => new ComboBoxInput(label, 0, y, width, items)
            );
        }

        public static CalendarInput CreateMonthCalendar(Panel panel, string label, int y)
        {
            return CreateSingle(
                panel,
                width => new CalendarInput(label, 0, y, width)
            );
        }

        public static Button CreatePrimaryButton(Panel panel, string text, int y)
        {
            return CreateButton(panel, text, y, Color.FromArgb(196, 178, 141), Color.White);
        }

        public static Button CreateSecondaryButton(Panel panel, string text, int y)
        {
            return CreateButton(panel, text, y, Color.White, Color.FromArgb(94, 95, 94));
        }

        private static Button CreateButton(Panel panel, string text, int y, Color backColor, Color foreColor)
        {
            Button button = new Button();

            button.Text = text;
            button.Size = new Size(GetFullWidth(panel), 60);
            button.Location = new Point(0, y);
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 24);
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            panel.Controls.Add(button);

            return button;
        }
    }
}
