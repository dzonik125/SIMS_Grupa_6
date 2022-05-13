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
using Controller;
using Model;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.PatientView
{
    /// <summary>
    /// Interaction logic for SurveyWindow.xaml
    /// </summary>
    public partial class SurveyWindow : Window
    {
        private AppointmentController ac = new AppointmentController();
        private SurveyController sc = new SurveyController();
        private DateTime n = new DateTime(1000, 1, 1);

        public SurveyWindow()
        {
            InitializeComponent();
            sc.CreateSurveysForPatient(1);
            List<Survey> toShow = new List<Survey>();
            foreach (Survey s in sc.FindAll())
            {
                if (s.completed == n || s.id == 1)
                {
                    toShow.Add(s);
                }
            }
            cb.ItemsSource = toShow;
            cb.DisplayMemberPath = "displayName";
        }

        private void Cb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Survey s1 = (Survey) cb.SelectedItem;
            if (s1.id == 1)
            {
                HospitalSurvey hs = new HospitalSurvey((Survey) cb.SelectedItem);
                Close();
                hs.ShowDialog();
                return;
            }
            SurveyFrom sf = new SurveyFrom((Survey) cb.SelectedItem); 
            Close();
            sf.ShowDialog();
        }
    }
}   