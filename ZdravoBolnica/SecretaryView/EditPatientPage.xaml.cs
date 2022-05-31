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
    /// Interaction logic for EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page
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
        public EditPatientPage(Patient p)
        {
            selectedPatient = p;
            InitializeComponent();

            Name.Text = p.name;
            Surname.Text = p.surname;
            PhoneNum.Text = p.phone;
            Email.Text = p.email;
            Username.Text = p.username;
            Adress a = ac.FindAdressById(p.address.id);
            Country.Text = a.country;
            City.Text = a.city;
            StreetNum.Text = a.number;
            Street.Text = a.street;
            Password.Text = p.password;
            Lbo.Text = p.lbo;
            Jmbg.Text = p.jmbg;
            BirthDate.Text = p.birthdate;

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
                brojK.Text = mr.cardNum.ToString();

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
                brojK.Text = 0.ToString();
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
            a.country = Country.Text;
            a.city = City.Text;
            a.number = StreetNum.Text;
            a.street = Street.Text;

            MedicalRecord mr = mrc.FindMedicalRecordById(selectedPatient.medicalRecord.id);
            MedicalRecord mrr = new MedicalRecord();
            if (selectedPatient.guest)
            {

                mrr.cardNum = Int32.Parse(brojK.Text);
                mrr.bloodType = Conversion.StringToBloodType(bloodType.Text);

                mrr.medications = medications.ToList<Medication>();
                // mrr.allergies = al.ToList<Allergies>();

                mrc.AddMedicalRecord(mrr);

                selectedPatient.guest = false;

                selectedPatient.medicalRecord = mrr;
            }
            else
            {

                mr.cardNum = Int32.Parse(brojK.Text);

                mr.bloodType = Conversion.StringToBloodType(bloodType.Text);
                // mr.allergies = al.ToList<Allergies>();
                mr.medications = medications.ToList<Medication>();
            }

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

            SecretaryView.Instance.SetContent(new RegistrationPatient());

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new RegistrationPatient());
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
