using SIMS.Controller;
using SIMS.Model;
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

        //MedicationController medicationController = new();
        public DoctorWindow()
        {

           /* Medication med = new();
            med.name = "Brufen";
            Medication med1 = new();
            med1.name = "Bromazepam";
            medicationController.Create(med);
            medicationController.Create(med1);*/
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
