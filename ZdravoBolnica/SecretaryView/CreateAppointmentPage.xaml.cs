using Controller;
using Model;
using SIMS.Model;
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

            appController.BindPatientsWithAppointments(appointments);
            appController.BindRoomsWithAppointments(appointments);
            appController.BindDoctorsWithAppointments(appointments);

            foreach (Appointment a in appointments)
            {
                if (a.room == null || a.patient == null || a.doctor == null)
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

        private void EmergencySurgery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditApp_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = dataGridAppointments.SelectedItem as Appointment;
            if (selectedAppointment == null)
            {
                MessageBox.Show("Izabrati termin.");
                return;
            }

            SecretaryView.Instance.SetContent(new EditAppointmentPage(selectedAppointment));

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
