using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            InitForm();
            InitPanel();
            InitInput();
        }

        /**
         * We will use this method to update the form's
         * properties such as the background colour.
         */
        private void InitForm()
        {
            this.BackColor = Color.FromArgb(84, 78, 71);
        }

        /**
         * We will use this method to update the panel's
         * properties such as the background colour, size and location.
         */
        private void InitPanel()
        {
            // Changes the background colour to a semi-transparent white
            pnlCard.BackColor = Color.FromArgb(150, 255, 255, 255);

            // Updates the width and height of the panel to be exactly 50 pixels less than the form's width and height
            pnlCard.Width = this.ClientSize.Width - 120;
            pnlCard.Height = this.ClientSize.Height - 120;

            // Centers the panel within the form by calculating the appropriate location based on the form's client size and the panel's size
            pnlCard.Location = new Point(
                (this.ClientSize.Width - pnlCard.Width) / 2,
                (this.ClientSize.Height - pnlCard.Height) / 2
            );
        }

        private void InitInput()
        {
            // Set the input panel's size to be 50% of the panel's width and 100% of the panel's height
            pnlInput.Width = (int)(pnlCard.Width * 0.5);
            pnlInput.Height = pnlCard.Height;

            // Set the input panel's position to the top left corner of the panel
            pnlInput.Location = new Point(
                30,
                0
            );

            // Set the title to the top left corner of the input panel
            lblTitle.Location = new Point(-10, 15);
            lblTitle.ForeColor = Variables.FOREGROUND_COLOUR;

            // Set the sub title location below the title
            lblSubtitle.Location = new Point(-5, lblSubtitle.Location.Y);
            lblSubtitle.ForeColor = Variables.FOREGROUND_COLOUR;

            // Names
            InputPair namesPair = UIUtil.CreateInputPair(pnlInput, "Forename", "Surname", 240);
            TextBox forename = namesPair.GetFirst();
            TextBox surname = namesPair.GetSecond();

            //Address Line 1 & 2
            TextBox addressLineOne = UIUtil.CreateInput(pnlInput, "Address Line 1", 340);
            TextBox addressLinetwo = UIUtil.CreateInput(pnlInput, "Address Line 2", 440);

            // Postcode and City
            InputPair addressPair = UIUtil.CreateInputPair(pnlInput, "Postcode", "City", 540);
            TextBox postcode = addressPair.GetFirst();
            TextBox city = addressPair.GetSecond();

            // Email Address
            TextBox emailAddress = UIUtil.CreateInput(pnlInput, "Email Address", 640);

            // Password and Confirm
            InputPair passwordPair = UIUtil.CreatePasswordInputPair(pnlInput, "Password", "Confirm Password", 740);
            TextBox password = passwordPair.GetFirst();
            TextBox confirmPassword = passwordPair.GetSecond();

            Label account = new Label();
            account.Text = "Already got an account? Log in here!";
            account.AutoSize = true;
            account.ForeColor = Variables.FOREGROUND_COLOUR;
            account.Font = new Font("Segoe UI", 16);
            account.Location = new Point(-5, 820);
            pnlInput.Controls.Add(account);

            // Confirm Button
            Button confirmButton = UIUtil.CreateInputConfirmButton(pnlInput, "Register Account", 860);
        }
    }
}
