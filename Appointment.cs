using McClean_Teeth.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth
{
    internal class Appointment
    {
        // Customer associated with the appointment.
        public Customer Customer { get; }

        // Date and time of the appointment.
        public DateTime DateTime { get; }

        // Type of treatment for the appointment.
        public TreatmentType Type { get; }

        // Additional information provided by the customer for the appointment.
        public string InformationProvided { get; }

        public Appointment(Customer customer, DateTime dateTime, TreatmentType type, string informationProvided)
        {
            Customer = customer;
            DateTime = dateTime;
            Type = type;
            InformationProvided = informationProvided;
        }

        /*
         * Gets the panel for viewing this appointment.
         * Displays all information about the appointment.
         */
        public Panel CreateCard(Panel parent, int index)
        {
            // Creates a card for the appointment
            Panel card = new Panel();
            card.BackColor = Color.FromArgb(196, 178, 141);
            card.Size = new Size(parent.Width - 50, 145);
            card.Location = new Point(0, index * 160);

            // Adds a little accent to the left of the card to make it look nicer
            Panel accent = new Panel();
            accent.BackColor = Color.FromArgb(175, 160, 125);
            accent.Size = new Size(8, card.Height);
            accent.Location = new Point(0, 0);

            // Adds the customer's name to the card
            Label customerName = new Label();
            customerName.Text = Customer.Username;
            customerName.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            customerName.ForeColor = Color.White;
            customerName.AutoSize = true;
            customerName.Location = new Point(22, 12);

            // Adds the information provided by the customer to the card
            Label info = new Label();
            info.Text = InformationProvided;
            info.Font = new Font("Segoe UI", 11);
            info.ForeColor = Color.White;
            info.MaximumSize = new Size(700, 0);
            info.AutoSize = true;
            info.Location = new Point(24, 60);

            // Add a right panel to the card to display the treatment type and appointment date
            Panel rightPanel = new Panel();
            rightPanel.Size = new Size(280, card.Height);
            rightPanel.Location = new Point(card.Width - rightPanel.Width - 20, 0);
            rightPanel.BackColor = Color.FromArgb(175, 160, 125);

            // Add the treatment type and appointment date to the right panel
            Label treatmentType = new Label();
            treatmentType.Text = TreatmentTypeUtil.GetDisplayName(Type);
            treatmentType.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            treatmentType.ForeColor = Color.White;
            treatmentType.AutoSize = false;
            treatmentType.TextAlign = ContentAlignment.MiddleCenter;
            treatmentType.Size = new Size(rightPanel.Width, (rightPanel.Height / 2));
            treatmentType.Location = new Point(0, 20);

            // Formats the appointment date and time using the FormatUtil class and adds it to the right panel
            Label appointmentDate = new Label();
            appointmentDate.Text =FormatUtil.FormatDateTime(DateTime);
            appointmentDate.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            appointmentDate.ForeColor = Color.FromArgb(245, 245, 245);
            appointmentDate.AutoSize = false;
            appointmentDate.TextAlign = ContentAlignment.MiddleCenter;
            appointmentDate.Size = new Size(rightPanel.Width, 50);
            appointmentDate.Location = new Point(0, (rightPanel.Height / 2));

            // Following code adds all the components to the cards and panels
            rightPanel.Controls.Add(treatmentType);
            rightPanel.Controls.Add(appointmentDate);

            card.Controls.Add(accent);
            card.Controls.Add(customerName);
            card.Controls.Add(info);
            card.Controls.Add(rightPanel);

            parent.Controls.Add(card);

            return card;
        }
    }
}
