using Controller;
using Model;
using SIMS.DoctorView;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for EditAppointmentPage.xaml
    /// </summary>
    public partial class EditAppointmentPage : Page
    {
        public List<Patient> patients = new List<Patient>();
        public List<Room> rooms = new List<Room>();
        public List<Doctor> doctors = new List<Doctor>();
        public AccountController patientController = new AccountController();
        public RoomController roomController = new RoomController();
        public DoctorController doctorController = new DoctorController();
        public AppointmentController appointmentController = new AppointmentController();
        public Appointment appointment;
        public EditAppointmentPage(Appointment selectedAppointment)
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
            InitDoctor();
        }
        private void InitDoctor()
        {
            int index = 0;
            doctors = doctorController.GetAllDoctors();
            DoctorBox.ItemsSource = doctors;
            foreach (Doctor d in doctors)
            {
                if (d.id.Equals(appointment.Doctor.id))
                {
                    break;
                }
                index++;
            }
            DoctorBox.SelectedIndex = index;
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            appointment.Doctor.id = getSelectedDoctor().id;
            appointment.patient.id = getSelectedPatient().id;
            appointment.Room.id = getSelectedRoom().id;
            String dateAndTime = DatePicker.Text + " " + Time.Text;
            DateTime timeStamp = DateTime.Parse(dateAndTime);
            appointment.startTime = timeStamp;
            appointment.duration = int.Parse(Duration.Text);
            Appointments appointments = Appointments.Instance;
            appointment.Doctor.id = appointments.doctorUser.id;

            appointmentController.UpdateAppointment(appointment);
            appointments.Refresh();

            SecretaryView.Instance.SetContent(new CreateAppointmentPage());

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new CreateAppointmentPage());
        }


        public Doctor getSelectedDoctor()
        {
            Doctor d = doctors[DoctorBox.SelectedIndex];
            return d;
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
    }
}
