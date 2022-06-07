using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MedicationDetails.xaml
    /// </summary>
    public partial class MedicationDetails : Window
    {
        public Medication selectedMed;
        private MedicationController medicationController = new MedicationController();
        public BindingList<Ingredient> ingredients = new BindingList<Ingredient>();
        public BindingList<Medication> medsReplacement = new BindingList<Medication>();
        public MedicationDetails(Medication m)
        {
            InitializeComponent();
            selectedMed = new Medication();
            selectedMed = m;
            Amount.Text = m.Amount.ToString();
            Ingredients.ItemsSource = ingredients;
            Replacements.ItemsSource = medsReplacement;
            MedName.Content = m.name;
            Comment.Text = m.comment;
            foreach (Ingredient i in m.components)
            {
                ingredients.Add(i);
            }

            foreach (int medId in m.medicationReplacementIds)
            {
                medsReplacement.Add(medicationController.FindById(medId));
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedMed.status = MedicationStatusType.accepted;
            medicationController.Update(selectedMed);
            Medications medications = Medications.Instance;
            medications.refresh();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Comment.Text.Equals(""))
            {
                MessageBox.Show("Morate ostaviti komentar zasto odbijate lek");
                return;
            }
            selectedMed.status = MedicationStatusType.rejected;
            selectedMed.comment = Comment.Text;
            medicationController.Update(selectedMed);
            Medications medications = Medications.Instance;
            medications.refresh();
            this.Close();
        }
    }
}
