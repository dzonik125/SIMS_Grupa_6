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
using System.Windows.Threading;

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
        public  SolidColorBrush sellectedTab = new SolidColorBrush(Color.FromRgb(190,230, 253));
        SolidColorBrush general = new SolidColorBrush(Color.FromRgb(0, 121, 107));
        public static DoctorWindow Instance
        {
            get
            {
               return instance;
            }
        }
      
            

        private DoctorWindow()
        {


            
            InitializeComponent();
            this.DataContext = this;
            SetStatusBarClock();
        
        }

        private void resetButtons()
        {
            Terms.Background = general;
            Patients.Background = general;
            Drugs.Background = general;
            History.Background = general;
            Profil.Background = general;
            DaysOff.Background = general;
        }

        private void SetStatusBarClock()
        {
            //Tred za prikazivanje sata i datuma
            this.dateAndTime.Content = DateTime.Now.ToString("HH:mm │ dd.MM.yyyy.");

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateAndTime.Content = DateTime.Now.ToString("HH:mm │ dd.MM.yyyy.");
            }, this.Dispatcher);
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments appointments = Appointments.Instance;
            Page.Content = appointments;
            resetButtons();
            Terms.Background = sellectedTab;
        }

        private void Patients_Click(object sender, RoutedEventArgs e)
        {
            PatientsView pw = PatientsView.Instance;
            Page.Content = pw;
            resetButtons();
            Patients.Background = sellectedTab;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Medications medications = Medications.Instance;
            Page.Content = medications;
            resetButtons();
            Drugs.Background = sellectedTab;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VacationPeriodsView vacationPeriodsView = VacationPeriodsView.Instance;
            Page.Content = vacationPeriodsView;
            resetButtons();
            DaysOff.Background = sellectedTab;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TermHistory appointmentHistory = new TermHistory();
            Page.Content = appointmentHistory;
            resetButtons();
            History.Background = sellectedTab;
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            Page.Content = profile;
            resetButtons();
            Profil.Background = sellectedTab;
        }
    }
}
