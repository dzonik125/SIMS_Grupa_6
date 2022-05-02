using Controller;
using Model;
using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for NewGuestPatient.xaml
    /// </summary>
    public partial class NewGuestPatient : Window
    {
        public PatientController pc = new PatientController();
        public Patient patient = new Patient();
        public AdressController ac = new AdressController();
        public Adress adress;
        public MedicalRecordController mrc = new MedicalRecordController();
        public MedicalRecord mr;
        public NewGuestPatient()
        {
            InitializeComponent();
        }

        private void AddGuestPatient_Click(object sender, RoutedEventArgs e)
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


            //      mr.id = 0;
            //          patient.medicalRecord = mr;

            ac.AddAdress(adress);
            pc.AddPatient(patient);


            SecretaryUI sui = SecretaryUI.Instance;
            sui.refresh();
            this.Close();


        }
    }
}
