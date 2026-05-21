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
        private Customer loggedIn;

        // FAKE DATA
        private Appointment[] appointments;

        public AppointmentsForm(Customer loggedIn)
        {
            InitializeComponent();

            this.loggedIn = loggedIn;
            this.appointments = new Appointment[] {
                new Appointment(loggedIn, DateTime.Now.AddDays(1), TreatmentType.Filling, "I need a new filling placed onto my tooth."),
                new Appointment(loggedIn, DateTime.Now.AddDays(3), TreatmentType.Hygiene, "I need a cleaning done on my teeth."),
                new Appointment(loggedIn, DateTime.Now.AddDays(5), TreatmentType.Teeth_Whitening, "I want to get my teeth whitened for an upcoming event."),
                new Appointment(loggedIn, DateTime.Now.AddMinutes(5), TreatmentType.Veneers, "I need to get a veneer placed on my front tooth."),
                new Appointment(loggedIn, DateTime.Now.AddMonths(1), TreatmentType.Checkup, "I just want to get a checkup done on my teeth.")
            };

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
        }

        private void InitCards()
        {
            for (int i = 0; i < appointments.Length; i++)
            {
                appointments[i].CreateCard(pnlAppointments, i);
            }
        }
    }
}
