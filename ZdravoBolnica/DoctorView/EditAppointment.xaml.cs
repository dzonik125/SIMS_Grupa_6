using Controller;
using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;
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

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {
        public List<Patient> patients = new List<Patient>();
        public List<Room> rooms = new List<Room>();
        public AccountController patientController = new AccountController();
        public RoomController roomController = new RoomController();
        public AppointmentController appointmentController = new AppointmentController();
        public Appointment appointment;

        public EditAppointment(Appointment selectedAppointment)
        {
            appointment = selectedAppointment;
            InitializeComponent();
            InitComboBoxes();
            DatePicker.SelectedDate = appointment.startTime;
            Time.Text = appointment.startTime.ToString("HH:mm");
            Duration.Text = appointment.duration.ToString();
            
        }

        public void InitComboBoxes()
        {
            InitRoom();
            InitPatient();
        }


        private void InitRoom()
        {


            int index = 0;
            rooms = roomController.FindAll();
            RoomBox.ItemsSource = rooms;
            foreach (Room r in rooms)
            {
                if (r.id.Equals(appointment.Room.id))
                {
                    break;
                }
                index++;
            }
            RoomBox.SelectedIndex = index;
        }

        private void InitPatient()
        {
            int index = 0;
            patients = patientController.FindAllAccounts();
            PatientBox.ItemsSource = patients;
            foreach (Patient p in patients)
            {
                if (p.id.Equals(appointment.patient.id))
                {
                    break;
                }
                index++;
            }
            PatientBox.SelectedIndex = index;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            appointment.patient.id = getSelectedPatient().id;
            appointment.Room.id = getSelectedRoom().id;
            String dateAndTime = DatePicker.Text + " " + Time.Text;
            DateTime timeStamp = DateTime.Parse(dateAndTime);
            appointment.startTime = timeStamp;
            appointment.duration = int.Parse(Duration.Text);
            Appointments appointments = Appointments.Instance;
            appointment.Doctor.id = appointments.doctorUser.id;
            
            appointmentController.UpdateAppointment(appointment);
            this.Close();
            appointments.Refresh();
            
        }


        public Patient getSelectedPatient()
        {
            Patient p = patients[PatientBox.SelectedIndex];
            return p;
        }

        public Room getSelectedRoom()
        {
            Room r = rooms[RoomBox.SelectedIndex];
            return r;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

        
    
}
