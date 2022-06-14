using Model;
using SIMS.Core;
using SIMS.Repository;

namespace SIMS.SecretaryView.ViewModel
{
    public class ProfilePageViewModel : ViewModelBase
    {
        public static ProfilePageViewModel _instance;

        public SecretaryRepository sr = new SecretaryRepository();
        public Secretary secretary = new Secretary();

        private string ime { get; set; }
        private string prezime { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        private string jmbg { get; set; }

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
                return prezime;
            }
            set
            {
                if (value != prezime)
                {
                    prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value != username)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged("Password");
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
                    OnPropertyChanged("email");
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

        public static ProfilePageViewModel GetInstance()
        {
            return _instance;
        }

        public ProfilePageViewModel()
        {
            secretary = sr.FindById(1);
            ime = secretary.name;
            prezime = secretary.surname;
            username = secretary.username;
            password = secretary.password;
            email = secretary.email;
            jmbg = secretary.jmbg;
        }
    }
}
