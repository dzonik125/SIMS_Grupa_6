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
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.PatientView
{
    /// <summary>
    /// Interaction logic for HospitalSurvey.xaml
    /// </summary>
    public partial class HospitalSurvey : Window
    {
        public List<String> values { get; set; }
        public Survey s1 = new Survey();
        private SurveyController sc = new SurveyController();
        public HospitalSurvey(Survey s)
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
            cb1.ItemsSource = values;
            cb2.ItemsSource = values;
            cb3.ItemsSource = values;
            cb4.ItemsSource = values;
            cb5.ItemsSource = values;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double a1 = double.Parse((String)cb1.SelectedItem);
            double a2 = double.Parse((String)cb2.SelectedItem);
            double a3 = double.Parse((String)cb3.SelectedItem);
            double a4 = double.Parse((String)cb4.SelectedItem);
            double a5 = double.Parse((String)cb5.SelectedItem);

            s1.avg = (a1 + a2 + a3 + a4 + a5) / 5;
            sc.Update(s1);
            Close();
        }
    }
}
