using Model;
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
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : Page
    {

        public static PatientsView instance = new PatientsView();
        public ObservableCollection<Patient> patients { get; set; }
        public PatientController pc = new PatientController();

        private PatientsView()
        {
            InitializeComponent();
            this.DataContext = this;
            patients = new ObservableCollection<Patient>();
            Refresh();
        }

        public static PatientsView Instance
        {
            get
            {
                return instance;
            }
        }

        public void Refresh()
        {
            List<Patient> patientList = new();
            patientList = pc.FindAllPatients();
            foreach(Patient p in patientList)
            {
                patients.Add(p);
            }
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            PatientMedicalRecord pmr = PatientMedicalRecord.Instance;
            pmr.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecordExamination re = new RecordExamination();
            re.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RecordSurgery rs = new RecordSurgery();
            rs.ShowDialog();
        }
    }
}
