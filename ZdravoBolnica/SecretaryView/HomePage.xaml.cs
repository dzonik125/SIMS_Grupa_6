using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    /// 

    public partial class HomePage : Page
    {
        public static HomePage instance = new HomePage();
        RegistrationPatient rui;
        public static HomePage Instance
        {
            get
            {
                return instance;
            }
        }
        public HomePage()
        {
            InitializeComponent();
        }


        private void addPatient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RegistrationPatient rui = RegistrationPatient.Instance;
            //Page.Content = rui;
            //this.Close();

        }

        private void scheduleAppointment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateAppointment ca = new CreateAppointment();
            ca.Show();
            //this.Close();
        }
    }
}
