using System;
using System.Windows;
using Controller;
using Model;
using SIMS.ManagerView.ViewModel;
using SIMS.Model;

namespace SIMS.ManagerView
{


    public partial class NewRoom : Window
    {

        private RoomController rc = new RoomController();

        public Room room;
        public NewRoom()
        {
            room = new Room();
            InitializeComponent();
            //TypeCombo.ItemsSource = Conversion.GetRoomTypes();
            var vm = new NewRoomViewModel();
            DataContext = vm;
            vm.OnRequestClose += (s, e) => Close();
        }

        /*private void NewRoom_Click(object sender, RoutedEventArgs e)
        {
            room.roomNum = Int32.Parse(RoomNum.Text);
            room.floor = Int32.Parse(Floor.Text);
            room.empty = true;
            room.roomType = Conversion.StringToRoomType(TypeCombo.Text);
            if (rc.StorageExist(room))
            {
                MessageBox.Show("Vec postoji magacin");
                return;
            }
            if (rc.FindRoomByFloor(room.roomNum, room.floor))
            {
                MessageBox.Show("Na ovom spratu vec postoji taj broj prostorije");
                return;
            }
            rc.AddRoom(room);
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();
            this.Close();

        }

        private void NewRoomClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TypeCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }*/
    }
}
