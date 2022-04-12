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
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        public Patient selectedPatient;
        public PatientController pc = new PatientController();
        public AdressController ac = new AdressController();
        public Adress adress;
        public EditPatient(Patient p)
        {
            selectedPatient = p;
            InitializeComponent();
            Name.Text = p.name;
            Surname.Text = p.surname;
            PhoneNum.Text = p.phone;
            Email.Text = p.email;
            Username.Text = p.username;
            Adress a = ac.FindAdressById(p.adressID);
            Country.Text = a.country;
            City.Text = a.city;
            StreetNum.Text = a.number;
            Street.Text = a.street;
            Password.Text = p.password;
            Lbo.Text = p.lbo;
            Jmbg.Text = p.jmbg;
            BirthDate.Text = p.birthdate;
            
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            Adress a = ac.FindAdressById(selectedPatient.adressID);
            a.country = Country.Text;
            a.city = City.Text;
            a.number = StreetNum.Text;
            a.street = Street.Text;
            selectedPatient.name = Name.Text;
            System.Diagnostics.Trace.WriteLine(selectedPatient.name);
            selectedPatient.surname = Surname.Text;
            selectedPatient.lbo = Lbo.Text;
            selectedPatient.email = Email.Text;
            selectedPatient.birthdate = BirthDate.Text;
            selectedPatient.password = Password.Text;
            selectedPatient.username = Username.Text;
            selectedPatient.phone = PhoneNum.Text;
            selectedPatient.jmbg = Jmbg.Text;
            ac.UpdateAdress(a);

            selectedPatient.address = ac.FindAdressById(selectedPatient.adressID);

           

            pc.UpdatePatient(selectedPatient);
            SecretaryUI sui = SecretaryUI.Instance;
            sui.refresh();
            this.Close();

        }

        private void CloseEditPatient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
