using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
       public partial class ManagerUI : Window
    {

        private static ManagerUI instance = new ManagerUI();
        private RoomController rc = new RoomController();
        private EquipmentController ec = new EquipmentController();
        private RoomEquipmentController rec = new RoomEquipmentController();
        private Room roomSource;

        private ManagerUI() {
            InitializeComponent();

            this.DataContext = this;
            list = new ObservableCollection<Room>();
            List<Room> rooms = new List<Room>();
            rooms = rc.FindAll();
            foreach (Room r in rooms)
            {
                list.Add(r);
            }

            this.DataContext = this;
            equipList = new ObservableCollection<Equipment>();
            List<Equipment> inventory = new List<Equipment>();
            inventory = ec.FindAll();

            foreach (Equipment e in inventory)
            {
                equipList.Add(e);
            }

            listRoomInventory = new ObservableCollection<Equipment>();
           


        }
        public static ManagerUI Instance
        {
            get
            {
                return instance;
            }
        }




        public ObservableCollection<Room> list
        {
            get;
            set;
        }
        public static ObservableCollection<Equipment> equipList
        {
            get;
            set;
        }

        public ObservableCollection<Equipment> listRoomInventory
        {
            get;
            set;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewRoom nr = new NewRoom();
            nr.ShowDialog();
        }

        public void add(Room r)

        {
            this.DataContext = this;
           
           
        }

        public void refresh()
        {
            list.Clear();
            List<Room> rooms = new List<Room>();
            rooms = rc.FindAll();
            foreach(Room r in rooms)
            {
                list.Add(r);
            }
        }

        public void refreshEquipmentTable()
        {
            equipList.Clear();
            List<Equipment> inventory = new List<Equipment>();
            inventory = ec.FindAll();
            foreach (Equipment e in inventory)
            {
                equipList.Add(e);
            }
        }

        public void refreshRoomInventoryTable(Room r)
        {
            listRoomInventory.Clear();
           
            List<Equipment> allInventory = new List<Equipment>();
            allInventory = ec.FindAll();
            List<RoomEquipment> roomEquipment = new List<RoomEquipment>();
            roomEquipment = rec.FindAll();
            List<Equipment> roomInventory = new List<Equipment>();
            roomInventory = rec.GetRoomEquipment(allInventory, roomEquipment,r.id);
            foreach (Equipment e in roomInventory)
            {
                listRoomInventory.Add(e);
            }
        
            



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izabrati prostoriju.");
                return;
            }

            rc.DeleteRoomById(selectedRoom.id);
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izabrati prostoriju.");
                return;
            }

            EditRoom er = new EditRoom(selectedRoom);
            er.ShowDialog();



        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ManagerUI mui = ManagerUI.Instance;
            MainWindow mw = new MainWindow();
            mw.Show();
            mui.Hide();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddEquipment_Click(object sender, RoutedEventArgs e)
        {
            AddEquipment addEquipment = new AddEquipment();
            addEquipment.ShowDialog();
        }

        private void EditEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment selectedEquipment = equipmenttTable.SelectedItem as Equipment;
            if (selectedEquipment == null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }
            EditEquipment editEquipment = new EditEquipment(selectedEquipment);
            editEquipment.ShowDialog();
        }

        private void DeleteEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment selectedEquipment = equipmenttTable.SelectedItem as Equipment;
            if (selectedEquipment == null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }
            ec.DeleteEquipmentById(selectedEquipment.id);
            refreshEquipmentTable();
            return;


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void RoomInventory_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }

            List<Equipment> equipmentlist = new List<Equipment>();
            equipmentlist = ec.FindAll();
            rec.setRoomEquipment(selectedRoom.id, equipmentlist);


        }

        private void ShowRoomInventory_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsTable.SelectedItem as Room;
            roomSource = selectedRoom;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izaberite prostoriju");
                return;
            }
            refreshRoomInventoryTable(selectedRoom);

        }

        private void TransferEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment selectedEquipment = roomsEquipmentTable.SelectedItem as Equipment;
            if (selectedEquipment == null)
            {
                MessageBox.Show("Morate izbrati opremu");
                return;

            }
            TransferEquipment transferEquipment = new TransferEquipment(roomSource,selectedEquipment);
            transferEquipment.ShowDialog();
        }
    }
}
