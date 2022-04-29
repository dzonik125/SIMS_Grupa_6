using Controller;
using Model;
using SIMS.Model;
using System;
using System.Windows;

namespace SIMS
{


    public partial class NewRoom : Window
    {

        private RoomController rc = new RoomController();

        public Room room;
        public NewRoom()
        {
            room = new Room();
            InitializeComponent();
            TypeCombo.ItemsSource = Conversion.GetRoomTypes();
        }

        private void NewRoom_Click(object sender, RoutedEventArgs e)
        {
            room.roomNum = Int32.Parse(RoomNum.Text);
            room.floor = Int32.Parse(Floor.Text);
            room.empty = true;
            room.roomType = Conversion.StringToRoomType(TypeCombo.Text);
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

    }
}
