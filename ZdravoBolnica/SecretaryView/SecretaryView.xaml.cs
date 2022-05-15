using SIMS.Controller;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for SecretaryView.xaml
    /// </summary>
    public partial class SecretaryView : Window
    {
        private static SecretaryView instance = new SecretaryView();
        private SecretaryUI sui;
        private Timer timer;
        private OrderEquipmentController oec = new OrderEquipmentController();

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
            //SetContent(new SecretaryView());
            //  timer = new Timer(new TimerCallback(oec.CreateOrder), null, 1000, 60000);
        }

        //      private void addPatient_Click(object sender, RoutedEventArgs e)
        //     {
        //          SecretaryUI sui = SecretaryUI.Instance;
        //         sui.Show();
        //       this.Close();


        //     }

        //   private void scheduleAppointment_Click(object sender, RoutedEventArgs e)
        //     {
        //     CreateAppointment ca = new CreateAppointment();
        //       ca.Show();
        //       this.Close();

        //   }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            HomePage hp = HomePage.Instance;
            Page.Content = hp;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new RegistrationPatient());
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new CreateAppointmentPage());
        }

        private void OrderEquipment_Click(object sender, RoutedEventArgs e)
        {
            SetContent(new OrderEquipmentPage());
        }
    }
}
