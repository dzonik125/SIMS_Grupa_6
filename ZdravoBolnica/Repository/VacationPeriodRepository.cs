using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using SIMS.Model;

namespace SIMS.Repository
{
    public class VacationPeriodRepository : Repository<VacationPeriod, int>
    {
        private String filename = @".\..\..\..\Data\vacationPeriods.txt";
        private Serializer<VacationPeriod> vacationPeriodSerilizer = new Serializer<VacationPeriod>();
        public void Create(VacationPeriod entity)
        {
            List<VacationPeriod> periods = vacationPeriodSerilizer.fromCSV(filename);
            if (periods.Count > 0)
            {
                entity.id = periods[periods.Count - 1].id;
                entity.id++;
            }
            else
                entity.id = 1;

            periods.Add(entity);
            vacationPeriodSerilizer.toCSV(filename, periods);
        }

        public List<VacationPeriod> findAllByDoctorId(int id)
        {
            List<VacationPeriod> toReturn = new List<VacationPeriod>();
            List<VacationPeriod> vacationPeriods = FindAll();
            foreach(VacationPeriod v in vacationPeriods)
            {
                if (v.doctor.id == id)
                    toReturn.Add(v);
            }
            return toReturn;
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<VacationPeriod> FindAll()
        {
            return vacationPeriodSerilizer.fromCSV(filename);
        }

        public VacationPeriod FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(VacationPeriod entity)
        {
            throw new NotImplementedException();
        }
    }
}
