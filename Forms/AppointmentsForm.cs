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
    public partial class AppointmentsForm : Form
    {
        // MySQL Queries
        private static readonly string GET_APPOINTMENTS = "SELECT BookingID, Treatment, BookingDate, BookingTime, Notes, CustomerID FROM booking_details WHERE CustomerID = @CustomerID ORDER BY BookingDate, BookingTime";

        private Customer loggedIn;

        private List<Appointment> appointments = new List<Appointment>();

        public AppointmentsForm(Customer loggedIn)
        {
            InitializeComponent();

            this.loggedIn = loggedIn;

            LoadAppointmentsFromDatabase();

            InitForm();
            InitPanel();
            InitCards();
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

            lblTitle.ForeColor = Variables.FOREGROUND_COLOUR;

            Button bookButton = UIInputFactory.CreateSecondaryButton(pnlCard, "Book New Appointment", lblTitle.Location.Y);
            bookButton.Width = pnlCard.Width - 20;
            bookButton.Location = new Point(10, pnlCard.Height - bookButton.Height - 10);
            bookButton.Click += (sender, e) =>
            {
                this.Hide();
                BookingForm bookingForm = new BookingForm(loggedIn);
                bookingForm.ShowDialog();
                this.Close();
            };
        }

        private void InitCards()
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                appointments[i].CreateCard(pnlAppointments, i);
            }
        }

        private void LoadAppointmentsFromDatabase()
        {
            List<Dictionary<string, object>> rows = Program.database.Query(GET_APPOINTMENTS, new Dictionary<string, object>
            {
                { "@CustomerID", loggedIn.CustomerID }
            });

            appointments.Clear();

            foreach (var row in rows)
            {
                appointments.Add(new Appointment(
                    loggedIn,
                    ((DateTime)row["BookingDate"]).Date + (TimeSpan)row["BookingTime"],
                    TreatmentTypeUtil.FromUppercase(row["Treatment"].ToString()),
                    row["Notes"].ToString()
                ));

            }
        }
    }
}
