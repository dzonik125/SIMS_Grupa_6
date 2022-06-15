using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Util;
using System;
using System.Collections.Generic;
using static SIMS.Model.VacationPeriodStatus;

namespace SIMS.Service
{
    public class VacationPeriodService
    {
        public VacationPeriodRepository vacationPeriodRepository = new VacationPeriodRepository();
        public AppointmentService appointmentService = new AppointmentService();
        public DoctorService doctorService = new DoctorService();
       

        public bool VacationOverlapsWithAppointments(Doctor doctor, Scheduler scheduler)
        {
            bool vacationOverlapsWithAppointments = false;
            List<Appointment> appointments = appointmentService.GetAppointmentsByDoctorId(doctor.id);
            foreach (Appointment a in appointments)
            {
                if (scheduler.overlapsWithExistingTerm(a.startTime, a.duration))
                    vacationOverlapsWithAppointments = true;
            }
            return vacationOverlapsWithAppointments;
        }



        public List<VacationPeriod> findAllByDoctorId(int id)
        {
            return vacationPeriodRepository.findAllByDoctorId(id);
        }

        public bool checkIfDoctorIsAlreadyOnVacation(Doctor doctor, Scheduler scheduler)
        {
            bool doctorIsAlreadyOnVacation = false;
            List<VacationPeriod> docVacationPeriods = findAllByDoctorId(doctor.id);
            foreach (VacationPeriod v in docVacationPeriods)
            {
                TimeSpan vacationDuration = v.EndTime - v.StartTime;
                if (scheduler.overlapsWithExistingTerm(v.StartTime, vacationDuration.TotalMinutes))
                {
                    doctorIsAlreadyOnVacation = true;
                }
            }
            return doctorIsAlreadyOnVacation;
        }


        public bool checkForDoctorsOnVacation(Doctor doctor, Scheduler scheduler)
        {
            List<VacationPeriod> vacationPeriods = findAllButRejectedByDoctorSpecialization(doctor.specialization);
            int numOfDoctorsOnVacation = 0;
            foreach (VacationPeriod v in vacationPeriods)
            {
                TimeSpan vacationPeriodDuration = v.EndTime - v.StartTime;
                if (scheduler.overlapsWithExistingTerm(v.StartTime, vacationPeriodDuration.TotalMinutes))
                    numOfDoctorsOnVacation += 1;
            }
            return numOfDoctorsOnVacation > 1;
        }

        private List<VacationPeriod> findAllButRejectedByDoctorSpecialization(Specialization specialization)
        {
            List<VacationPeriod> vacationPeriods = FindAll();
            List<VacationPeriod> vacationPeriodsBySpecialization = new List<VacationPeriod>();
            bindDoctorsWithVacationPeriods(vacationPeriods);
            foreach (VacationPeriod v in vacationPeriods)
            {
                if ((v.doctor.specialization == specialization) && v.status != VacationPeriodStatusType.rejected)
                {
                    vacationPeriodsBySpecialization.Add(v);
                }
            }
            return vacationPeriodsBySpecialization;
        }

        public void bindDoctorsWithVacationPeriods(List<VacationPeriod> vacationPeriods)
        {
            foreach (VacationPeriod v in vacationPeriods)
            {
                v.doctor = doctorService.GetDoctorById(v.doctor.id);
            }
        }

        public VacationPeriod FindById(int id)
        {
            return vacationPeriodRepository.FindById(id);
        }

        public bool Update(VacationPeriod vacationPeriod)
        {
            vacationPeriodRepository.Update(vacationPeriod);
            return true;
        }


        public void Create(VacationPeriod entity)
        {
            vacationPeriodRepository.Create(entity);
        }

        public List<VacationPeriod> FindAll()
        {
            return vacationPeriodRepository.FindAll();
        }
    }
}
