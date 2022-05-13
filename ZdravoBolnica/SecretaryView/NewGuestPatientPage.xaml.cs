using Controller;
using Model;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for NewGuestPatientPage.xaml
    /// </summary>
    public partial class NewGuestPatientPage : Page
    {

        public PatientController pc = new PatientController();
        public Patient patient = new Patient();
        public AdressController ac = new AdressController();
        public Adress adress;
        public MedicalRecordController mrc = new MedicalRecordController();
        public MedicalRecord mr;
        public int lastPage;
        public NewGuestPatientPage(int p)
        {
            InitializeComponent();
            lastPage = p;
        }

        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            adress = new Adress();
            mr = new MedicalRecord();


            patient.name = Name.Text;
            patient.surname = Surname.Text;
            patient.lbo = "";
            patient.email = "";
            patient.birthdate = "";
            patient.password = "";
            patient.username = "";
            patient.phone = "";
            patient.jmbg = Jmbg.Text;


            adress.number = "";
            adress.street = "";
            adress.city = "";
            adress.country = "";
            patient.address = adress;
            patient.guest = true;

            ac.AddAdress(adress);
            pc.AddPatient(patient);

            if (lastPage == 1)
            {
                RegistrationPatient rgi = new RegistrationPatient();
                SecretaryView.Instance.SetContent(new RegistrationPatient());
            }
            else
            {
                AddEmergencyExaminationPage aeep = new AddEmergencyExaminationPage(Model.AppointmentType.examination);
                SecretaryView.Instance.SetContent(new AddEmergencyExaminationPage(Model.AppointmentType.examination));
            }


        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
