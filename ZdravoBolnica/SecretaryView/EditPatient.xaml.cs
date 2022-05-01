using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Windows;

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

        public MedicalRecord medicalRecord;
        public MedicalRecordController mrc = new MedicalRecordController();

        public BloodType bt;

        public List<Allergies> al = new List<Allergies>();
        public AllergiesController alc = new AllergiesController();
        public EditPatient(Patient p)
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



            if (p.gender.Equals(Gender.male))
            {
                MaleRadioButton.IsChecked = true;
            }
            else FemaleRadioButton.IsChecked = true;



            if (!p.guest)
            {
                List<Allergies> al = alc.FindAll();
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

                // mr.allergies.Add(al);

            }
            else
            {
                brojK.Text = 0.ToString();

            }





            // InitAllergie();
        }




        /*     private void InitAllergie()
            {
                medicalRecord = new MedicalRecord();
                int index = 0;
                al = alc.FindAll();
                AllergsBox.ItemsSource = al;
                foreach (Allergies a in al)
                {
                    if (a.id.Equals(medicalRecord.All))
                    {
                        break;
                    }
                    index++;
                }
                AllergsBox.SelectedIndex = index;
            }*/



        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            Adress a = ac.FindAdressById(selectedPatient.address.id);
            a.country = Country.Text;
            a.city = City.Text;
            a.number = StreetNum.Text;
            a.street = Street.Text;

            MedicalRecord mr = mrc.FindMedicalRecordById(selectedPatient.medicalRecord.id);
            mr.cardNum = Int32.Parse(brojK.Text);

            mr.bloodType = Conversion.StringToBloodType(bloodType.Text);


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
            mrc.UpdateMedicalRecord(mr);


            selectedPatient.address = ac.FindAdressById(selectedPatient.address.id);



            pc.UpdatePatient(selectedPatient);
            SecretaryUI sui = SecretaryUI.Instance;
            sui.refresh();
            this.Close();

        }

        private void CloseEdit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
