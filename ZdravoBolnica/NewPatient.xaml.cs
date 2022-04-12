using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            String a = DateTime.Now.ToString("yyMMddHHmmssff");
            patient.adressID = a;
            string v = DateTime.Now.ToString("yyMMddHHmmssff");
            patient.id = v;

            adress.id = a;
            adress.number = StreetNum.Text;
            adress.street = Street.Text;
            adress.city = City.Text;
            adress.country = Country.Text;

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
    }
}
