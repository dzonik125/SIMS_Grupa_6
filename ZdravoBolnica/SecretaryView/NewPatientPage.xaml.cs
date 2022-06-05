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
    /// Interaction logic for NewPatientPage.xaml
    /// </summary>
    public partial class NewPatientPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string ime;
        private string preime;
        private string jmbg;
        private string ulica;
        private string broj;
        private string grad;
        private string drzava;
        private string email;
        private string kontakt;
        private string korisnickoIme;
        private string lozinka;
        private string brojKartona;
        private string lbo;
        private string datum;

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        public string Prezime
        {
            get
            {
                return preime;
            }
            set
            {
                if (value != preime)
                {
                    preime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }
        public string Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }
        public string Grad
        {
            get
            {
                return grad;
            }
            set
            {
                if (value != grad)
                {
                    grad = value;
                    OnPropertyChanged("Grad");
                }
            }
        }
        public string Drzava
        {
            get
            {
                return drzava;
            }
            set
            {
                if (value != drzava)
                {
                    drzava = value;
                    OnPropertyChanged("Drzava");
                }
            }
        }
        public string Ulica
        {
            get
            {
                return ulica;
            }
            set
            {
                if (value != ulica)
                {
                    ulica = value;
                    OnPropertyChanged("Ulica");
                }
            }
        }
        public string Broj
        {
            get
            {
                return broj;
            }
            set
            {
                if (value != broj)
                {
                    broj = value;
                    OnPropertyChanged("Broj");
                }
            }
        }

        public string BrojKartona
        {
            get
            {
                return brojKartona;
            }
            set
            {
                if (value != brojKartona)
                {
                    brojKartona = value;
                    OnPropertyChanged("BrojKartona");
                }
            }
        }

        public string Lbo
        {
            get
            {
                return lbo;
            }
            set
            {
                if (value != lbo)
                {
                    lbo = value;
                    OnPropertyChanged("Lbo");
                }
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Kontakt
        {
            get
            {
                return kontakt;
            }
            set
            {
                if (value != kontakt)
                {
                    kontakt = value;
                    OnPropertyChanged("Kontakt");
                }
            }
        }
        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }
            set
            {
                if (value != korisnickoIme)
                {
                    korisnickoIme = value;
                    OnPropertyChanged("KorisnickoIme");
                }
            }
        }

        public string Datum
        {
            get
            {
                return datum;
            }
            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }


        public string Lozinka
        {
            get
            {
                return lozinka;
            }
            set
            {
                if (value != lozinka)
                {
                    lozinka = value;
                    OnPropertyChanged("Lozinka");
                }
            }
        }











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

            DataContext = this;
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            adress = new Adress();
            mr = new MedicalRecord();
            pr = new Prescription();

            patient.name = textBoxIme.Text;
            patient.surname = textBoxPrezime.Text;
            patient.lbo = textBoxLbo.Text;
            patient.email = textBoxEmail.Text;
            patient.birthdate = textBoxDatumRodjenja.Text;
            patient.password = textBoxSifra.Text;
            patient.username = textBoxKorisnickoIme.Text;
            patient.phone = textBoxBrojTelefona.Text;
            patient.jmbg = textBoxJmbg.Text;

            if ((bool)MaleRadioButton.IsChecked)
            {
                patient.gender = Gender.male;
            }
            else patient.gender = Gender.female;

            adress.number = textBoxBroj.Text;
            adress.street = textBoxUlica.Text;
            adress.city = textBoxGrad.Text;
            adress.country = textBoxDrzava.Text;

            if (textBoxBrojK.Text.Equals(""))
            {
                MessageBox.Show("Unesite broj kartona");
            }
            else
            {
                mr.cardNum = textBoxBrojK.Text;
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
            }
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

    }
}
