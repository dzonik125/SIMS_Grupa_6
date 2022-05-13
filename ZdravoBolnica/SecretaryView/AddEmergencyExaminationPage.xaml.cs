using Controller;
using Model;
using SIMS.Model;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for AddEmergencyExaminationPage.xaml
    /// </summary>
    public partial class AddEmergencyExaminationPage : Page
    {
        public List<Patient> patients;
        // public List<Specialization> specializations;
        public List<string> specs;
        public PatientController pc = new PatientController();
        public List<Doctor> doctors;
        public DoctorController dc = new DoctorController();
        public Specialization specialization;
        public AppointmentType appointmentType;
        public List<Appointment> appointments;
        public AppointmentController ac = new AppointmentController();
        public AddEmergencyExaminationPage(AppointmentType type)
        {
            appointmentType = type;
            RoomType roomType = type == AppointmentType.examination ? RoomType.examination : RoomType.surgery;
            InitializeComponent();
            patients = pc.FindAllPatients();


            Specialization.ItemsSource = Conversion.GetSpecializationType();

            //     specialization = (Specialization)Specialization.SelectedItem;
            appointments = ac.getAppointmentBySpecialization(specialization);

            PatientBox.ItemsSource = patients;

            TimeBox.ItemsSource = appointments;


        }



        private void Schedule_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void AddGuest_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new NewGuestPatientPage(0));
        }
    }
}
