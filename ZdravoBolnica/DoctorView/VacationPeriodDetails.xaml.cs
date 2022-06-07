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
    /// Interaction logic for VacationPeriodDetails.xaml
    /// </summary>
    public partial class VacationPeriodDetails : Window
    {

        public VacationPeriod selectedVacationPeriod = new();

        public VacationPeriodDetails(VacationPeriod vacationPeriod)
        {
            selectedVacationPeriod = vacationPeriod;
            InitializeComponent();
            StartTime.Text = vacationPeriod.StartTime.ToString();
            EndTime.Text = vacationPeriod.EndTime.ToString();
            Comment.Text = vacationPeriod.comment;
            if (vacationPeriod.status == VacationPeriodStatus.VacationPeriodStatusType.accepted)
                Response.Text = "Odobreno";
            else if (vacationPeriod.status == VacationPeriodStatus.VacationPeriodStatusType.waiting)
                Response.Text = "Na cekanju";
            else
                Response.Text = vacationPeriod.rejectComment;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
