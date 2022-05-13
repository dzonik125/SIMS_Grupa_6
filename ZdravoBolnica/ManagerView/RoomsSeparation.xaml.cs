using Controller;
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

namespace SIMS.ManagerView
{
    /// <summary>
    /// Interaction logic for SeparateRooms.xaml
    /// </summary>
    public partial class RoomSeparation : Window
    {
        public Room room1 = new Room();
        public Room room2 = new Room();
        private RoomController _roomController = new RoomController();
        private SeparateRoomsController _separateRoomsController = new SeparateRoomsController();
        public RoomSeparation()
        {
            InitializeComponent();
            newPurposeRoom1.ItemsSource = Conversion.GetRoomTypes();
            newPurposeRoom2.ItemsSource = Conversion.GetRoomTypes();
        }

        

        private void ConfirmSeparationRooms_Click(object sender, RoutedEventArgs e)
        {
            room1.roomNum = int.Parse(roomNum1.Text);
            room1.floor = int.Parse(Floor.Text);
            room1.id = _roomController.FindRoomId(room1.floor, room1.roomNum);
            room1.roomType = Conversion.StringToRoomType(newPurposeRoom1.Text);
            room2.roomNum = int.Parse(roomNum2.Text);
            room2.floor = int.Parse(Floor.Text);
            room2.roomType = Conversion.StringToRoomType(newPurposeRoom2.Text);
            DateTime startTimeRenovation = DateTime.Parse(startDate.Text);
            DateTime endTimeRenovation = DateTime.Parse(endDate.Text);
            int duration = ((endTimeRenovation - startTimeRenovation).Days) * 24 * 60;

            SeparateRooms separateRooms = new SeparateRooms();
            separateRooms.roomOne = room1;
            separateRooms.roomTwo = room2;
            separateRooms.startDate = startTimeRenovation;
            separateRooms.endDate = endTimeRenovation;
            


            _separateRoomsController.SaveFutureRenovationForRoomSeparation(separateRooms);
            this.Close();
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();

        }

        private void DiscardSeparationRooms_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
