using SIMS.Controller;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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


        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            if (CurrentTheme.Equals("Dark"))
            {
                app.ChangeTheme(new Uri("/Light.xaml", UriKind.Relative));
                CurrentTheme = "Light";
            }
            else
            {
                app.ChangeTheme(new Uri("/Dark.xaml", UriKind.Relative));
                CurrentTheme = "Dark";
            }
        }

        public static SecretaryView Instance
        {
            get
            {
                return instance;
            }
        }


        public void SetContent(Page page)
        {
            Page.Content = page;
        }

        public SecretaryView()
        {
            InitializeComponent();
            SetContent(new CreateAppointmentPage());
            //   CurrentTitle = TranslationSource.Instance["Clinic"];
            CurrentLanguage = "en-US";
            CurrentTheme = "Light";
            this.DataContext = this;
        }



        private void Register_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new RegistrationPage());
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



        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new ProfilePage());
        }
    }
}
