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
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();

            InitForm();
            InitPanel();
            InitLogo();
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

        /**
         * We will use this method to update the logo's
         * properties such as the size and location.
         */
        private void InitLogo()
        {
            // Sets the logo size to be 40% of the panel's width and 100% of the panel's height
            picLogo.Width = (int)(pnlCard.Width * 0.4);
            picLogo.Height = pnlCard.Height - 200;

            // Set the logo's position to the top right corner of the panel   
            picLogo.Location = new Point(
                pnlCard.Width - picLogo.Width - 75,
                100
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

            // Username
            TextBox usernameEmailBox = UIUtil.CreateInput(pnlInput, "Email or Username", 240);

            // Password
            TextBox passwordBox = UIUtil.CreatePasswordInput(pnlInput, "Password", 340);

            // Confirm Button
            Button confirmButton = UIUtil.CreateInputConfirmButton(pnlInput, "Login", pnlInput.Height - 160);

            ClickConfirm(confirmButton, usernameEmailBox, passwordBox);

            // Create Account Button
            Button createAccountButton = UIUtil.CreateInputSecondaryButton(pnlInput, "Create Account", pnlInput.Height - 90);
            createAccountButton.Click += (sender, e) =>
            {
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.ShowDialog();

                this.Close();    
            };
        }

        private void ClickConfirm(Button confirm, TextBox usernameEmailBox, TextBox passwordBox)
        {
            confirm.Click += (sender, e) =>
            {
                string username = usernameEmailBox.Text;
                string password = passwordBox.Text;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
                {
                    MessageBox.Show("Please enter valid Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            };
        }
    }
}
