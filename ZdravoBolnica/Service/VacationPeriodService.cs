using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIMS.Model.VacationPeriodStatus;

namespace SIMS.Service
{
    public class VacationPeriodService
    {
        public VacationPeriodRepository vacationPeriodRepository = new VacationPeriodRepository();
        public AppointmentService appointmentService = new AppointmentService();
        public DoctorService doctorService = new DoctorService();
        public void Create(VacationPeriod entity)
        {
            vacationPeriodRepository.Create(entity);
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
            return vacationPeriodRepository.FindAll();
        }

        public bool checkIfDoctorHasAppoinmentsInPeriod(Doctor doctor, DateRange dateRange)
        {
            List<Appointment> appointments = appointmentService.getAppointmentsByDoctorId(doctor.id);
            foreach(Appointment a in appointments)
            {
                if (dateRange.checkForIntersection(a.startTime, a.duration))
                    return true;
            }
            return false;
        }

        public List<VacationPeriod> findAllByDoctorId(int id)
        {
            return vacationPeriodRepository.findAllByDoctorId(id);
        }

        public bool checkIfDoctorIsAlreadyOnVacation(Doctor doctor, DateRange dateRange)
        {
            List<VacationPeriod> docVacationPeriods = findAllByDoctorId(doctor.id);
            foreach(VacationPeriod v in docVacationPeriods)
            {
                TimeSpan vacationDuration = v.EndTime - v.StartTime;
                if (dateRange.checkForIntersection(v.StartTime, vacationDuration.TotalMinutes))
                {
                    return true;
                }
            }
            return false;
        }


        public bool checkForDoctorsOnVacation(Doctor doctor, DateRange dateRange)
        {
            List<VacationPeriod> vacationPeriods = findAllByDoctorSpecialization(doctor.specialization);
            int numOfDoctorsOnVacation = 0;
            foreach(VacationPeriod v in vacationPeriods)
            {
                TimeSpan vacationPeriodDuration = v.EndTime - v.StartTime;
                if (dateRange.checkForIntersection(v.StartTime, vacationPeriodDuration.TotalMinutes))
                    numOfDoctorsOnVacation += 1;
            }
            return numOfDoctorsOnVacation > 1;
        }

        private List<VacationPeriod> findAllByDoctorSpecialization(Specialization specialization)
        {
            List<VacationPeriod> vacationPeriods = FindAll();
            List<VacationPeriod> returnPeriods = new List<VacationPeriod>();
            bindDoctorsWithVacationPeriods(vacationPeriods);
            foreach(VacationPeriod v in vacationPeriods)
            {
                if((v.doctor.specialization == specialization) && v.status != VacationPeriodStatusType.rejected)
                {
                    returnPeriods.Add(v);
                }
            }
            return returnPeriods;
        }

        public void bindDoctorsWithVacationPeriods(List<VacationPeriod> vacationPeriods)
        {
            List<Doctor> doctors = doctorService.GetAllDoctors();
            foreach (Doctor d in doctors)
            {
                foreach (VacationPeriod v in vacationPeriods)
                {
                    if (v.doctor.id == d.id)
                    {
                        v.doctor = d;
                    }
                }
            }
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
