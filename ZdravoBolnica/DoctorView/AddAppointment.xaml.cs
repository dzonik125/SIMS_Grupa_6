using Controller;
using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {

        public List<Patient> patients;
        public List<Room> rooms;
        public PatientController pc = new PatientController();
        public RoomController rc = new RoomController();
        public AppointmentController ac = new AppointmentController();
        public AppointmentType appointmentType;
        public AddAppointment(AppointmentType type)
        {
            appointmentType = type;
            RoomType roomType = type == AppointmentType.examination ? RoomType.examination : RoomType.surgery;
            InitializeComponent();
            patients = pc.FindAllPatients();
            rooms = rc.getRoomsByType(roomType);
            PatientBox.ItemsSource = patients;
            RoomBox.ItemsSource = rooms;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment();
            a.patient = new Patient();
            a.patient.id = getSelectedPatient().id;
            a.Room = new Room();
            a.Room.id = getSelectedRoom().id;
            a.Type = appointmentType;
            a.id = DateTime.Now.ToString("yyMMddHHmmssff");
            String dateAndTime = DatePicker.Text + " " + Time.Text;
            DateTime timeStamp = DateTime.Parse(dateAndTime);
            a.startTime = timeStamp;
            a.duration = int.Parse(Duration.Text);
            Appointments appointments = Appointments.Instance;
            a.Doctor = new Doctor();
            a.Doctor.id = appointments.doctorUser.id;
            if (ac.IntersectionWithAppointments(a.patient.id, a.Doctor.id, a.Room.id, a.startTime, a.duration))
            {
                MessageBox.Show("ne.");
                return;
            }
            else
            {
                ac.SaveAppointment(a);
                this.Close();
                appointments.Refresh();
            }

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
