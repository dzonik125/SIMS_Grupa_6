using SIMS.Controller;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using static SIMS.TranslationSoruce;

namespace SIMS.SecretaryView
{
    public partial class SecretaryView : Window, INotifyPropertyChanged
    {
        private static SecretaryView instance = new SecretaryView();
        private OrderEquipmentController oec = new OrderEquipmentController();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string CurrentLanguage { get; set; }
        private string CurrentTheme { get; set; }
        private string currentTitle;

        public string CurrentTitle
        {
            get
            {
                return currentTitle;
            }
            set
            {
                if (value != currentTitle)
                {
                    currentTitle = value;
                    OnPropertyChanged("CurrentTitle");
                }
            }
        }


        public static SecretaryView Instance
        {
            get
            {
                return instance;
            }
        }

        // public void SetLabel(string label)
        //  {
        //     MainLabel.Content = label;
        // }
        public void SetContent(Page page)
        {
            Page.Content = page;
        }

        public SecretaryView()
        {
            InitializeComponent();
            SetContent(new CreateAppointmentPage());
            CurrentTitle = TranslationSource.Instance["Clinic"];
            CurrentLanguage = "en-US";
            CurrentTheme = "Light";
        }


        /* private void HomePage_Click(object sender, RoutedEventArgs e)
         {
             HomePage hp = HomePage.Instance;
             Page.Content = hp;
         }*/

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new RegistrationPatient());
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new CreateAppointmentPage());
        }

        private void OrderEquipment_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new OrderEquipmentPage());
        }

        private void VacationPeriod_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new VacationPeriodPage());
        }

        private void Meeting_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new MeetingPage());
        }

        private void Language_Click(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            if (CurrentLanguage.Equals("en-US"))
            {
                CurrentLanguage = "sr-LATN";
            }
            else
            {
                CurrentLanguage = "en-US";
            }
            app.ChangeLanguage(CurrentLanguage);
        }
    }
}
