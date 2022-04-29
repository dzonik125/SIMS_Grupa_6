using Controller;
using Model;
using SIMS.SecretaryView;
using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for NewPatient.xaml
    /// </summary>
    public partial class NewPatient : Window
    {
        public Patient patient = new Patient();
        public MedicalRecord mr;
        public Adress adress;
        private PatientController pc = new PatientController();
        private AdressController ac = new AdressController();
        private MedicalRecordController mrc = new MedicalRecordController();
        public NewPatient()
        {
            InitializeComponent();

        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            adress = new Adress();

            mr = new MedicalRecord();
            patient.name = Name.Text;
            patient.surname = Surname.Text;
            patient.lbo = Lbo.Text;
            patient.email = Email.Text;
            patient.birthdate = BirthDate.Text;
            patient.password = Password.Text;
            patient.username = Username.Text;
            patient.phone = PhoneNum.Text;
            patient.jmbg = Jmbg.Text;
            adress.number = StreetNum.Text;
            adress.street = Street.Text;
            adress.city = City.Text;
            adress.country = Country.Text;
            patient.address = adress;
            patient.address.id = "jiuj";
            patient.guest = false;
            mr = mrc.FindAll()[mrc.FindAll().Count - 1];
            patient.medicalRecord = mr;




            ac.AddAdress(adress);

            pc.AddPatient(patient);



            SecretaryUI sui = SecretaryUI.Instance;
            sui.refresh();
            this.Close();
        }

        private void CloseNew_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void medicalRecord_Click(object sender, RoutedEventArgs e)
        {
            MedicalRecordView mr = new MedicalRecordView();
            mr.Show();

        }
    }
}
