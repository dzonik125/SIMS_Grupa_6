using Controller;
using Model;
using SIMS.Controller;
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

        public List<String> hron = new List<string>();

        public AllergiesController ac = new AllergiesController();

        public List<string> allist = new List<string>();
        public List<Allergies> allergs = new List<Allergies>();

        public List<Allergies> alergije = new List<Allergies>();

        public Allergies allergies = new Allergies();

        public MedicalRecordView()
        {
            //  AllergiesController ac = new AllergiesController();

            InitializeComponent();
            allergs = ac.FindAll();
            bloodType.ItemsSource = Enum.GetValues(typeof(BloodType));
            foreach (Allergies a in allergs)
            {
                allist.Add(a.name);
            }
            allergens.ItemsSource = allist;
        }

        private void CreateMR_Click(object sender, RoutedEventArgs e)
        {
            medicalRecord.cardNum = Int32.Parse(brojK.Text);
            medicalRecord.bloodType = (BloodType)bloodType.SelectedIndex;

            foreach (Allergies a in allergs)
            {
                if (a.name.Equals(allergens.SelectedItem.ToString()))
                {
                    allergies = a;
                    break;
                }

            }

            medicalRecord.allergies = allergies;



            mrc.AddMedicalRecord(medicalRecord);

            this.Close();
        }

        private void allergens_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // allergens.SelectedIndex;
        }
    }
}
