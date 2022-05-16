using Model;
using Service;
using SIMS.Model;
using SIMS.Util;
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
    /// Interaction logic for Referral.xaml
    /// </summary>
    public partial class Referral : Window
    {
        public Patient selectedPatient = new Patient();
        public AppointmentService aps = new AppointmentService();
        public Referral(Patient p)
        {  
            InitializeComponent();
            selectedPatient = p;
            SpecializationBox.ItemsSource = Conversion.GetSpecializationType();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EndTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateRange dateRange = new();
            dateRange.startTime = (DateTime)StartTime.SelectedDate;
            dateRange.endTime = (DateTime)EndTime.SelectedDate;
            List<Appointment> appo = aps.findFreeTermsForReferral(Specialization.general, dateRange, selectedPatient);
            Time.ItemsSource = appo;
        }
    }
}
