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
    /// Interaction logic for PrescriptionDetails.xaml
    /// </summary>
    public partial class PrescriptionDetails : Window
    {
        public Prescription selectedPrescription;
        public PrescriptionDetails(Prescription p)
        {
            InitializeComponent();
            selectedPrescription = p;
            Medicatoin.Text = p.medication.name;
            StartTime.Text = p.startTime.ToString();
            EndTime.Text = p.endTime.ToString();
            Comment.Text = p.comment;
            Frequency.Text = p.timesPerDay.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
