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
        }

        public EditEquipment(Equipment e)
        {
            InitializeComponent();
            selectedEquipment = e;
            ID.Text = selectedEquipment.id.ToString();
            Name.Text = selectedEquipment.item;
            Type.Text = Conversion.EquipmentTypeToString(selectedEquipment.type);
        }

        private void CloseEditEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void EditEquip_Click(object sender, RoutedEventArgs e)
        {
            selectedEquipment.id = int.Parse(ID.Text);
            selectedEquipment.item = Name.Text;
            selectedEquipment.type = Conversion.StringToEquipmentType(Type.Text);
            ec.UpdateEquipment(selectedEquipment);
            ManagerUI mui = ManagerUI.Instance;
            mui.refreshEquipmentTable();
            this.Close();
        }
    }
}
