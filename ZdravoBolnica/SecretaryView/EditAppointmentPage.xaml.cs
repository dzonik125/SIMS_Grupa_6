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
        public List<Appointment> appointmentss = new List<Appointment>();
        public List<string> appointmentTime = new List<string>();
        public EditAppointmentPage(Appointment selectedAppointment)
        {
            appointment = selectedAppointment;
            InitializeComponent();

            List<string> duration = new List<string>() { "30 minuta", "60 minuta", "90 minuta" };
            Duration.ItemsSource = duration;

            appointmentTime = new List<string>() { "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00" };
            Time.ItemsSource = appointmentTime;

            InitComboBoxes();
            DatePicker.SelectedDate = appointment.startTime;
        }
        public void InitComboBoxes()
        {
            InitRoom();
            InitPatient();
            InitDoctor();
            InitTime();
            InitDuration();

        }
        private void InitDoctor()
        {
            int index = 0;
            doctors = doctorController.GetAllDoctors();
            DoctorBox.ItemsSource = doctors;
            foreach (Doctor d in doctors)
            {
                if (d.id.Equals(appointment.doctor.id))
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
                if (r.id.Equals(appointment.room.id))
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

        private void InitDuration()
        {
            if (appointment.duration == 30)
                Duration.SelectedIndex = 0;
            else if (appointment.duration == 60)
                Duration.SelectedIndex = 1;
            else
                Duration.SelectedIndex = 2;
        }

        private void InitTime()
        {
            int index = 0;
            foreach (String a in appointmentTime)
            {
                if (a.Equals(appointment.GetAppoitmentTime()))
                {
                    break;
                }
                index++;
            }
            Time.SelectedIndex = index;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            appointment.doctor.id = getSelectedDoctor().id;
            appointment.patient.id = getSelectedPatient().id;
            appointment.room.id = getSelectedRoom().id;
            String dateAndTime = DatePicker.Text + " " + Time.Text;
            DateTime timeStamp = DateTime.Parse(dateAndTime);
            appointment.startTime = timeStamp;

            if (Duration.SelectedIndex == 0)
                appointment.duration = 30;
            else if (Duration.SelectedIndex == 1)
                appointment.duration = 60;
            else
                appointment.duration = 90;

            //     appointment.id = getSelectedAppointment().id;

            // appointment.duration = int.Parse(Duration.Text);
            Appointments appointments = Appointments.Instance;
            // appointment.Doctor.id = appointments.doctorUser.id;


            if (ValidationAppointment())
            {
                appointmentController.UpdateAppointment(appointment);
                appointments.Refresh();
                SecretaryView.Instance.SetContent(new CreateAppointmentPage());
            }

            // appointmentController.UpdateAppointment(appointment);
            // appointments.Refresh();

            // SecretaryView.Instance.SetContent(new CreateAppointmentPage());

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new CreateAppointmentPage());
        }


        private bool ValidationAppointment()
        {
            AppointmentController appointmentController = new AppointmentController();
            List<Appointment> appointments = appointmentController.GetAllAppointments();
            foreach (Appointment a in appointments)
            {
                if (a.GetEndTime() > appointment.startTime && a.startTime < appointment.GetEndTime() && !a.id.Equals(appointment.id))
                {
                    if (a.doctor.id.Equals(appointment.doctor.id))
                    {
                        MessageBox.Show("Doktor je zauzet u ovom terminu!");
                        return false;
                    }
                    else if (a.room.id.Equals(appointment.room.id))
                    {
                        MessageBox.Show("Soba je zauzeta u ovom terminu!");
                        return false;
                    }
                }
            }
            return true;
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
