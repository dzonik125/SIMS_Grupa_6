using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public BloodType bloodT;
        public MedicalRecord medicalRecord = new MedicalRecord();
        public Gender gender;

        private PatientController pc = new PatientController();
        private AdressController ac = new AdressController();
        private MedicalRecordController mrc = new MedicalRecordController();
        public AllergiesController alc = new AllergiesController();

        public List<Allergies> allergs = new List<Allergies>();
        public BindingList<Allergies> al = new BindingList<Allergies>();



        public NewPatient()
        {
            InitializeComponent();

            allergenTable.ItemsSource = al;

            bloodType.ItemsSource = Conversion.GetBloodType();

            allergs = alc.FindAll();
            AllergsBox.ItemsSource = allergs;

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

            if ((bool)MaleRadioButton.IsChecked)
            {
                patient.gender = Gender.male;
            }
            else patient.gender = Gender.female;

            adress.number = StreetNum.Text;
            adress.street = Street.Text;
            adress.city = City.Text;
            adress.country = Country.Text;


            mr.cardNum = Int32.Parse(brojK.Text);
            mr.bloodType = Conversion.StringToBloodType(bloodType.Text);

            mr.allergies = al.ToList<Allergies>();
            mrc.AddMedicalRecord(mr);

            patient.address = adress;

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

        private void addAllergen_Click(object sender, RoutedEventArgs e)
        {
            al.Add((Allergies)AllergsBox.SelectedItem);

        }

        private void removeAllergen_Click(object sender, RoutedEventArgs e)
        {
            al.Remove((Allergies)allergenTable.SelectedItem);

        }

    }
}
