using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;

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
            foreach (VacationPeriod v in vacationPeriods)
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
            List<VacationPeriod> vacationPeriods = FindAll();
            foreach (VacationPeriod vacationPeirod in vacationPeriods)
            {
                if (vacationPeirod.id == key)
                {
                    return vacationPeirod;
                }
            }
            return null;
        }

        public void Update(VacationPeriod entity)
        {
            List<VacationPeriod> vacationPeriods = FindAll();
            foreach (VacationPeriod vacationPeriod in vacationPeriods)
            {
                if (vacationPeriod.id.Equals(entity.id))
                {
                    vacationPeriod.StartTime = entity.StartTime;
                    vacationPeriod.EndTime = entity.EndTime;
                    vacationPeriod.comment = entity.comment;
                    vacationPeriod.rejectComment = entity.rejectComment;
                    vacationPeriod.doctor = entity.doctor;
                    vacationPeriod.status = entity.status;
                    vacationPeriod.type = entity.type;
                    break;
                }
            }
            vacationPeriodSerilizer.toCSV(filename, vacationPeriods);

        }
    }
}
