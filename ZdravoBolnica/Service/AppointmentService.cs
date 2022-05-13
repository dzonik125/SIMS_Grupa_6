// File:    AppointmentService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 17:38:26
// Purpose: Definition of Class AppointmentService

using Model;
using Repository;
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

        public List<Appointment> getFutureAppointmentsForPatient(string id)
        {
            List<Appointment> potentialAppointments = GetAllApointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach (Appointment a in potentialAppointments)
            {
                if (a.patient.id.Equals(id))
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
            /*
             List<Doctor> doctorList = new List<Doctor>();
             doctorList = getDoctorBySpecialization(s);
             foreach (Doctor d in doctorList)
             {
                 if (


                     )
             }
            */


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
    }
}