using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;
using Model;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for EditPatientAppointment.xaml
    /// </summary>
    public partial class EditPatientAppointment : Window
    {

        public Appointment appointment;
        private AppointmentController ac = new AppointmentController();
        private RoomController rc = new RoomController();
        private DateTime oldDateTime;

        public EditPatientAppointment(Appointment selectedAppointment)
        {
            appointment = selectedAppointment;
            InitializeComponent();
            DatePicker.SelectedDate = appointment.startTime;
            Tb.Text = appointment.startTime.ToString("HH:mm");
            oldDateTime = appointment.startTime;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            appointment.startTime = DateTime.Parse(DatePicker.Text + " " + Tb.Text);
            if (rc.findFreeRoom(appointment.startTime) == null)
            {
                MessageBox.Show("Za izabrani datum, nema slobodnih termina." +
                                "Molimo Vas odaberite drugi!");
                return;
            }

            if (DatePicker.SelectedDate == DateTime.Today)
            {
                MessageBox.Show("Ne možete pomeriti termin na današnji datum!");
                return;
            }

            if (DatePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Ne možete odabrati datum koji je prošao!");
                return;
            }


            if ((oldDateTime.Date - DatePicker.SelectedDate.Value.Date).TotalDays > 2 || (DatePicker.SelectedDate.Value.Date - oldDateTime.Date).TotalDays > 2)
            {
                MessageBox.Show("Ne možete pomeriti za više od dva dana.");
                return;
            }

            ac.UpdateAppointment(appointment);
            this.Close();
            PatientWindow pw = PatientWindow.Instance;
            pw.refresh();
        }
    }
}
