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

namespace SIMS.HCI
{
    /// <summary>
    /// Interaction logic for HCI_Main.xaml
    /// </summary>
    public partial class HCI_Main : Window
    {
        public HCI_Main()
        {
            InitializeComponent();
            
            Loaded += My_Window_Loaded;
        }

        private void My_Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Pocetna());
        }
    }
}
