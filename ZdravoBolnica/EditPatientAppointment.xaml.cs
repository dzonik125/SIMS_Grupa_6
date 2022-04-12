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

        public EditPatientAppointment(Appointment selectedAppointment)
        {
            appointment = selectedAppointment;
            InitializeComponent();
            DatePicker.SelectedDate = appointment.startTime;
            Tb.Text = appointment.startTime.ToString("HH:mm");


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            appointment.startTime = DateTime.Parse(DatePicker.Text + " " + Tb.Text);
            ac.UpdateAppointment(appointment);
            this.Close();
            PatientWindow pw = PatientWindow.Instance;
            pw.refresh();
        }
    }
}
