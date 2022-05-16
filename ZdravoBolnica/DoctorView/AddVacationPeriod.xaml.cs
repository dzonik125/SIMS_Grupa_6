using SIMS.Model;
using SIMS.Service;
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
    /// Interaction logic for AddVacationPeriod.xaml
    /// </summary>
    public partial class AddVacationPeriod : Window
    {
        public VacationPeriodService vacationPeriodService = new VacationPeriodService();
        public AddVacationPeriod()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
          
            if((StartTime.SelectedDate == null) || (EndTime.SelectedDate == null) || Comment.Text.Equals(""))
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
            DateRange dateRange = new DateRange();
            dateRange.startTime = (DateTime)StartTime.SelectedDate;
            dateRange.endTime = (DateTime)EndTime.SelectedDate;
            TimeSpan ts = dateRange.endTime - dateRange.startTime;
            dateRange.duration = ts.TotalMinutes;
            
            if (vacationPeriodService.checkIfDoctorHasAppoinmentsInPeriod(DoctorWindow.Instance.doctorUser, dateRange))
            {
                MessageBox.Show("Imate zakazane termine u ovom periodu!");
            }

            

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
