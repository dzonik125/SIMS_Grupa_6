using Model;
using SIMS.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SIMS.SecretaryView.ViewModel
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        private static RegistrationPageViewModel _instance;
        private ObservableCollection<Patient> _patientsList;
        //private List<Patient> _patients;

        public RelayCommand NewPatientCommand { get; set; }
        public RelayCommand DeletePatientCommand { get; set; }

        private Patient selectedPatient;

        private PatientController pc = new PatientController();

        public ObservableCollection<Patient> Patients
        {
            get => _patientsList;
            set
            {
                _patientsList = value;
                OnPropertyChanged(nameof(Patients));
            }
        }


        public Patient SelectedPatient
        {
            get => selectedPatient;
            set
            {
                selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public static RegistrationPageViewModel GetInstance()
        {
            return _instance;
        }

        public RegistrationPageViewModel()
        {
            _instance = this;
            _patientsList = new ObservableCollection<Patient>();
            List<Patient> patients = new List<Patient>();

            patients = pc.FindAllPatients();
            foreach (Patient p in patients)
            {
                _patientsList.Add(p);
            }
            NewPatientCommand = new RelayCommand(param => Execute(), param => CanExecute());
        }

        private bool CanExecute()
        {

            return true;
        }

        private void Execute()
        {
            var vm = new NewPatientViewModel();
            var createPatient = new NewPatientPage()
            {
                DataContext = vm
            };
            // vm.OnRequestClose += (s, e) => createPatient.this;
            SecretaryView.Instance.SetContent(createPatient);

        }

    }
}
