using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for NewPatientPage.xaml
    /// </summary>
    public partial class NewPatientPage : Page, INotifyPropertyChanged
    {
        public Patient patient = new Patient();
        public MedicalRecord mr;
        public Adress adress;
        public BloodType bloodT;
        public MedicalRecord medicalRecord = new MedicalRecord();
        public Gender gender;
        public Prescription pr;

        private PatientController pc = new PatientController();
        private AdressController ac = new AdressController();
        private MedicalRecordController mrc = new MedicalRecordController();
        public AllergiesController alc = new AllergiesController();
        public PrescriptionController prc = new PrescriptionController();
        public MedicationController mc = new MedicationController();

        public List<Prescription> prescriptions = new List<Prescription>();


        public BindingList<Allergies> al = new BindingList<Allergies>();
        public List<Allergies> allergs = new List<Allergies>();

        public BindingList<Medication> medications = new BindingList<Medication>();
        public List<Medication> meds = new List<Medication>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public NewPatientPage()
        {
            InitializeComponent();

            // allergenTable.ItemsSource = al;
            medAllergs_table.ItemsSource = medications;


            bloodType.ItemsSource = Conversion.GetBloodType();

            allergs = alc.FindAll();
            meds = mc.FindAll();

            // AllergsBox.ItemsSource = allergs;
            MedAllergsBox.ItemsSource = meds;
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            adress = new Adress();
            mr = new MedicalRecord();
            pr = new Prescription();

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

            mr.medications = medications.ToList<Medication>();


            //  mr.allergies = al.ToList<Allergies>();

            mrc.AddMedicalRecord(mr);

            patient.address = adress;
            patient.guest = false;

            mr = mrc.FindAll()[mrc.FindAll().Count - 1];
            patient.medicalRecord = mr;

            ac.AddAdress(adress);
            pc.AddPatient(patient);

            SecretaryView.Instance.SetContent(new RegistrationPatient());

            RegistrationPatient rgi = new RegistrationPatient();
            SecretaryView.Instance.SetContent(new RegistrationPatient());
            //SecretaryUI sui = SecretaryUI.Instance;
            // sui.refresh();
            //this.Close();
        }

        private void CloseNew_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new RegistrationPatient());
        }

        private void addAllergen_Click(object sender, RoutedEventArgs e)
        {
            //  al.Add((Allergies)AllergsBox.SelectedItem);

        }

        private void removeAllergen_Click(object sender, RoutedEventArgs e)
        {
            // al.Remove((Allergies)allergenTable.SelectedItem);
        }

        private void addMedicine_Click(object sender, RoutedEventArgs e)
        {
            medications.Add((Medication)MedAllergsBox.SelectedItem);
        }

        private void removeMedicine_Click(object sender, RoutedEventArgs e)
        {
            medications.Remove((Medication)medAllergs_table.SelectedItem);
        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }
    }
}
