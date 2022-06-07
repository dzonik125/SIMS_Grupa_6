using SIMS.Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SIMS.Model;

namespace SIMS.ManagerView
{
    /// <summary>
    /// Interaction logic for AddMedication.xaml
    /// </summary>
    public partial class AddMedication : Window
    {
        public Medication newMedication = new Medication();
        private MedicationController _medicationController = new MedicationController();
        public BindingList<Ingredient> ingredients = new BindingList<Ingredient>();
        public IngredientsController _ingriedientsController = new IngredientsController();
        public BindingList<Medication> medsReplacement = new BindingList<Medication>();
       
        public AddMedication()
        {
            InitializeComponent();
            statusCombo.ItemsSource = Conversion.GetMEdicationStatusTypes();
           

            this.DataContext = this;
            ingredientsTable.ItemsSource = ingredients;
            replacementTable.ItemsSource = medsReplacement;
            List<Ingredient> ing = new List<Ingredient>();
            List<Medication> meds = new List<Medication>();
            meds = _medicationController.FindAll();
            ing = _ingriedientsController.FindAll();
            IngredientsCombo.ItemsSource = ing;
            replacement.ItemsSource = meds;
        }

        private void DiscardMeds_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddMeds_Click(object sender, RoutedEventArgs e)
        {
            List<int> medicationIds = new List<int>();
            foreach(Medication m in medsReplacement.ToList<Medication>())
            {
                medicationIds.Add(m.id);
            }
            newMedication.name = name.Text;
            newMedication.status = MedicationStatusType.waiting;
            newMedication.Amount = int.Parse(quantity.Text);
            newMedication.components = ingredients.ToList<Ingredient>();
            newMedication.medicationReplacementIds = medicationIds;
            newMedication.comment = "";

            _medicationController.Create(newMedication);
            ManagerUI mui = ManagerUI.Instance;
            mui.refreshMedicationTable();
            this.Close();

           
        }
        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            ingredients.Add((Ingredient)IngredientsCombo.SelectedItem);
        }

        private void AddReplacement_Click(object sender, RoutedEventArgs e)
        {
            medsReplacement.Add((Medication)replacement.SelectedItem);

        }
    }
}
