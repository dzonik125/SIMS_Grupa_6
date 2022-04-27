using System.Windows;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for SecretaryView.xaml
    /// </summary>
    public partial class SecretaryView : Window
    {
        private static SecretaryView instance = new SecretaryView();
        private SecretaryUI sui;

        public static SecretaryView Instance
        {
            get
            {
                return instance;
            }
        }

        public SecretaryView()
        {
            InitializeComponent();
        }

        private void addPatient_Click(object sender, RoutedEventArgs e)
        {
            SecretaryUI sui = SecretaryUI.Instance;
            sui.Show();
            this.Close();


        }

        private void scheduleAppointment_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment ca = new CreateAppointment();
            ca.Show();
            this.Close();

        }
    }
}
