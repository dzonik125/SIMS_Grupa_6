using Controller;
using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for MedicalRecordView.xaml
    /// </summary>
    public partial class MedicalRecordView : Window
    {
        public MedicalRecordController mrc = new MedicalRecordController();

        public BloodType bloodT;
        public MedicalRecord medicalRecord = new MedicalRecord();
        // public List<MedicalRecord> medrec;
        public List<String> hron = new List<string>();
        public Allergies allergies = new Allergies();
        // public AllergiesController ac = new AllergiesController();
        public List<Allergies> allist;


        public MedicalRecordView()
        {

            InitializeComponent();
            //allist = ac.FindAll();
            bloodType.ItemsSource = Enum.GetValues(typeof(BloodType));
            allergens.ItemsSource = allist;
        }

        private void CreateMR_Click(object sender, RoutedEventArgs e)
        {
            // hron.Add(hronb.Text);
            medicalRecord.cardNum = Int32.Parse(brojK.Text);
            medicalRecord.bloodType = Conversion.StringToBloodType(bloodType.ToString());

            //medicalRecord.hronicalDeseasses = hron;

            mrc.AddMedicalRecord(medicalRecord);

            System.Diagnostics.Trace.WriteLine(medicalRecord);

            this.Close();
        }
    }
}
