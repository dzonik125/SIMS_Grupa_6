using Controller;
using Model;
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
    /// Interaction logic for EditRoom.xaml
    /// </summary>
    /// 
    public partial class EditRoom : Window
    {

        public Room selectedRoom;
        public RoomController rc = new RoomController();
        public EditRoom(Room r)
        {
            selectedRoom = r;
            InitializeComponent();
            RoomNum.Text = r.roomNum.ToString();
            TypeCombo.ItemsSource = Conversion.GetRoomTypes();
            if (r.roomType.ToString().Equals("surgery")) {
                TypeCombo.SelectedIndex = 0;
            }else if(r.roomType.ToString().Equals("examination"))
            {
                TypeCombo.SelectedIndex = 1;
            }
            else if (r.roomType.ToString().Equals("waitingRoom"))
            {
                TypeCombo.SelectedIndex = 2;
            }
            else if (r.roomType.ToString().Equals("laboratory"))
            {
                TypeCombo.SelectedIndex = 3;
            }
            else
            {
                TypeCombo.SelectedIndex = 4;
            }
            Floor.Text = r.floor.ToString();




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            selectedRoom.roomNum = Int32.Parse(RoomNum.Text);
            selectedRoom.roomType = Conversion.StringToRoomType(TypeCombo.Text);
            selectedRoom.floor = Int32.Parse(Floor.Text);

            rc.UpdateRoom(selectedRoom);
            ManagerUI mui = ManagerUI.Instance;
            mui.refresh();
            this.Close();
        }
    }
}
