using Controller;
using Model;
using SIMS.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        public static CreateAppointment instance = new CreateAppointment();
        public Doctor doctorUser { get; set; }

        private AppointmentController appController = new AppointmentController();
        private AccountController patientController = new AccountController();
        private DoctorController doctorController = new DoctorController();
        private RoomController roomController = new RoomController();
        private ObservableCollection<Appointment> apps;

        public ObservableCollection<Appointment> Apps { get; set; }

        public static CreateAppointment Instance
        {
            get
            {
                return instance;
            }
        }
        public CreateAppointment()
        {
            InitializeComponent();
            this.DataContext = this;
            Apps = new ObservableCollection<Appointment>();
            doctorUser = doctorController.GetAllDoctors()[0];

            Refresh();
        }


        public void Refresh()
        {
            Apps.Clear();

            List<Appointment> appointments = new();
            appointments = appController.getFutureAppointmentsForDoctor(doctorUser.id);
            List<Patient> patients = patientController.FindAllAccounts();
            List<Room> rooms = roomController.FindAll();
            List<Doctor> doctors = doctorController.GetAllDoctors();
            appController.bindPatientsWithAppointments(patients, appointments);
            appController.bindRoomsWithAppointments(rooms, appointments);
            appController.bindDoctorsWithAppointments(doctors, appointments);

            foreach (Appointment a in appointments)
            {
                if (a.Room == null || a.patient == null || a.Doctor == null)
                    continue;
                Apps.Add(a);
            }
        }

        private void Scehdule_Click(object sender, RoutedEventArgs e)
        {
            AppointmentType type = AppointmentType.examination;
            SecretaryAddAppointment ap = new SecretaryAddAppointment(type);
            ap.ShowDialog();
        }

        private void ScheduleSurgery_Click(object sender, RoutedEventArgs e)
        {
            AppointmentType type = AppointmentType.surgery;
            SecretaryAddAppointment ap = new SecretaryAddAppointment(type);
            ap.ShowDialog();
        }

        private void EditApp_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = dataGridAppointments.SelectedItem as Appointment;
            if (selectedAppointment == null)
            {
                MessageBox.Show("Izabrati termin.");
                return;
            }


            SecreteryEditAppointment sep = new SecreteryEditAppointment(selectedAppointment);
            sep.ShowDialog();
        }

        private void DeleteApp_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = dataGridAppointments.SelectedItem as Appointment;
            if (selectedAppointment == null)
            {
                MessageBox.Show("Izabrati termin.");
                return;
            }
            appController.DeleteAppointmentById(selectedAppointment.id);
            Refresh();
        }
    }
}
