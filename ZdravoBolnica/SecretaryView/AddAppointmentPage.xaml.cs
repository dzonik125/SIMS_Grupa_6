using Controller;
using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for AddAppointmentPage.xaml
    /// </summary>
    public partial class AddAppointmentPage : Page
    {
        public List<Patient> patients;
        public List<Room> rooms;
        public List<Doctor> doctors;
        public PatientController pc = new PatientController();
        public RoomController rc = new RoomController();
        public AppointmentController ac = new AppointmentController();
        public AppointmentType appointmentType;
        private DoctorController dc = new DoctorController();
        public AddAppointmentPage(AppointmentType type)
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

            List<string> duration = new List<string>() { "30 minuta", "60 minuta", "90 minuta" };
            Duration.ItemsSource = duration;

            List<string> appointmentsTime = new List<string>() { "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "23:00", "23:30", "00:00" };
            Time.ItemsSource = appointmentsTime;

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

            if (Duration.SelectedIndex == 0)
                a.duration = 30;
            else if (Duration.SelectedIndex == 1)
                a.duration = 60;
            else
                a.duration = 90;

            // a.duration = int.Parse(Duration.Text);
            CreateAppointment appointments = CreateAppointment.Instance;

            // if (ac.IntersectionWithAppointments(a.patient.id, a.Doctor.id, a.Room.id, a.startTime, a.duration))
            // {
            //    MessageBox.Show("Popini sva polja.");
            //    return;
            // }
            if (ValidationAppointment(a))
            {
                ac.SaveAppointment(a);
                appointments.Refresh();
                SecretaryView.Instance.SetContent(new CreateAppointmentPage());
            }

        }

        private bool ValidationAppointment(Appointment appointment)
        {
            AppointmentController appointmentController = new AppointmentController();
            List<Appointment> appointments = appointmentController.GetAllApointments();
            foreach (Appointment a in appointments)
            {
                if (a.GetEndTime() > appointment.startTime && a.startTime < appointment.GetEndTime() && !a.id.Equals(appointment.id))
                {
                    if (a.Doctor.id.Equals(appointment.Doctor.id))
                    {
                        MessageBox.Show("Doktor je zauzet u ovom terminu!");
                        return false;
                    }
                    else if (a.Room.id.Equals(appointment.Room.id))
                    {
                        MessageBox.Show("Soba je zauzeta u ovom terminu!");
                        return false;
                    }
                }
            }
            return true;
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
            SecretaryView.Instance.SetContent(new CreateAppointmentPage());
        }
    }
}
