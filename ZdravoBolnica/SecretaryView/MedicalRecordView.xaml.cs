using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public List<Allergies> al = new List<Allergies>();


        public ObservableCollection<Allergies> Alergeni
        {
            get;
            set;
        }


        public MedicalRecordView()
        {
            //Alergeni = new ObservableCollection<Allergies>();
            //  AllergiesController ac = new AllergiesController();

            InitializeComponent();
            allergs = ac.FindAll();
            bloodType.ItemsSource = Enum.GetValues(typeof(BloodType));
            foreach (Allergies a in allergs)
            {
                allist.Add(a.name);
            }
            AllergsBox.ItemsSource = allist;
        }

        /*    private void CreateMR_Click(object sender, RoutedEventArgs e)
            {
                medicalRecord.cardNum = Int32.Parse(brojK.Text);
                medicalRecord.bloodType = (BloodType)bloodType.SelectedIndex;

                foreach (Allergies a in allergs)
                {
                    if (a.name.Equals(AllergsBox.SelectedItem.ToString()))
                    {
                        allergies = a;
                        break;
                    }

                }

                medicalRecord.allergies = allergies;



                mrc.AddMedicalRecord(medicalRecord);

                this.Close();
            }*/

        // private void allergens_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //  {
        // allergens.SelectedIndex;
        // }

        private void refresh(Patient patient)
        {
            Alergeni.Clear();

            //  List<Allergies> allergies = new List<Allergies>();
            //  allergies = ac.FindAll();
            //  foreach (Allergies a in allergies)
            // {
            //     if(patient.id == a.
            //   }


        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //   refresh();

        }

        public Allergies getSelectedAllergen()
        {
            Allergies a = allergs[AllergsBox.SelectedIndex];
            return a;
        }

    }
}
