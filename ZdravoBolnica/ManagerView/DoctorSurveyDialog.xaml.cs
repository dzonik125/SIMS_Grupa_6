using System.Collections.ObjectModel;
using System.Windows;
using Model;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.ManagerView
{
    public partial class DoctorSurveyDialog : Window
    {
        private DoctorSurveyController doctorSurveyController = new DoctorSurveyController();
        public DoctorSurveyDialog(Doctor doctor)
        {
            InitializeComponent();
            this.DataContext = this;
            doctorSurveysList = new ObservableCollection<DoctorSurvey>(doctorSurveyController.FindSurveyForDoctor(doctor));
            //refreshDoctorSurveyTable(doctor);
        }

        public ObservableCollection<DoctorSurvey> doctorSurveysList { get; set; }
        private void refreshDoctorSurveyTable(Doctor doctor)
        {
            doctorSurveysList.Clear();
            foreach(DoctorSurvey d in doctorSurveyController.FindSurveyForDoctor(doctor))
            {
                doctorSurveysList.Add(d);
            }
        }
    }
}