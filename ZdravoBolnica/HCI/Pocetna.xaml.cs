using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.HCI
{
    /// <summary>
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class Pocetna : Page
    {
        private Dictionary<string, Color> dates = new Dictionary<string, Color>();

        public Pocetna()
        {
            InitializeComponent();
            //Dictionary<String, Color> dates = new Dictionary<String, Color>
            //{
            //    {"5/10/2022", Colors.Red},
            //    {"5/12/2022", Colors.Red},
            //};

            //Style style = new Style(typeof(CalendarDayButton));

            //foreach (KeyValuePair<String, Color> item in dates)
            //{
            //    DataTrigger trigger = new DataTrigger()
            //    {
            //        Value = item.Key,
            //        Binding = new Binding("Date")
            //    };
            //    trigger.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(item.Value)));
            //    style.Triggers.Add(trigger);
            //}

            //MyCalendar.CalendarDayButtonStyle = style;
        }

        public void refresh()
        {

        }


    }
}
