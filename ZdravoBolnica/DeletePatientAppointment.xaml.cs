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
using Controller;
using Model;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for DeletePatientAppointment.xaml
    /// </summary>
    public partial class DeletePatientAppointment : Window
    {
        private AppointmentController ac = new AppointmentController();
        private string id;

        public DeletePatientAppointment(Appointment a)
        {
            InitializeComponent();
            id = a.id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ac.DeleteAppointmentById(id);
            PatientWindow.Instance.refresh();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
