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

        


        public void bindRoomsWithAppointments(List<Room> rooms, List<Appointment> appointments)
        {
            foreach (Room r in rooms)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.Room.id == r.id)
                    {
                        a.Room = r;
                    }
                }
            }

        }

        public void bindDoctorsWithAppointments(List<Doctor> doctors, List<Appointment> appointments)
        {
            foreach (Doctor d in doctors)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.Doctor.id == d.id)
                    {
                        a.Doctor = d;
                    }
                }
            }
        }

        public void bindPatientsWithAppointments(List<Patient> patients, List<Appointment> appointments)
        {
            foreach (Patient p in patients)
            {
                foreach (Appointment a in appointments)
                {
                    if (a.patient.id == p.id)
                    {
                        a.patient = p;
                    }

                }
            }
        }

        public bool isRoomOccupied(Room roomDestination, DateTime transferDate, int duration)
        {
            List<Appointment> roomAppointments = getAppointmentsByRoomId(roomDestination.id);
            foreach (Appointment a in roomAppointments)
            {
                if (!((a.startTime.AddMinutes(a.duration) < transferDate && a.startTime < transferDate || (transferDate.AddMinutes(duration) < a.startTime && transferDate < a.startTime))))
                {
                    return true;
                }
            }
            return false;
        }

        

        public List<Appointment> getFutureAppointmentsForDoctor(int id)
        {
            
            List<Appointment> potentialAppointments = GetAllApointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment a in potentialAppointments)
            {
                if (a.Doctor.id == id)
                {
                    if (a.startTime.AddMinutes(a.duration) >= DateTime.Now)
                    {

                        futureAppointments.Add(a);

                    }
                }
            }
            return futureAppointments;
        }

        


        public Boolean IsExist(int id)
        {
            Appointment a = appointmentRepository.FindById(id);
            if (a == null)
            {
                return false;
            }
            return true;
        }


        public List<DateTime> getTenNextFreeAppointmentsForDoctorToday(int id)
        {
            DateTime toCheck = DateTime.Now.AddMinutes(60 - DateTime.Now.Minute);
            DateTime finish = DateTime.Today.AddHours(8).AddMinutes(30);
            List<Appointment> apps = getAppointmentsByDoctorId(id);
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
            List<Appointment> apps = getAppointmentsByDoctorId(id);
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
        
       /* public List<Appointment> getFreeTermsForUrgentSurgery(Specialization spec, DateRange dateRange, Patient p)
        {
            dateRange.startTime = DateTime.Now.AddMinutes(30);

            if(findFreeTermsForReferral(spec, dateRange, p) == null) 
            {
                for appointment in futureappointments
                    getRescheduleTimeDifference
            }
        }*/


        //public Appointment getTermForUrgent


        public List<Appointment> getAppointmentsForDoctors(List<Doctor> doctors)
        {
            List<Appointment> returnAppointments = new();
            foreach(Doctor d in doctors)
            {
                List<Appointment> appointmentsForDoctor = getAppointmentsByDoctorId(d.id);
                returnAppointments.AddRange(appointmentsForDoctor);
            }
            return returnAppointments;
        }



        public Appointment getFirstFreeAppointment(Specialization spec, Patient p)
        {
            DateRange dateRange = new DateRange();
            dateRange.startTime = DateTime.Now.AddHours(0);
            dateRange.endTime = DateTime.Now.AddHours(2);
            List<Appointment> freeAppointments = findFreeTermsForReferral(spec, dateRange, p);
            if(freeAppointments.Count > 0)
            {
                return freeAppointments[0];
            }
            return null;
        }

        public Appointment getFirstFuture(List<Appointment> apps)
        {
            Appointment forReturn = new Appointment();
            foreach (Appointment appointment in apps)
            {
                if (appointment.startTime.CompareTo(DateTime.Now.AddHours(2)) < 0)
                {
                    return appointment;
                }

            }
            return null;
        }

        public void SaveBusyAppointment(Appointment a, Patient p, Specialization spec)
        {
            Appointment appointment = new Appointment();
            //a.patient;
            //appointmentRepository.Create();



            Appointment app = new Appointment();
            app = a;
            app.patient = p;
            appointmentRepository.Update(app);
            appointment = findFreeAppointmentForPatient(p, spec);
            appointment.patient = p;
            appointment.duration = 30;
            appointmentRepository.Create(appointment);
        }

        public Appointment findFreeAppointmentForPatient(Patient p, Specialization spec)
        {
            DateRange dateRange = new DateRange();
            dateRange.startTime = DateTime.Now;
            dateRange.endTime = DateTime.Now.AddDays(3);
            dateRange.duration = 30;
            List<Appointment> appointments = findFreeTermsForReferral(spec, dateRange, p);
            return appointments[0];
        }



        public List<Appointment> findFreeTermsForReferral(Specialization spec, DateRange dateRange, Patient patient)
        {
            List<Appointment> returnAppointments = new();
            List<Doctor> doctors = doctorRepository.findBySpecialization(spec);
            List<Appointment> doctorsAppointments = getAppointmentsForDoctors(doctors);
            List<Appointment> patientAppointments = GetAllAppointmentsForPatient(patient.id);
            doctorsAppointments.AddRange(patientAppointments);
            findFreeTerms(doctorsAppointments, dateRange, returnAppointments);
            return returnAppointments;
        }

        public List<Appointment> findFreeTerms(List<Appointment> doctorsAppointments, DateRange dateRange, List<Appointment> returnAppointments)
        {
            dateRange.startTime = dateRange.startTime.AddHours(7); //ovo mozes i pre svih funcija povecati
            while(dateRange.startTime < dateRange.endTime)
            {
                addPotentialAppointment(doctorsAppointments, dateRange, returnAppointments);
                dateRange.startTime = dateRange.startTime.AddMinutes(30);
                if (dateRange.startTime.Hour == 20)
                    dateRange.startTime = dateRange.startTime.AddHours(12);

            }
            return returnAppointments;
        }

        public void addPotentialAppointment(List<Appointment> doctorsAppointments, DateRange dateRange, List<Appointment> returnAppoinments)
        {
           RoomService roomService = new RoomService();
           Appointment firstAppointment = doctorsAppointments[0];
           Appointment lastAppointment = doctorsAppointments[doctorsAppointments.Count - 1];
           if (dateRange.startTime.AddMinutes(30) <= firstAppointment.startTime)
                roomService.findRoomForAppointment(firstAppointment, dateRange, returnAppoinments);
            else if (dateRange.startTime >= lastAppointment.startTime.AddMinutes(lastAppointment.duration))
               roomService.findRoomForAppointment(lastAppointment, dateRange, returnAppoinments);
            else getAppoinmentsBetweenScheduled(doctorsAppointments, dateRange, returnAppoinments);

        }

        public void getAppoinmentsBetweenScheduled(List<Appointment> doctorsAppointments, DateRange dateRange, List<Appointment> returnAppoinments)
        {
            RoomService roomService = new RoomService();
            for(int i = 0; i < doctorsAppointments.Count - 1; i++)
            {
                if (dateRange.checkIfBetween(doctorsAppointments[i].startTime.AddMinutes(doctorsAppointments[i].duration), doctorsAppointments[i + 1].startTime))
                    roomService.findRoomForAppointment(doctorsAppointments[i], dateRange, returnAppoinments);
                
            }

        }

        

        public string getFirstFreeAppointment(DateTime? start, DateTime? end)
        {
            List<Appointment> apps = GetAllApointments();
            List<Doctor> docs = ds.GetAllDoctors();
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

                List<Appointment> dapps = getAppointmentsByDoctorId(d.id);
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

        //  public List<DateTime> GetAppointmentBySpecialization(DateTime? start, DateTime? end, int id, Specialization s)
        //  {

        //     List<Doctor> docs = getDoctorBySpecialization(s);

        //     return;
        //  }

        public List<DateTime> getTenNextAppointmentsForDoctorForDate(DateTime? start, DateTime? end, int id)
        {
            DateTime toCheck = start.Value.AddHours(8);
            DateTime finish = toCheck.AddMinutes(30);
            List<Appointment> apps = getAppointmentsByDoctorId(id);
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
            List<Doctor> docs = ds.GetAllDoctors();
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
                List<Appointment> dapps = getAppointmentsByDoctorId(d.id);
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

        public List<Appointment> GetAllAppointmentsForPatient(int id)
        {
            List<Appointment> toRet = new List<Appointment>();
            List<Appointment> apps = GetAllApointments();
            foreach (Appointment a in apps)
            {
                if (a.patient.id == id)
                {
                    toRet.Add(a);
                }
            }

            return toRet;
        }

        public List<Appointment> getFutureAppointmentsForPatient(int id)
        {
            List<Appointment> potentialAppointments = GetAllApointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment a in potentialAppointments)
            {
                if (a.patient.id == id)
                {
                    if (a.startTime >= DateTime.Now)
                    {

                        futureAppointments.Add(a);

                    }

                }



            }

            return futureAppointments;

        }

        public List<Appointment> getAppointmentsByDoctorId(int doctorID)
        {
            return appointmentRepository.FindByDoctorId(doctorID);
        }

        public List<Appointment> getAppointmentsByPatientId(int patientID)
        {
            return appointmentRepository.FindByPatientId(patientID);
        }

        public List<Appointment> getAppointmentsByRoomId(int roomID)
        {
            return appointmentRepository.FindByRoomId(roomID);
        }

        public List<Appointment> getAppointmentBySpecialization(Specialization s)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            List<Doctor> doctorList = new List<Doctor>();
            doctorList = ds.GetAllDoctors();
            foreach (Doctor d in doctorList)
            {
                if (d.specialization.Equals(s))
                {
                    appointmentList = getAppointmentsByDoctorId(d.id);
                }
            }
            return appointmentList;
        }


        public List<Doctor> getDoctorBySpecialization(Specialization specialization)
        {
            List<Doctor> doctors = new();
            List<Doctor> doctorSpec = new();
            doctors = doctorRepository.FindAll();
            foreach (Doctor d in doctors)
            {
                if (d.Specialization.Equals(specialization))
                {
                    doctorSpec.Add(d);
                }
            }
            return doctorSpec;

        }


        public Appointment findPatientAppointment(Patient p)
        {
            List<Appointment> appointments = getAppointmentsByPatientId(p.id);
            foreach (Appointment a in appointments)
            {
                if (a.startTime <= DateTime.Now && a.startTime.AddMinutes(a.duration) >= DateTime.Now)
                {
                    return a;
                }
            }
            return null;
        }

        public bool IntersectionWithAppointments(int patientID, int doctorID, int roomID, DateTime date, int duration)
        {
            List<Appointment> doctorAppointments = getAppointmentsByDoctorId(doctorID);
            List<Appointment> roomAppointments = getAppointmentsByRoomId(roomID);
            List<Appointment> patientAppointments = getAppointmentsByPatientId(patientID);

            foreach (Appointment a in doctorAppointments)
            {
                if (!((a.startTime.AddMinutes(a.duration) < date && a.startTime < date || (date.AddMinutes(duration) < a.startTime && date < a.startTime))))
                {
                    return true;
                }
            }
            foreach (Appointment a in roomAppointments)
            {
                if (!((a.startTime.AddMinutes(a.duration) < date && a.startTime < date || (date.AddMinutes(duration) < a.startTime && date < a.startTime))))
                {
                    return true;
                }
            }
            foreach (Appointment a in patientAppointments)
            {
                if (!((a.startTime.AddMinutes(a.duration) < date && a.startTime < date || (date.AddMinutes(duration) < a.startTime && date < a.startTime))))
                {
                    return true;
                }
            }

            return false;
        }




        public Appointment GetAppointmentByID(string id)
        {
            throw new NotImplementedException();
        }


        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public DoctorRepository doctorRepository = new DoctorRepository();
        //public RoomService rs = new RoomService();
        public DoctorService ds = new DoctorService();
        public DoctorService doctorService = new DoctorService();
    }
}