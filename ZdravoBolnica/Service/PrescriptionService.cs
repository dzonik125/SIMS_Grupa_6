using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class PrescriptionService
    {

        public PrescriptionRepository prescriptionRepository = new PrescriptionRepository();
        public void Create(Prescription entity)
        {
            prescriptionRepository.Create(entity);
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
            return prescriptionRepository.FindAll();
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
            return prescriptionRepository.findPrescriptionsbyMRecordId(id);
        }

        public void bindPrescriptionsWithDoctors(List<Prescription> prescriptions)
        {
            DoctorService doctorService = new DoctorService();
            foreach (Prescription p in prescriptions)
            {
                p.doctor = doctorService.GetDoctorById(p.doctor.id);
            }
            
        }

        public void bindPrescriptionsWithMedications(List<Prescription> prescriptions)
        {
            MedicationService medicationService = new MedicationService();
            foreach (Prescription p in prescriptions)
            {
                p.medication = medicationService.FindById(p.medication.id);
            }

        }

    }
}
