using SIMS.Model;
using SIMS.Service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{
    public partial class VacationPeriodPage : Page
    {
        public BindingList<VacationPeriod> list = new BindingList<VacationPeriod>();
        public List<VacationPeriod> vacationPeriods = new List<VacationPeriod>();
        public VacationPeriodService vacationPeriodSevice = new VacationPeriodService();
        public VacationPeriodPage()
        {
            InitializeComponent();
            vacationPeriodTable.ItemsSource = list;
            vacationPeriods = vacationPeriodSevice.FindAll();
            vacationPeriodSevice.bindDoctorsWithVacationPeriods(vacationPeriods);
            foreach (VacationPeriod v in vacationPeriods)
            {
                list.Add(v);
            }


        }

        private void Details_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VacationPeriod selectedVacationPeriod = vacationPeriodTable.SelectedItem as VacationPeriod;
            if (selectedVacationPeriod == null)
            {
                MessageBox.Show("Izabrati termin za prikaz!");
                return;
            }
            if (!Conversion.VacationPeriodStatusTypeToString(selectedVacationPeriod.status).Equals("Na cekanju"))
            {
                MessageBox.Show("Ne možete više izmeniti ovaj termin!");
                return;
            }
            else
            {
                VacationPeriodStatus vps = new VacationPeriodStatus(selectedVacationPeriod);
                vps.ShowDialog();
            }
        }
    }
}
