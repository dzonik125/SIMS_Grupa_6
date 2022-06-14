using Controller;
using Model;
using SIMS.Model;
using SIMS.SecretaryView.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for CreateAppointmentPage.xaml
    /// </summary>
    public partial class CreateAppointmentPage : Page
    {
        public static CreateAppointmentPage instance = new CreateAppointmentPage();
        public Doctor doctorUser { get; set; }

        private AppointmentController appController = new AppointmentController();
        private AccountController patientController = new AccountController();
        private DoctorController doctorController = new DoctorController();
        private RoomController roomController = new RoomController();

        public ObservableCollection<Appointment> Apps { get; set; }

        public static CreateAppointmentPage Instance
        {
            get
            {
                return instance;
            }
        }

        public CreateAppointmentPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Apps = new ObservableCollection<Appointment>();

            Refresh();
        }

        public void Refresh()
        {
            Apps.Clear();

            List<Appointment> appointments = appController.GetAllAppointments();
            List<Patient> patients = patientController.FindAllAccounts();
            List<Room> rooms = roomController.FindAll();
            List<Doctor> doctors = doctorController.GetAllDoctors();
            appController.BindPatientsWithAppointments(patients, appointments);
            appController.BindRoomsWithAppointments(rooms, appointments);
            appController.BindDoctorsWithAppointments(doctors, appointments);

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
            SecretaryView.Instance.SetContent(new AddAppointmentPage(type));
        }

        private void ScheduleSurgery_Click(object sender, RoutedEventArgs e)
        {
            AppointmentType type = AppointmentType.surgery;
            SecretaryView.Instance.SetContent(new AddAppointmentPage(type));
        }

        private void EmergencyExamination_Click(object sender, RoutedEventArgs e)
        {
            AppointmentType type = AppointmentType.examination;
            SecretaryView.Instance.SetContent(new AddEmergencyExaminationPage(type));
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

        private void DataGridCell_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Appointment selectedAppointment = dataGridAppointments.SelectedItem as Appointment;
            SecretaryView.Instance.SetContent(new EditAppointmentPage(selectedAppointment));

        }



        private void Report_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new ReportPage());
        }
    }
}
