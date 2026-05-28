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
        // MySQL Queries
        private static readonly string INSERT_BOOKING = "INSERT INTO booking_details (Treatment, BookingDate, BookingTime, Notes, CustomerID) VALUES (@Treatment, @BookingDate, @BookingTime, @Notes, @CustomerID)";
        private static readonly string CHECK_BOOKING_EXISTS = "SELECT COUNT(*) AS Count FROM booking_details WHERE BookingDate = @BookingDate AND BookingTime = @BookingTime";

        private Customer loggedIn;

        public BookingForm(Customer loggedIn)
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
            ClickConfirm(confirmButton, treatmentSelection, moreInfo, date);
        }

        private bool IsSlotAlreadyBooked(DateTime selectedDate)
        {
            List<Dictionary<string, object>> result = Program.database.Query(CHECK_BOOKING_EXISTS, new Dictionary<string, object>
            {
                { "@BookingDate", selectedDate.Date },
                { "@BookingTime", selectedDate.TimeOfDay }
            });

            if (result.Count == 0)
            {
                return false;
            }

            int count = Convert.ToInt32(result[0]["Count"]);
            return count > 0;
        }

        private void ClickConfirm(Button confirm, ComboBoxInput treatmentSelection, TextBoxInput moreInfo, CalendarInput date)
        {
            confirm.Click += (sender, e) =>
            {
                if (treatmentSelection.Control.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Please select a treatment.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                TreatmentType treatment = TreatmentTypeUtil.FromDisplayName(treatmentSelection.Control.SelectedItem.ToString());
                DateTime selectedDate = date.Control.SelectedDateTime;

                // Prevent past bookings
                if (selectedDate < DateTime.Now)
                {
                    MessageBox.Show(
                        "You cannot book an appointment in the past.",
                        "Invalid Date",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // Check if slot already exists
                if (IsSlotAlreadyBooked(selectedDate))
                {
                    MessageBox.Show(
                        "This appointment slot is already booked. Please choose another date or time.",
                        "Slot Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                Program.database.Execute(INSERT_BOOKING, new Dictionary<string, object>
                {
                    { "@Treatment", treatment.ToString() },
                    { "@BookingDate", selectedDate.Date },
                    { "@BookingTime", selectedDate.TimeOfDay },
                    { "@Notes", moreInfo.Control.Text },
                    { "@CustomerID", loggedIn.CustomerID }
                });

                MessageBox.Show(
                    "Appointment booked successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Hide();
                new AppointmentsForm(loggedIn).ShowDialog();
                this.Close();
            };
        }
    }
}
