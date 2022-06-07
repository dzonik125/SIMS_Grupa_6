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

        private void Registration_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new RegistrationPatient());
        }

        private void schedule_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new CreateAppointmentPage());
        }

        private void order_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new OrderEquipmentPage());
        }
    }
}
