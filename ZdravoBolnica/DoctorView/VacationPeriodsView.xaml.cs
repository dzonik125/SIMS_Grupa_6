using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.DoctorView
{
    /// <summary>
    /// Interaction logic for VacationPeriodsView.xaml
    /// </summary>
    public partial class VacationPeriodsView : Page
    {
        public static VacationPeriodsView instance = new VacationPeriodsView();
        public ObservableCollection<VacationPeriod> vacationPeriods { get; set; }
        public VacationPeriodService vacationPeriodSevice = new VacationPeriodService();

        public static VacationPeriodsView Instance
        {
            get
            {
                return instance;
            }
        }

        private VacationPeriodsView()
        {
            InitializeComponent();
            this.DataContext = this;
            vacationPeriods = new ObservableCollection<VacationPeriod>();
            refresh();
        }


        public void refresh()
        {
            vacationPeriods.Clear();
            List<VacationPeriod> periods = vacationPeriodSevice.findAllByDoctorId(DoctorWindow.Instance.doctorUser.id);
            foreach(VacationPeriod v in periods)
            {
                vacationPeriods.Add(v);
            }


        }


        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            AddVacationPeriod adv = new AddVacationPeriod();
            adv.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            VacationPeriod vacationPeriod = dataGridAppointments.SelectedItem as VacationPeriod;
            VacationPeriodDetails vacationPeriodDetails = new VacationPeriodDetails(vacationPeriod);
            vacationPeriodDetails.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
