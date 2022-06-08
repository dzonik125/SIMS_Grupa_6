using SIMS.Controller;
using SIMS.Filters;
using SIMS.Model;
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
    /// Interaction logic for Medications.xaml
    /// </summary>
    public partial class Medications : Page
    {
        public static Medications instance = new Medications();
        public ObservableCollection<Medication> medications { get; set; }
        public MedicationController mc = new MedicationController();
        public static Medications Instance
        {
            get
            {
                return instance;
            }
        }

        private Medications()
        {
            InitializeComponent();
            this.DataContext = this;
            medications = new ObservableCollection<Medication>();
            refresh();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Medication m = dataGridMedications.SelectedItem as Medication;
            if(m == null)
            {
                MessageBox.Show("Izaberite lek koji zelite da pogledate");
            }
            MedicationDetails medicationDetails = new MedicationDetails(m);
            medicationDetails.Show();
        }

        public void refresh()
        {
            medications.Clear();
            List<Medication> mList = mc.FindAll();
            
            foreach(Medication m in mList)
            {
                medications.Add(m);
            }



        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            String searchText = SearchBox.Text;

            if (searchText == "")
                SearchBox.Text = "Pretrazi...";

        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            MedicationsFilter filter = new MedicationsFilter();
            filter.SetKeywordsFromInput(SearchBox.Text);
            dataGridMedications.ItemsSource = filter.ApplyFilters(medications);
        }
    }
}
