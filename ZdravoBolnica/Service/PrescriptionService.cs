using Model;
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

        public void bindPrescriptionsWithDoctors(List<Prescription> prescriptions, List<Doctor> doctors)
        {
            foreach (Doctor d in doctors)
            {
                foreach (Prescription p in prescriptions)
                {
                    if (p.doctor.id == d.id)
                    {
                        p.doctor = d;
                    }
                }
            }
        }

        public void bindPrescriptionsWithMedications(List<Prescription> prescriptions, List<Medication> medications)
        {
            foreach (Medication m in medications)
            {
                foreach (Prescription p in prescriptions)
                {
                    if (p.medication.id == m.id)
                    {
                        p.medication = m;
                    }
                }
            }

        }

    }
}
