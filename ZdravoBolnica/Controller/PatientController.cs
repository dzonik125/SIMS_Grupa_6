using Model;
using Service;
using System;
using System.Collections.Generic;

namespace SIMS
{
    public class PatientController
    {
        private PatientService ps = new PatientService();
        public Patient FindPatientById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> FindAllPatients()
        {
            return ps.FindAllPatients();
        }

        public bool DeletePatientById(string id)
        {
            ps.DeletePatientById(id);
            return true;
        }

        public bool AddPatient(Patient p)
        {
            ps.AddPatient(p);
            return true;
        }
        public bool AddGuestPatient(Patient p)
        {
            ps.AddGuestPatient(p);
            return true;
        }

        public bool UpdatePatient(Patient p)
        {

            ps.UpdatePatient(p);
            return true;
        }

        public Service.PatientService patientService;

    }

}
