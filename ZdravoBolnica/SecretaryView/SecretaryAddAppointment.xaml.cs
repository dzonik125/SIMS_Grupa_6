using Controller;
using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for SecretaryAddAppointment.xaml
    /// </summary>
    public partial class SecretaryAddAppointment : Window
    {
        public List<Patient> patients;
        public List<Room> rooms;
        public List<Doctor> doctors;
        public PatientController pc = new PatientController();
        public RoomController rc = new RoomController();
        public AppointmentController ac = new AppointmentController();
        public AppointmentType appointmentType;
        private DoctorController dc = new DoctorController();
        public SecretaryAddAppointment(AppointmentType type)
        {
            appointmentType = type;
            RoomType roomType = type == AppointmentType.examination ? RoomType.examination : RoomType.surgery;
            InitializeComponent();
            patients = pc.FindAllPatients();
            doctors = dc.GetAllDoctors();
            rooms = rc.getRoomsByType(roomType);
            PatientBox.ItemsSource = patients;
            RoomBox.ItemsSource = rooms;
            DoctorBox.ItemsSource = doctors;
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment();

            a.Doctor = new Doctor();
            a.Doctor.id = getSelectedDoctor().id;
            a.patient = new Patient();
            a.patient.id = getSelectedPatient().id;
            a.Room = new Room();
            a.Room.id = getSelectedRoom().id;
            a.Type = appointmentType;
            String dateAndTime = DatePicker.Text + " " + Time.Text;
            DateTime timeStamp = DateTime.Parse(dateAndTime);
            a.startTime = timeStamp;
            a.duration = int.Parse(Duration.Text);
            CreateAppointment appointments = CreateAppointment.Instance;

            if (ac.IntersectionWithAppointments(a.patient.id, a.Doctor.id, a.Room.id, a.startTime, a.duration))
            {
                MessageBox.Show("ne.");
                return;
            }
            else
            {
                ac.SaveAppointment(a);
                
                appointments.Refresh();
                this.Close();
            }
        }

        public Patient getSelectedPatient()
        {
            Patient p = patients[PatientBox.SelectedIndex];
            return p;
        }
        public Doctor getSelectedDoctor()
        {
            Doctor d = doctors[DoctorBox.SelectedIndex];
            return d;
        }

        public Room getSelectedRoom()
        {
            Room r = rooms[RoomBox.SelectedIndex];
            return r;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
