
using SIMS.DoctorView;
using System.Windows;

namespace SIMS
{

    public partial class MainWindow : Window
    {

        public ManagerUI mui;
        public SecretaryUI sui;
        // public SecretaryView sv;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pWin = PatientWindow.Instance;
            pWin.Show();
            this.Hide();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoctorWindow dw = DoctorWindow.Instance;
            dw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ManagerUI mui = ManagerUI.Instance;
            mui.Show();
            this.Hide();
        }
        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            SIMS.SecretaryView.SecretaryView sv = SIMS.SecretaryView.SecretaryView.Instance;
            sv.Show();
            this.Hide();

        }
    }
}
