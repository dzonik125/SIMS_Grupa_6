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

namespace SIMS.ManagerView
{
    /// <summary>
    /// Interaction logic for EditMedication.xaml
    /// </summary>
    public partial class EditMedication : Window
    {
        private Medication selectedMedication;
        private MedicationController _medicationController = new MedicationController();
        public BindingList<Ingredients> ingredients = new BindingList<Ingredients>();
        public IngredientsController _ingriedientsController = new IngredientsController();
        public BindingList<Medication> medsReplacement = new BindingList<Medication>();

        public EditMedication(Medication m)
        {
            InitializeComponent();
            this.DataContext = this;
            ingredientsTable.ItemsSource = ingredients;
            replacementTable.ItemsSource = medsReplacement;
            List<Ingredients> ing = new List<Ingredients>();
            List<Medication> meds = new List<Medication>();
            meds = _medicationController.FindAllWithoutThisOne(m.name);
            ing = _ingriedientsController.FindAll();
            IngredientsCombo.ItemsSource = ing;
            replacement.ItemsSource = meds;
            selectedMedication = m;
            name.Text = selectedMedication.name;
            quantity.Text = selectedMedication.Amount.ToString();
            comment.Text = selectedMedication.comment;
            statusCombo.ItemsSource = Conversion.GetMEdicationStatusTypes();
           if(m.status.ToString().Equals("accepted"))
            {
                statusCombo.SelectedIndex = 0;
            }
           else if(m.status.ToString().Equals("waiting"))
            {
                statusCombo.SelectedIndex = 1;
            }
           else if (m.status.ToString().Equals("rejected"))
            {
                statusCombo.SelectedIndex = 2;
            }
           foreach(Ingredients i in m.components)
            {
                ingredients.Add(i);
            }

           foreach(int medId in m.medicationReplacementIds)
            {
                medsReplacement.Add(_medicationController.FindById(medId));
            }

        }

        private void EditMeds_Click(object sender, RoutedEventArgs e)
        {
            List<int> medicationIds = new List<int>();
            foreach (Medication m in medsReplacement.ToList<Medication>())
            {
                medicationIds.Add(m.id);
            }
            selectedMedication.name = name.Text;
            selectedMedication.status = Conversion.StringToMedicationStatusType(statusCombo.Text);
            selectedMedication.Amount = int.Parse(quantity.Text);
            selectedMedication.components = ingredients.ToList<Ingredients>();
            selectedMedication.medicationReplacementIds = medicationIds;
            selectedMedication.comment = "";

            _medicationController.Update(selectedMedication);
            ManagerUI mui = ManagerUI.Instance;
            mui.refreshMedicationTable();
            this.Close();
        }

        private void DiscardMeds_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddReplacement_Click(object sender, RoutedEventArgs e)
        {
            medsReplacement.Add((Medication)replacement.SelectedItem);

        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            ingredients.Add((Ingredients)IngredientsCombo.SelectedItem);
        }
    }
}
