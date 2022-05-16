using Controller;
using Model;
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
        public static DoctorWindow instance = new DoctorWindow();
        private DoctorController doctorController = new DoctorController();
        private MedicationController medicationController = new MedicationController();
        public Doctor doctorUser = new Doctor();

        public static DoctorWindow Instance
        {
            get
            {
               return instance;
            }
        }
      
            

        private DoctorWindow()
        {

            /*Medication med = new();
            med.name = "Brufen";
            Medication med1 = new();
            med1.name = "Bromazepam";
            medicationController.Create(med);
            medicationController.Create(med1);*/
            doctorUser = doctorController.GetAllDoctors()[0];
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Medications medications = Medications.Instance;
            Page.Content = medications;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VacationPeriodsView vacationPeriodsView = VacationPeriodsView.Instance;
            Page.Content = vacationPeriodsView;
        }
    }
}
