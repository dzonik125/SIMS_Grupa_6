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
    /// Interaction logic for PastAppointments.xaml
    /// </summary>
    public partial class PastAppointments : Window
    {
        public PastAppointments()
        {
            InitializeComponent();
            MainProblems.Text = "Glavobolja";
            Diagnosis.Text = "Anemija";
            Anamnesis.Text = "E pluribus unum";
            Therapy.Text = "Brufen 3x1 100mg";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
