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
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        public Equipment equipment = new Equipment();
        private EquipmentController ec = new EquipmentController();
        public AddEquipment()
        {
            InitializeComponent();

        }


        private void CloseAddEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddEquip_Click(object sender, RoutedEventArgs e)
        {
            equipment.id = Int32.Parse(ID.Text);
            equipment.item = Name.Text;
            equipment.type = Conversion.StringToEquipmentType(Type.Text);
            ec.AddEquipment(equipment);

            ManagerUI mui = ManagerUI.Instance;
            mui.refreshEquipmentTable();
            this.Close();

        }
    }
}
