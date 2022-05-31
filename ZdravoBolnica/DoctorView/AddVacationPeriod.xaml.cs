using SIMS.Controller;
using SIMS.Model;
using SIMS.Util;
using System;
using System.Windows;
using static SIMS.Model.VacationPeriodStatus;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for AddVacationPeriod.xaml
    /// </summary>
    public partial class AddVacationPeriod : Window
    {
        public VacationPeriodController vacationPeriodController = new VacationPeriodController();
        public AddVacationPeriod()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            if ((StartTime.SelectedDate == null) || (EndTime.SelectedDate == null) || Comment.Text.Equals(""))
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
            DateRange dateRange = new DateRange();
            dateRange.startTime = (DateTime)StartTime.SelectedDate;
            dateRange.endTime = (DateTime)EndTime.SelectedDate;
            TimeSpan ts = dateRange.endTime - dateRange.startTime;
            dateRange.duration = ts.TotalMinutes;

            if (dateRange.startTime < DateTime.Now.AddDays(2))
            {
                MessageBox.Show("Morate zakazati minimalno dva dana ranije!");
                return;
            }

            if (vacationPeriodController.checkIfDoctorHasAppoinmentsInPeriod(DoctorWindow.Instance.doctorUser, dateRange) && (bool)Urgent.IsChecked == false)
            {
                MessageBox.Show("Imate zakazane termine u ovom periodu!");
                return;
            }

            if (vacationPeriodController.checkIfDoctorIsAlreadyOnVacation(DoctorWindow.Instance.doctorUser, dateRange) && (bool)Urgent.IsChecked == false)
            {
                MessageBox.Show("Vec imate slobodne dane u ovom periodu!");
                return;
            }

            if (vacationPeriodController.checkForDoctorsOnVacation(DoctorWindow.Instance.doctorUser, dateRange) && (bool)Urgent.IsChecked == false)
            {
                MessageBox.Show("Vise od jednog doktora vase specijalizacije ima slobodne dane u ovom periodu!");
                return;
            }
            VacationPeriod vacationPeriod = new();
            vacationPeriod.comment = Comment.Text;
            vacationPeriod.rejectComment = "";
            vacationPeriod.doctor = DoctorWindow.Instance.doctorUser;
            vacationPeriod.StartTime = dateRange.startTime;
            vacationPeriod.EndTime = dateRange.endTime;
            vacationPeriod.status = VacationPeriodStatusType.waiting;
            if ((bool)Urgent.IsChecked)
            {
                vacationPeriod.type = VacationPeriodType.urgent;
            }
            else
                vacationPeriod.type = VacationPeriodType.regular;

            vacationPeriodController.Create(vacationPeriod);
            VacationPeriodsView.Instance.refresh();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
