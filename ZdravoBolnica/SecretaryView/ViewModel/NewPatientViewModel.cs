using Model;
using SIMS.Core;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.SecretaryView.ViewModel
{
    public class NewPatientViewModel : ViewModelBase
    {
        public event EventHandler OnRequestClose;
        public RelayCommand FinishCommand { get; set; }

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
        private Gender gender;


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


        public Gender Pol
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != gender)
                {
                    gender = value;
                    OnPropertyChanged("Pol");
                }
            }
        }

        private List<string> BloodTypes { get; set; }
        private string selectedType;

        public string SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


        public NewPatientViewModel()
        {
            BloodTypes = Conversion.GetBloodType();
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
        }

        public bool CanExecute()
        {
            if (String.IsNullOrEmpty(selectedType))
            {
                return false;
            }

            return true;
        }

        public void Execute()
        {
            // Adress adress = new Adress();
            // MedicalRecord medicalRecord = new MedicalRecord();
            Patient patient = new Patient()
            {
                name = Ime,
                surname = Prezime,
                lbo = Lbo,
                email = Email,
                birthdate = Datum,
                password = Lozinka,
                username = KorisnickoIme,
                phone = Kontakt,
                jmbg = Jmbg,
                gender = Pol,

                // roomNum = Int32.Parse(RoomNum),
                //  floor = Int32.Parse(Floor),
                //  roomType = Conversion.StringToRoomType(SelectedType),
                //  empty = true
            };
            Adress adress = new Adress()
            {
                number = Broj,
                street = Ulica,
                city = Grad,
                country = Drzava
            };
            MedicalRecord medicalRecord = new MedicalRecord()
            {
                cardNum = BrojKartona,
                bloodType = Conversion.StringToBloodType(SelectedType),
                //  medications =
            };
            //  rc.AddRoom(room);
            //  ManagerUI mui = ManagerUI.Instance;
            //  mui.refresh();
            OnRequestClose?.Invoke(this, EventArgs.Empty);

        }


    }
}
