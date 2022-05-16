using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.PatientView
{
    /// <summary>
    /// Interaction logic for SurveyFrom.xaml
    /// </summary>
    public partial class SurveyFrom : Window
    {

        public List<String> values { get; set; }
        public Survey s1 = new Survey();
        private SurveyController sc = new SurveyController();
        public SurveyFrom(Survey s)
        {
            InitializeComponent();
            s1 = s;
            values = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                values.Add(i.ToString());
            }

            fillCombos();

        }

        private void fillCombos()
        {
            q1.ItemsSource = values;
            q2.ItemsSource = values;
            q3.ItemsSource = values;
            q4.ItemsSource = values;
            q5.ItemsSource = values;
            q6.ItemsSource = values;
            q7.ItemsSource = values;
            q8.ItemsSource = values;
            q9.ItemsSource = values;
            q10.ItemsSource = values;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            double a1 = double.Parse((String) q1.SelectedItem);
            double a2 = double.Parse((String) q2.SelectedItem);
            double a3 = double.Parse((String) q3.SelectedItem);
            double a4 =  double.Parse((String) q4.SelectedItem);
            double a5 = double.Parse((String) q5.SelectedItem);
            double a6 =  double.Parse((String) q6.SelectedItem);
            double a7 =  double.Parse((String) q7.SelectedItem);
            double a8 =  double.Parse((String) q8.SelectedItem);
            double a9 =  double.Parse((String) q9.SelectedItem);
            double a10 = double.Parse((String) q10.SelectedItem);

            s1.avg = (a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10) / 10;
            s1.completed = DateTime.Now;
            sc.Update(s1); 
            Close();
        }
    }
}
