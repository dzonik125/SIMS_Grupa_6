using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;

namespace SIMS.Repository
{
    public class PrescriptionRepository : IRepository<Prescription, int>
    {
        private String filename = @".\..\..\..\Data\prescriptions.txt";
        private Serializer<Prescription> prescriptionSerializer = new Serializer<Prescription>();
        public void Create(Prescription entity)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions = prescriptionSerializer.fromCSV(filename);
            if (prescriptions.Count > 0)
            {
                entity.id = prescriptions[prescriptions.Count - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            prescriptions.Add(entity);
            prescriptionSerializer.toCSV(filename, prescriptions);
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
            return prescriptionSerializer.fromCSV(filename);
        }

        public Prescription FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(Prescription entity)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> findPrescriptionsbyMRecordId(int id)
        {
            List<Prescription> allPrescriptions = new List<Prescription>();
            allPrescriptions = prescriptionSerializer.fromCSV(filename);
            List<Prescription> prescriptionsByMRecordId = new List<Prescription>();
            foreach(Prescription p in allPrescriptions)
            {
                if (p.medicalRecord.id == id)
                    prescriptionsByMRecordId.Add(p);
            }
            return prescriptionsByMRecordId;
        }
    }
}
