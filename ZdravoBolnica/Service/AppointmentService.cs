// File:    AppointmentService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:38:26
// Purpose: Definition of Class AppointmentService

using Model;
using Repository;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void UpdateAppointment(Appointment a)
        {
            appointmentRepository.Update(a);
        }

        public void DeleteAppointmentById(int id)
        {
            appointmentRepository.DeleteById(id);
        }

        public void SaveAppointment(Appointment a)
        {
            appointmentRepository.Create(a);
        }




        public void BindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments)
        {
            foreach (Room r in rooms)
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
            foreach (Doctor d in doctors)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.doctor.id == d.id)
                        a.doctor = d;
                }
            }
        }

        public void BindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            foreach (Patient p in patients)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.patient.id == p.id)
                        a.patient = p;
                }
            }
        }

        public bool IsRoomOccupied(Room roomDestination, DateTime transferDate, int duration)
        {
            List<Appointment> roomAppointments = GetAppointmentsByRoomId(roomDestination.id);
            foreach (Appointment a in roomAppointments)
            {
                if (!((a.startTime.AddMinutes(a.duration) < transferDate && a.startTime < transferDate 
                    || (transferDate.AddMinutes(duration) < a.startTime && transferDate < a.startTime))))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Appointment> GetFutureAppointmentsForDoctor(int id)
        {
            List<Appointment> potentialAppointments = GetAllApointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment a in potentialAppointments)
            {
                if (a.doctor.id == id)
                {
                    if (a.startTime.AddMinutes(a.duration) >= DateTime.Now)
                        futureAppointments.Add(a);
                }
            }
            return futureAppointments;
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

        public Appointment GetFirstFreeAppointmentInOneHour(Specialization spec, Patient p)
        {
            dateRange.startTime = DateTime.Now.AddHours(0);

            dateRange.endTime = DateTime.Now.AddHours(1);
            dateRange.specializationType = spec;
            dateRange.roomType = RoomType.examination;
            dateRange.duration = 30;
            List<Appointment> freeAppointments = FindFreeTermsForReferral(dateRange, p);
            if (freeAppointments.Count > 0)
                return freeAppointments[0];
            
            return null;
        }

        public Appointment GetFirstAppointmentForDoctor(List<Appointment> apps)
        {

            foreach (Appointment appointment in apps)
            {
                if ((appointment.startTime.CompareTo(DateTime.Now.AddHours(2)) < 0) && appointment.startTime > DateTime.Now)
                    return appointment;
            }
            return null;
        }

        public void SaveBusyAppointment(Appointment a, Patient p, Specialization spec)
        {

            newAppointment = FindFreeAppointmentForPatient(p, spec);
            newAppointment.patient = patientService.FindPatientById(a.patient.id);
            newAppointment.duration = 30;
            appointmentRepository.Create(newAppointment);

            appointmentForUpdate = a;
            appointmentForUpdate.patient = p;
            appointmentRepository.Update(appointmentForUpdate);

        }
        //nalazi prvi slobodan app
        public Appointment FindFreeAppointmentForPatient(Patient p, Specialization spec)
        {
            Scheduler scheduler = new Scheduler();
            scheduler.startTime = DateTime.Now;
            scheduler.endTime = DateTime.Now.AddDays(3);
            scheduler.duration = 30;
            scheduler.specializationType = spec;

            scheduler.roomType = RoomType.examination;

            List<Appointment> appointments = FindFreeTermsForReferral(scheduler, p);
            return appointments[0];
        }

        public List<Appointment> FindFreeTermsForReferral(Scheduler scheduler, Patient patient)
        {
            List<Appointment> patientAppointments = GetAllAppointmentsForPatient(patient.id);
            return FindFreeTerms(patientAppointments, scheduler);
        }


        public List<Appointment> FindFreeTerms(List<Appointment> patientAppointments, Scheduler scheduler)
        {
            List<Appointment> potentialAppointments = new();
            while (scheduler.startTime < scheduler.endTime)
            {
                if (!overlapsWithPatientAppointments(patientAppointments, scheduler))
                {
                    Appointment potentialAppointment = new();
                    if (checkForRoomAndDoctorForAppointment(potentialAppointment, scheduler))
                        potentialAppointments.Add(potentialAppointment);
                }
                scheduler.step();
            }
            return potentialAppointments;
        }


        public bool overlapsWithPatientAppointments(List<Appointment> patientAppointments, Scheduler scheduler)
        {
            bool overlapExists = false;
            foreach (Appointment a in patientAppointments)
            {
                if (scheduler.overlapsWithExistingTerm(a.startTime, a.duration))
                    overlapExists = true;
            }
            return overlapExists;
        }

        private bool checkForRoomAndDoctorForAppointment(Appointment potentialAppointment, Scheduler scheduler)
        {
            RoomService roomService = new RoomService();
            potentialAppointment.startTime = scheduler.startTime;
            bool foundRoomAndDoctorForAppointment = false;

            if (roomService.freeRoomExistsForAppointment(potentialAppointment, scheduler) 
                && doctorService.freeDoctorExistsForAppointment(potentialAppointment, scheduler))
                foundRoomAndDoctorForAppointment = true;
            return foundRoomAndDoctorForAppointment;
        }


        public List<Appointment> GetAllAppointmentsForPatient(int id)
        {
            List<Appointment> patientAppointments = new List<Appointment>();
            foreach (Appointment a in GetAllApointments())
            {
                if (a.patient.id == id)
                    patientAppointments.Add(a);
            }
            return patientAppointments;
        }

        public List<Appointment> GetFutureAppointmentsForPatient(int id)
        {
            List<Appointment> potentialAppointments = GetAllApointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment a in potentialAppointments)
            {
                if (a.patient.id == id)
                {
                    if (a.startTime >= DateTime.Now)
                        futureAppointments.Add(a);
                }

            }
            return futureAppointments;
        }

        public List<DateTime> getTenNextFreeAppointmentsForDoctorToday(int id)
        {
            DateTime toCheck = DateTime.Now.AddMinutes(60 - DateTime.Now.Minute);
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

            } while (counter != 4);

            return toReturn;
        }

        public List<DateTime> getTenNextFreeAppointmentsForDoctor(int id)
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

        public string getFirstFreeAppointment(DateTime? start, DateTime? end)
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

        public List<DateTime> getTenNextAppointmentsForDoctorForDate(DateTime? start, DateTime? end, int id)
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

        public List<String> getFirstFiveFreeApointmentsForDate(DateTime? start, DateTime? end)
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

        public Appointment FindPatientAppointment(Patient p)
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