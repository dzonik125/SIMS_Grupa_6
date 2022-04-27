using Model;
using SIMS.Controller;
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
    /// Interaction logic for TransferEquipment.xaml
    /// </summary>
    public partial class TransferEquipment : Window
    {
        private Room roomDestination = new Room();
        private Room roomSource = new Room();
        private RoomEquipmentController rec = new RoomEquipmentController();
        private Equipment equipment = new Equipment();
        private int quantity;
        public TransferEquipment(Room roomS, Equipment selectedEquipment)
        {
            InitializeComponent();
            equipment = selectedEquipment;
            roomSource = roomS;

        }

        private void TransferEqupment_Click(object sender, RoutedEventArgs e)
        {
           

        }

      
        private void TransferEquipmentToAnotherRoom_Click(object sender, RoutedEventArgs e)
        {
            roomDestination.floor = int.Parse(Floor.Text);
            roomDestination.roomNum = int.Parse(RoomNum.Text);
            quantity = int.Parse(Quantity.Text);
            rec.TransferEquipment(roomSource,roomDestination, equipment,quantity);
            ManagerUI mui = ManagerUI.Instance;
            mui.refreshRoomInventoryTable(roomDestination);
            mui.refreshRoomInventoryTable(roomSource);
            this.Close();
        }
    }
}
