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
using System.Windows.Shapes;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.PatientView
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        public ObservableCollection<Prescription> prescriptions {get; set;}
        public PrescriptionController prescriptionController = new PrescriptionController();
        public MedicationController medicationController = new MedicationController();
        public Notifications()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Prescription> pres = prescriptionController.FindAll();
            prescriptions = new ObservableCollection<Prescription>();
            List<Medication> medications = medicationController.FindAll();
            prescriptionController.bindPrescriptionsWithMedications(pres, medications);
            foreach (Prescription p in pres)
            {
                prescriptions.Add(p);
            }

        }
    }
}
