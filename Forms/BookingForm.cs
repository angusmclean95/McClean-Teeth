using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using McClean_Teeth.Util;
using McClean_Teeth.Util.UI_Components.Inputs;
using McClean_Teeth.Util.UI_Components.Inputs.types;

namespace McClean_Teeth
{
    public partial class BookingForm : Form
    {
        private User loggedIn;

        public BookingForm(User loggedIn)
        {
            InitializeComponent();

            this.loggedIn = loggedIn;

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

            ComboBoxInput treatmentSelection = UIInputFactory.CreateComboBox(pnlInput, $"What can we help you with, {loggedIn.Username}?", TreatmentTypeUtil.GetAllDisplayNames(), 150);

            TextBoxInput moreInfo = UIInputFactory.CreateTextBox(pnlInput, "Please provide more information", 260);
            moreInfo.Control.Multiline = true;
            moreInfo.Control.Height = 300;

            CalendarInput date = UIInputFactory.CreateMonthCalendar(pnlInput2, "Please select a preferred date and time", 150);

            // Confirm Button
            Button confirmButton = UIInputFactory.CreatePrimaryButton(pnlInput, "Book Appointment", 600);
            //ClickConfirm(confirmButton, forename, surname, addressLine, postcode, city, emailAddress, password, confirmPassword);
        }

        //private void ClickConfirm(Button confirm, TextBox forename, TextBox surname, TextBox addressLine, TextBox postcode, TextBox city, TextBox emailAddress, TextBox password, TextBox confirmPassword)
        //{
        //    confirm.Click += (sender, e) =>
        //    {
        //        if (ValidationUtil.isNullOrEmpty(forename, surname, addressLine, postcode, city, emailAddress, password, confirmPassword))
        //        {
        //            MessageBox.Show("Please fill in all fields required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        string inputtedPostcode = postcode.Text;
        //        if(!ValidationUtil.isValidPostcode(inputtedPostcode))
        //        {
        //            MessageBox.Show("Please enter a valid Postcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }


        //        string inputtedEmail = emailAddress.Text;
        //        if(!ValidationUtil.isValidEmailAddress(inputtedEmail))
        //        {
        //            MessageBox.Show("Please enter a valid Email Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        string inputtedPassword = password.Text;
        //        string inputtedConfirmPassword = confirmPassword.Text;

        //        if (!ValidationUtil.isMatching(inputtedPassword, inputtedConfirmPassword))
        //        {
        //            MessageBox.Show("Password's do not match, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        if (!ValidationUtil.isValidPassword(inputtedPassword))
        //        {
        //            MessageBox.Show("Please enter a valid Password. Minimum of 8 characters containing at least 1 Uppercase, 1 Lowercase, 1 number & 1 symbol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }


        //    };
        //}
    }
}
