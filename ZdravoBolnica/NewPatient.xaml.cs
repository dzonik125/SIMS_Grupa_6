using Controller;
using Model;
using System;
using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for NewPatient.xaml
    /// </summary>
    public partial class NewPatient : Window
    {
        public Patient patient = new Patient();
        public Adress adress;
        private PatientController pc = new PatientController();
        private AdressController ac = new AdressController();
        public NewPatient()
        {
            InitializeComponent();

        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            adress = new Adress();
           
            
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

           // adress.id = a;

            

            pc.AddPatient(patient);
            ac.AddAdress(adress);

            SecretaryUI sui = SecretaryUI.Instance;
            sui.refresh();
            this.Close();
        }

        private void CloseNew_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BirthDate_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
