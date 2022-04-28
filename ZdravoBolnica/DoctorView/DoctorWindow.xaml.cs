using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments appointments = Appointments.Instance;
            Page.Content = appointments;
        }

        private void Patients_Click(object sender, RoutedEventArgs e)
        {
            PatientsView pw = PatientsView.Instance;
            Page.Content = pw;

        }
    }
}
