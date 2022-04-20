using Controller;
using Model;
using System;
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
        public NewGuestPatient()
        {
            InitializeComponent();
        }

        private void AddGuestPatient_Click(object sender, RoutedEventArgs e)
        {
            adress = new Adress();


            patient.name = Name.Text;
            patient.surname = Surname.Text;
            patient.lbo = "";
            patient.email = "";
            patient.birthdate = "";
            patient.password = "";
            patient.username = "";
            patient.phone = "";
            patient.jmbg = Jmbg.Text;
            String a = DateTime.Now.ToString("yyMMddHHmmssff");
            adress.number = "";
            adress.street = "";
            adress.city = "";
            adress.country = "";
            patient.address = adress;
            patient.address.id = a;
            //  patient.adressID = a;
            string v = DateTime.Now.ToString("yyMMddHHmmssff");
            patient.id = v;
            patient.guest = true;

            // adress.id = a;

            

            pc.AddPatient(patient);
            ac.AddAdress(adress);

            SecretaryUI sui = SecretaryUI.Instance;
            sui.refresh();
            this.Close();


        }
    }
}
