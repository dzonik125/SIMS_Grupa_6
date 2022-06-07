// File:    AppointmentService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:38:26
// Purpose: Definition of Class AppointmentService

using Model;
using Repository;
using SIMS.Model;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using SIMS;

namespace Service
{
    public class AppointmentService
    {
        public PatientService patientService = new PatientService();

        public Scheduler dateRange = new Scheduler();
        public Appointment newAppointment = new Appointment();
        public Appointment appointmentForUpdate = new Appointment();

        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public DoctorService doctorService = new DoctorService();


        public List<Appointment> GetAllApointments()
        {
            return appointmentRepository.FindAll();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            appointmentRepository.Update(appointment);
        }

        public void DeleteAppointmentById(int id)
        {
            appointmentRepository.DeleteById(id);
        }

        public void SaveAppointment(Appointment appointment)
        {
            appointmentRepository.Create(appointment);
        }
        
        public void BindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments)
        {
            foreach (Room room in rooms)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.room.id == r.id)
                        a.room = r;
                }
            }
        }

        public void BindDoctorsWithAppointments(List<Doctor> doctors, List<Appointment> appointments)
        {
            foreach (Doctor doctor in doctors)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (a.doctor.id == d.id)
                        a.doctor = d;
                }
            }
        }

        public void BindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            foreach (Patient patient in patients)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.patient.id == patient.id)
                        appointment.patient = patient;
                }
            }
        }

        public bool IsRoomOccupied(Room roomDestination, DateTime transferDate, int duration)
        {
            List<Appointment> roomAppointments = GetAppointmentsByRoomId(roomDestination.id);
            foreach (Appointment appointment in roomAppointments)
            {
                if (!((appointment.startTime.AddMinutes(appointment.duration) < transferDate && appointment.startTime < transferDate
                    || (transferDate.AddMinutes(duration) < appointment.startTime && transferDate < appointment.startTime))))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Appointment> GetFutureAppointmentsForDoctor(int id)
        {
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllApointments())
            {
                if (a.doctor.id == id)
                {
                    if (appointment.startTime.AddMinutes(appointment.duration) >= DateTime.Now)
                        futureAppointments.Add(appointment);
                }
            }
            return futureAppointments;
        }

        public List<DateTime> GetTenNextFreeAppointmentsForDoctor(int id)
        {
            DateTime toCheck = DateTime.Today.AddHours(32);
            DateTime finish = DateTime.Today.AddHours(32).AddMinutes(30);
            List<Appointment> apps = GetAppointmentsByDoctorId(id);
            List<DateTime> toReturn = new List<DateTime>();
            int counter = 0;
            bool dontAdd = false;

            do
            {

                dontAdd = false;

                if (finish.Hour == 20 && finish.Minute == 30)
                {
                    toCheck = toCheck.AddHours(12);
                    finish = finish.AddHours(12);
                    continue;
                }

                //if (rs.findFreeRoom(toCheck) == null)
                //{
                //    toCheck = toCheck.AddMinutes(30);
                //    finish = finish.AddMinutes(30);
                //    continue;
                //}

                foreach (Appointment a in apps)
                {
                    if ((a.startTime > toCheck) && (a.startTime < finish))
                    {
                        dontAdd = true;
                        break;
                    }

                    if (a.startTime == toCheck)
                    {
                        dontAdd = true;
                        break;
                    }
                }

                if (dontAdd)
                {

                    toCheck = toCheck.AddMinutes(30);
                    finish = finish.AddMinutes(30);
                    continue;

                }

                toReturn.Add(toCheck);
                counter++;
                toCheck = toCheck.AddMinutes(30);
                finish = finish.AddMinutes(30);

            } while (counter != 10);

            return toReturn;
        }
      
        public List<Appointment> GetAppointmentsForDoctors(List<Doctor> doctors)
        {
            List<Appointment> returnAppointments = new();
            foreach (Doctor doctor in doctors)
            {
                List<Appointment> appointmentsForDoctor = GetAppointmentsByDoctorId(doctor.id);
                returnAppointments.AddRange(appointmentsForDoctor);
            }
            return returnAppointments;
        }

        public Appointment GetFirstFreeAppointmentInOneHour(DateRange dateRange, Patient patient)
        {
            Appointment firstFree = new Appointment();
            List<Appointment> freeAppointments = FindFreeTermsForReferral(dateRange, patient);
            if (freeAppointments.Count > 0)

                if (freeAppointments.Count > 0)
                {
                    firstFree = freeAppointments[0];
                }
            return firstFree;
        }

        public Appointment GetFirstAppointmentForDoctor(List<Appointment> apps)
        {
            Appointment firstFreeAppointment = new Appointment();
            foreach (Appointment appointment in apps)
            {
                if ((appointment.startTime.CompareTo(DateTime.Now.AddHours(2)) < 0) && appointment.startTime > DateTime.Now)
                    firstFreeAppointment = appointment;
            }
            return firstFreeAppointment;
        }

        public void SaveBusyAppointment(Appointment appointment, Specialization specialization)
        {
            Appointment newAppointment = new Appointment();
            newAppointment = FindFreeAppointmentForPatient(appointment.patient, specialization);
            newAppointment.patient = patientService.FindPatientById(appointment.patient.id);
            newAppointment.duration = 30;
            appointmentRepository.Create(newAppointment);
            UpdateBusyAppointment(appointment);
        }

        private void UpdateBusyAppointment(Appointment busyAppointment)
        {
            Appointment appointmentForUpdate = new Appointment();
            appointmentForUpdate = busyAppointment;
            appointmentForUpdate.patient = busyAppointment.patient;
            appointmentRepository.Update(appointmentForUpdate);
        }

        public Appointment FindFreeAppointmentForPatient(Patient patient, Specialization specialization)
        {
            DateRange dateRange = new DateRange();
            dateRange.startTime = DateTime.Now;
            dateRange.endTime = DateTime.Now.AddDays(3);
            dateRange.duration = 30;
            dateRange.specializationType = specialization;
            dateRange.roomType = RoomType.examination;

            List<Appointment> appointments = FindFreeTermsForReferral(dateRange, patient);
            return appointments[0];
        }

        public List<Appointment> FindFreeTermsForReferral(DateRange dateRange, Patient patient)
        {
            List<Appointment> patientAppointments = GetAllAppointmentsForPatient(patient.id);
            return FindFreeTerms(patientAppointments, dateRange);
        }

        public List<Appointment> FindFreeTerms(List<Appointment> patientAppointments, DateRange dateRange)
        {
            List<Appointment> potentialAppointments = new();
            while (dateRange.startTime < dateRange.endTime)
            {
                if (!OverlapsWithPatientAppointments(patientAppointments, dateRange))
                {
                    Appointment potentialAppointment = new();
                    if (CheckForRoomAndDoctorForAppointment(potentialAppointment, dateRange))
                        potentialAppointments.Add(potentialAppointment);
                }
                dateRange.step();
            }
            return potentialAppointments;
        }

        public bool OverlapsWithPatientAppointments(List<Appointment> patientAppointments, DateRange dateRange)
        {
            bool overlapExists = false;
            foreach (Appointment appointment in patientAppointments)
            {
                if (dateRange.checkForIntersection(appointment.startTime, appointment.duration))
                    overlapExists = true;
            }
            return overlapExists;
        }

        private bool CheckForRoomAndDoctorForAppointment(Appointment potentialAppointment, DateRange dateRange)
        {
            RoomService roomService = new RoomService();
            potentialAppointment.startTime = dateRange.startTime;
            bool foundRoomAndDoctorForAppointment = false;
            if (roomService.freeRoomExistsForAppointment(potentialAppointment, dateRange)
                && doctorService.freeDoctorExistsForAppointment(potentialAppointment, dateRange))
                foundRoomAndDoctorForAppointment = true;
            return foundRoomAndDoctorForAppointment;
        }

        public string GetFirstFreeAppointment(DateTime? start, DateTime? end)
        {
            List<Appointment> apps = GetAllApointments();
            List<Doctor> docs = doctorService.GetAllDoctors();
            bool cont = true;
            DateTime startToUse = (DateTime)start;
            DateTime min = startToUse.AddHours(21);
            DateTime finish = startToUse.AddMinutes(30);
            bool dontAdd = false;
            int id = 0;
            foreach (Doctor d in docs)
            {
                startToUse = (DateTime)start;
                startToUse = startToUse.AddHours(8);
                finish = startToUse.AddMinutes(30);

                List<Appointment> dapps = GetAppointmentsByDoctorId(d.id);
                do
                {
                    dontAdd = false;
                    if (finish.Hour == 20 && finish.Minute == 30)
                    {

                        if (start == end)
                        {
                            break;
                        }

                        if (finish.Date == end.Value.Date)
                        {
                            break;
                        }

                        startToUse = startToUse.AddHours(12);
                        finish = finish.AddHours(12);
                        continue;
                    }

                    foreach (Appointment a in dapps)
                    {
                        //if ((a.startTime > startToUse) && (a.startTime < finish))
                        //{
                        //    dontAdd = true;
                        //    break;
                        //}

                        if (a.startTime == startToUse)
                        {
                            dontAdd = true;
                            break;
                        }
                    }


                    if (dontAdd)
                    {

                        startToUse = startToUse.AddMinutes(30);
                        finish = finish.AddMinutes(30);
                        continue;

                    }

                    if (min >= startToUse)
                    {
                        min = startToUse;
                        id = d.id;
                        startToUse = startToUse.AddMinutes(30);
                        finish = finish.AddMinutes(30);
                    }

                    startToUse = startToUse.AddMinutes(30);
                    finish = finish.AddMinutes(30);

                } while (cont);
            }

            String convMin = min.ToString();
            String convID = id.ToString();
            String toReturn = convMin + "=" + convID;
            return toReturn;

        }

        public List<DateTime> GetTenNextAppointmentsForDoctorForDate(DateTime? start, DateTime? end, int id)
        {
            DateTime toCheck = start.Value.AddHours(8);
            DateTime finish = toCheck.AddMinutes(30);
            List<Appointment> apps = GetAppointmentsByDoctorId(id);
            List<DateTime> toReturn = new List<DateTime>();
            int counter = 0;
            bool dontAdd = false;

            do
            {

                dontAdd = false;

                if (finish.Hour == 20 && finish.Minute == 30)
                {

                    if (start == end)
                    {
                        break;
                    }

                    if (finish.Date == end.Value.Date)
                    {
                        break;
                    }

                    toCheck = toCheck.AddHours(12);
                    finish = finish.AddHours(12);
                    continue;
                }

                //if (rs.findFreeRoom(toCheck) == null)
                //{
                //    toCheck = toCheck.AddMinutes(30);
                //    finish = finish.AddMinutes(30);
                //    continue;
                //}

                foreach (Appointment a in apps)
                {
                    if ((a.startTime > toCheck) && (a.startTime < finish))
                    {
                        dontAdd = true;
                        break;
                    }

                    if (a.startTime == toCheck)
                    {
                        dontAdd = true;
                        break;
                    }
                }

                if (dontAdd)
                {

                    toCheck = toCheck.AddMinutes(30);
                    finish = finish.AddMinutes(30);
                    continue;

                }

                toReturn.Add(toCheck);
                counter++;
                toCheck = toCheck.AddMinutes(30);
                finish = finish.AddMinutes(30);

            } while (counter != 10);

            return toReturn;
        }

        public List<String> GetFirstFiveFreeApointmentsForDate(DateTime? start, DateTime? end)
        {
            List<Appointment> apps = GetAllApointments();
            List<Doctor> docs = doctorService.GetAllDoctors();
            bool cont = true;
            DateTime startToUse = (DateTime)start;
            startToUse = startToUse.AddHours(8);
            DateTime finish = startToUse.AddMinutes(30);
            bool dontAdd = false;
            List<String> potentialTimes = new List<String>();
            int id = 0;
            foreach (Doctor d in docs)
            {
                startToUse = (DateTime)start;
                startToUse = startToUse.AddHours(8);
                finish = startToUse.AddMinutes(30);
                List<Appointment> dapps = GetAppointmentsByDoctorId(d.id);
                do
                {
                    dontAdd = false;
                    if (finish.Hour == 20 && finish.Minute == 30)
                    {

                        if (start == end)
                        {
                            break;
                        }

                        if (finish.Date == end.Value.Date)
                        {
                            break;
                        }

                        startToUse = startToUse.AddHours(12);
                        finish = finish.AddHours(12);
                        continue;
                    }

                    foreach (Appointment a in dapps)
                    {
                        if ((a.startTime > startToUse) && (a.startTime < finish))
                        {
                            dontAdd = true;
                            break;
                        }

                        if (a.startTime == startToUse)
                        {
                            dontAdd = true;
                            break;
                        }
                    }

                    if (dontAdd)
                    {

                        startToUse = startToUse.AddMinutes(30);
                        finish = finish.AddMinutes(30);
                        continue;

                    }


                    id = d.id;
                    String toAdd = startToUse.ToString() + " " + id.ToString();
                    potentialTimes.Add(toAdd);
                    startToUse = startToUse.AddMinutes(30);
                    finish = finish.AddMinutes(30);

                } while (cont);

            }

            potentialTimes = potentialTimes.OrderBy(ele => DateTime.Parse(ele.Split(' ')[0] + " " + ele.Split(' ')[1] + " " + ele.Split(' ')[2])).ToList();
            List<String> toRet = new List<string>();
            if (potentialTimes.Count < 5)
            {
                for (int i = 0; i < potentialTimes.Count; i++)
                {
                    toRet.Add(potentialTimes.ElementAt(i));
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    toRet.Add(potentialTimes.ElementAt(i));
                }

            }



            return toRet;
        }


        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return appointmentRepository.FindByDoctorId(doctorId);
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return appointmentRepository.FindByPatientId(patientId);
        }

        public List<Appointment> GetAppointmentsByRoomId(int roomId)
        {
            return appointmentRepository.FindByRoomId(roomId);
        }

        public Appointment FindPatientAppointment(Patient patient)
        {
            Appointment patientAppointment = new();
            foreach (Appointment appointment in GetAppointmentsByPatientId(p.id))
            {
                if (appointment.startTime <= DateTime.Now && appointment.startTime.AddMinutes(appointment.duration) >= DateTime.Now)
                    patientAppointment = appointment;
            }
            return patientAppointment;
        }

    }
}