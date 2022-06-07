using Model;
using SIMS.Controller;
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

namespace SIMS
{
    /// <summary>
    /// Interaction logic for EditEquipment.xaml
    /// </summary>
    public partial class EditEquipment : Window
    {
        private Equipment selectedEquipment;
        private EquipmentController ec = new EquipmentController();

        public EditEquipment()
        {
            InitializeComponent();
        }

        /*public EditEquipment(Equipment e)
        {
            InitializeComponent();
            selectedEquipment = e;
            Quantity.Text = selectedEquipment.quantity.ToString();
            Name.Text = selectedEquipment.item;
            ComboType.ItemsSource = Conversion.GetEquipmentTypes();
            if (e.type.ToString().Equals("potrosna"))
            {
                ComboType.SelectedIndex = 0;
            }
            else if (e.type.ToString().Equals("nepotrosna"))
            {
                ComboType.SelectedIndex = 1;
            }
        }*/

        /*private void CloseEditEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void EditEquip_Click(object sender, RoutedEventArgs e)
        {
            selectedEquipment.quantity = int.Parse(Quantity.Text);
            selectedEquipment.item = Name.Text;
            selectedEquipment.type = Conversion.StringToEquipmentType(ComboType.Text);
            ec.UpdateEquipment(selectedEquipment);
            ManagerUI mui = ManagerUI.Instance;
            mui.refreshEquipmentTable();
            this.Close();
        }*/
    }
}
