using Controller;
using Model;
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
    /// <summary>
    /// Interaction logic for ManagerUI.xaml
    /// </summary>
    public partial class ManagerUI : Window
    {

        private static ManagerUI instance = new ManagerUI();
        private RoomController rc = new RoomController();

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

       /* public ManagerUI()
        {

            InitializeComponent();
            
            this.DataContext = this;
            list = new ObservableCollection<Room>();
            List<Room> rooms = new List<Room>();
            rooms = rc.FindAll();
            foreach (Room r in rooms)
            {
                list.Add(r);
            }
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewRoom nr = new NewRoom();
            nr.ShowDialog();
        }

        public void add(Room r)

        {
            this.DataContext = this;
            System.Diagnostics.Trace.WriteLine("jea");
           
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = appointmentsTable.SelectedItem as Room;
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
            Room selectedRoom = appointmentsTable.SelectedItem as Room;
            if (selectedRoom == null)
            {
                MessageBox.Show("Izabrati prostoriju.");
                return;
            }

            EditRoom er = new EditRoom(selectedRoom);
            er.ShowDialog();



        }
    }
}
