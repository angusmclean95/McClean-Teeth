using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using McClean_Teeth.Util.UI_Components.Inputs;
using McClean_Teeth.Util.UI_Components.Inputs.types;

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
            InputPair<TextBoxInput> namesPair = UIInputFactory.CreateTextBoxPair(pnlInput, "Forename", "Surname", 240);
            TextBoxInput forename = namesPair.GetFirst();
            TextBoxInput surname = namesPair.GetSecond();

            //Address Line 1 & 2
            TextBoxInput addressLine = UIInputFactory.CreateTextBox(pnlInput, "Address Line", 340);

            // Postcode and City
            InputPair<TextBoxInput> addressPair = UIInputFactory.CreateTextBoxPair(pnlInput, "Postcode", "City", 440);
            TextBoxInput postcode = addressPair.GetFirst();
            TextBoxInput city = addressPair.GetSecond();

            // Email Address
            TextBoxInput emailAddress = UIInputFactory.CreateTextBox(pnlInput, "Email Address", 540);

            // Password and Confirm
            InputPair<TextBoxInput> passwordPair = UIInputFactory.CreateTextBoxPair(pnlInput, "Password", "Confirm Password", 640);
            TextBoxInput password = passwordPair.GetFirst();
            TextBoxInput confirmPassword = passwordPair.GetSecond();

            Label account = new Label();
            account.Text = "Already got an account? Log in here!";
            account.AutoSize = true;
            account.ForeColor = Variables.FOREGROUND_COLOUR;
            account.Font = new Font("Segoe UI", 16);
            account.Location = new Point(-5, 720);
            account.Click += (sender, e) =>
            {
                AuthForm lgoinForm = new AuthForm();
                lgoinForm.ShowDialog();

                this.Close();
            };
            pnlInput.Controls.Add(account);

            // Confirm Button
            Button confirmButton = UIUtil.CreateConfirmButton(pnlInput, "Register Account", 760);
            ClickConfirm(confirmButton, forename, surname, addressLine, postcode, city, emailAddress, password, confirmPassword);
        }

        private void ClickConfirm(Button confirm, TextBoxInput forename, TextBoxInput surname, TextBoxInput addressLine, TextBoxInput postcode, TextBoxInput city, TextBoxInput emailAddress, TextBoxInput password, TextBoxInput confirmPassword)
        {
            confirm.Click += (sender, e) =>
            {
                if (ValidationUtil.isNullOrEmpty(forename, surname, addressLine, postcode, city, emailAddress, password, confirmPassword))
                {
                    MessageBox.Show("Please fill in all fields required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string inputtedPostcode = postcode.Control.Text;
                if(!ValidationUtil.isValidPostcode(inputtedPostcode))
                {
                    MessageBox.Show("Please enter a valid Postcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                string inputtedEmail = emailAddress.Control.Text;
                if(!ValidationUtil.isValidEmailAddress(inputtedEmail))
                {
                    MessageBox.Show("Please enter a valid Email Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string inputtedPassword = password.Control.Text;
                string inputtedConfirmPassword = confirmPassword.Control.Text;

                if (!ValidationUtil.isMatching(inputtedPassword, inputtedConfirmPassword))
                {
                    MessageBox.Show("Password's do not match, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidationUtil.isValidPassword(inputtedPassword))
                {
                    MessageBox.Show("Please enter a valid Password. Minimum of 8 characters containing at least 1 Uppercase, 1 Lowercase, 1 number & 1 symbol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            };
        }
    }
}
