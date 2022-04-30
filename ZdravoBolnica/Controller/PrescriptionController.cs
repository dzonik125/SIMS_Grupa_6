using Model;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class PrescriptionController
    {
        public PrescriptionService prescriptionService = new PrescriptionService();
        public void Create(Prescription entity)
        {
            prescriptionService.Create(entity);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> FindAll()
        {
            return prescriptionService.FindAll();
        }

        public Prescription FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(Prescription entity)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> findPrescriptionsByMRecordId(int id)
        {
            return prescriptionService.findPrescriptionsByMRecordId(id);
        }

        public void bindPrescriptionsWithDoctors(List<Prescription> prescriptions, List<Doctor> doctors)
        {
            prescriptionService.bindPrescriptionsWithDoctors(prescriptions, doctors);
        }

        public void bindPrescriptionsWithMedications(List<Prescription> prescriptions, List<Medication> medications)
        {
            prescriptionService.bindPrescriptionsWithMedications(prescriptions, medications);
        }
    }
}
