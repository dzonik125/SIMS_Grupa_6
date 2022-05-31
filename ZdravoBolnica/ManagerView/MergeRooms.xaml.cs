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
    /// Interaction logic for MergeRooms.xaml
    /// </summary>
    public partial class MergeRooms : Window
    {
        public Room room1 = new Room();
        public Room room2 = new Room();
        private MergeRoomsController _mergeRoomsController = new MergeRoomsController();
        private AppointmentController _appointmentController = new AppointmentController();
        private RoomController _roomController = new RoomController();
        public MergeRooms()
        {
            InitializeComponent();
            newPurpose.ItemsSource = Conversion.GetRoomTypes();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ConfirmMergeRooms_Click(object sender, RoutedEventArgs e)
        {
            room1.roomNum = int.Parse(roomNum1.Text);
            room2.roomNum = int.Parse(roomNum2.Text);
            room1.floor = int.Parse(Floor.Text);
            room2.floor = int.Parse(Floor.Text);
            room1.id = _roomController.FindRoomId(room1.floor, room1.roomNum);
            room2.id = _roomController.FindRoomId(room2.floor, room2.roomNum);
            DateTime startTimeRenovation = DateTime.Parse(startDate.Text);
            DateTime endTimeRenovation = DateTime.Parse(endDate.Text);
            int duration = ((endTimeRenovation - startTimeRenovation).Days) * 24 * 60;

            if(room1.id == 0 )
            {
                MessageBox.Show("Prva soba koju ste uneli ne postoji na ovom spratu: ");
                return;

            }

            if (room2.id == 0)
            {
                MessageBox.Show("Druga soba koju ste uneli ne postoji na ovom spratu: ");
                return;

            }

            if (_appointmentController.IsRoomOccupied(room1, startTimeRenovation, duration) || _appointmentController.IsRoomOccupied(room2,startTimeRenovation,duration))
             {

                MessageBox.Show("Soba je zauzeta u ovom periodu");
                return;
              }
           
             _mergeRoomsController.SaveRoomsMerging(room1, room2, Conversion.StringToRoomType(newPurpose.Text), startTimeRenovation, endTimeRenovation);
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();
            
           
           
            this.Close();


        }

        private void DiscardMergeRooms_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
