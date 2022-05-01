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
    /// Interaction logic for Renovation.xaml
    /// </summary>
    public partial class Renovation : Window
    {
        public Renovation()
        {
            InitializeComponent();
        }

        private void ChangePurpose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MergeRooms_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RoomRenovation_Click(object sender, RoutedEventArgs e)
        {
            RoomRenovationWindow rrw = new RoomRenovationWindow();
            rrw.Show();
            this.Close();
        }
    }
}
