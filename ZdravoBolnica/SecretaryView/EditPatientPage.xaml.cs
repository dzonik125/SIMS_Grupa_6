using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page, INotifyPropertyChanged
    {

        public Patient selectedPatient;
        public PatientController pc = new PatientController();
        public AdressController ac = new AdressController();
        public Adress adress;

        public MedicalRecord medicalRecord;
        public MedicalRecordController mrc = new MedicalRecordController();

        public BloodType bt;

        public BindingList<Allergies> al = new BindingList<Allergies>();
        public AllergiesController alc = new AllergiesController();

        public BindingList<Medication> medications = new BindingList<Medication>();
        public MedicationController medsc = new MedicationController();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public EditPatientPage(Patient p)
        {
            selectedPatient = p;
            InitializeComponent();
            textBoxIme.Text = p.name;
            textBoxPrezime.Text = p.surname;
            textBoxBrojTelefona.Text = p.phone;
            textBoxEmail.Text = p.email;
            textBoxKorisnickoIme.Text = p.username;
            Adress a = ac.FindAdressById(p.address.id);
            textBoxDrzava.Text = a.country;
            textBoxGrad.Text = a.city;
            textBoxBroj.Text = a.number;
            textBoxUlica.Text = a.street;
            textBoxSifra.Text = p.password;
            textBoxLbo.Text = p.lbo;
            textBoxJmbg.Text = p.jmbg;
            textBoxDatumRodjenja.Text = p.birthdate;

            bloodType.ItemsSource = Conversion.GetBloodType();

            if (p.gender.Equals(Gender.male))
            {
                MaleRadioButton.IsChecked = true;
            }
            else FemaleRadioButton.IsChecked = true;

            List<Allergies> allergs = alc.FindAll();
            List<Medication> meds = medsc.FindAll();

            if (!p.guest)
            {

                MedicalRecord mr = mrc.FindMedicalRecordById(p.medicalRecord.id);
                textBoxBrojK.Text = mr.cardNum.ToString();

                bloodType.ItemsSource = Conversion.GetBloodType();

                if (mr.bloodType.ToString().Equals("ONegative"))
                {
                    bloodType.SelectedIndex = 0;
                }
                else if (mr.bloodType.ToString().Equals("APositive"))
                {
                    bloodType.SelectedIndex = 1;
                }
                else if (mr.bloodType.ToString().Equals("ANegative"))
                {
                    bloodType.SelectedIndex = 2;
                }
                else if (mr.bloodType.ToString().Equals("BPositive"))
                {
                    bloodType.SelectedIndex = 3;
                }
                else if (mr.bloodType.ToString().Equals("BNegative"))
                {
                    bloodType.SelectedIndex = 4;
                }
                else if (mr.bloodType.ToString().Equals("ABPositive"))
                {
                    bloodType.SelectedIndex = 5;
                }
                else if (mr.bloodType.ToString().Equals("ABNegative"))
                {
                    bloodType.SelectedIndex = 6;
                }
                else
                {
                    bloodType.SelectedIndex = 7;
                }

                // foreach (Allergies all in mr.allergies)
                // {
                //      al.Add(all);
                //   }

                foreach (Medication med in mr.medications)
                {
                    medications.Add(med);
                }

            }
            else
            {
                textBoxBrojK.Text = 0.ToString();
                MaleRadioButton.IsChecked = false;
                FemaleRadioButton.IsChecked = false;



            }
            //AllergsBox.ItemsSource = allergs;
            //   allergenTable.ItemsSource = al;

            MedAllergsBox.ItemsSource = meds;
            medAllergs_table.ItemsSource = medications;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Adress a = ac.FindAdressById(selectedPatient.address.id);
            a.country = textBoxDrzava.Text;
            a.city = textBoxGrad.Text;
            a.number = textBoxBroj.Text;
            a.street = textBoxUlica.Text;

            MedicalRecord mr = mrc.FindMedicalRecordById(selectedPatient.medicalRecord.id);
            MedicalRecord mrr = new MedicalRecord();
            if (selectedPatient.guest)
            {

                mrr.cardNum = textBoxBrojK.Text;
                mrr.bloodType = Conversion.StringToBloodType(bloodType.Text);

                mrr.medications = medications.ToList<Medication>();
                // mrr.allergies = al.ToList<Allergies>();

                mrc.AddMedicalRecord(mrr);

                selectedPatient.guest = false;

                selectedPatient.medicalRecord = mrr;
            }
            else
            {

                mr.cardNum = textBoxBrojK.Text;

                mr.bloodType = Conversion.StringToBloodType(bloodType.Text);
                // mr.allergies = al.ToList<Allergies>();
                mr.medications = medications.ToList<Medication>();
            }

            selectedPatient.name = textBoxIme.Text;
            System.Diagnostics.Trace.WriteLine(selectedPatient.name);
            selectedPatient.surname = textBoxPrezime.Text;
            selectedPatient.lbo = textBoxLbo.Text;
            selectedPatient.email = textBoxEmail.Text;
            selectedPatient.birthdate = textBoxDatumRodjenja.Text;
            selectedPatient.password = textBoxSifra.Text;
            selectedPatient.username = textBoxKorisnickoIme.Text;
            selectedPatient.phone = textBoxBrojTelefona.Text;
            selectedPatient.jmbg = textBoxJmbg.Text;

            if ((bool)MaleRadioButton.IsChecked)
            {
                selectedPatient.gender = Gender.male;
            }
            else selectedPatient.gender = Gender.female;


            ac.UpdateAdress(a);
            if (mr == null)
            {
                mrc.UpdateMedicalRecord(mrr);
            }
            else mrc.UpdateMedicalRecord(mr);

            selectedPatient.address = ac.FindAdressById(selectedPatient.address.id);
            selectedPatient.medicalRecord = mrc.FindMedicalRecordById(selectedPatient.medicalRecord.id);


            pc.UpdatePatient(selectedPatient);
            // SecretaryUI sui = SecretaryUI.Instance;
            // sui.refresh();

            SecretaryView.Instance.SetContent(new RegistrationPage());

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new RegistrationPage());
        }

        private void addMedicine_Click(object sender, RoutedEventArgs e)
        {
            medications.Add((Medication)MedAllergsBox.SelectedItem);
        }

        private void removeMedicine_Click(object sender, RoutedEventArgs e)
        {
            medications.Remove((Medication)medAllergs_table.SelectedItem);
        }


    }
}
