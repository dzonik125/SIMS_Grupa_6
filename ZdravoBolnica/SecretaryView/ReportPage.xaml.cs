using Model;
using Service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.SecretaryView.ViewModel
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public BindingList<Room> list = new BindingList<Room>();
        public List<Room> rooms = new List<Room>();
        public RoomService rs = new RoomService();

        public ReportPage()
        {
            InitializeComponent();
            rooms = rs.IsRoomAvailable();
            foreach (Room room in rooms)
            {
                list.Add(room);
            }
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
