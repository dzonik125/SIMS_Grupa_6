using Model;
using SIMS.Model;
using SIMS.Service;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class VacationPeriodController
    {
        public VacationPeriodService vacationPeriodService = new VacationPeriodService();
        public void Create(VacationPeriod entity)
        {
            vacationPeriodService.Create(entity);
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
            return vacationPeriodService.FindAll();
        }

        public bool checkIfDoctorHasAppoinmentsInPeriod(Doctor doctor, DateRange dateRange)
        {
            return vacationPeriodService.checkIfDoctorHasAppoinmentsInPeriod(doctor, dateRange);
        }

        public List<VacationPeriod> findAllByDoctorId(int id)
        {
            return vacationPeriodService.findAllByDoctorId(id);
        }

        public bool checkIfDoctorIsAlreadyOnVacation(Doctor doctor, DateRange dateRange)
        {
            return vacationPeriodService.checkIfDoctorIsAlreadyOnVacation(doctor, dateRange);
        }


        public bool checkForDoctorsOnVacation(Doctor doctor, DateRange dateRange)
        {
            return vacationPeriodService.checkForDoctorsOnVacation(doctor, dateRange);
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
