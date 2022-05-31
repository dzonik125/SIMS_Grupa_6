// File:    RoomService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:05:19
// Purpose: Definition of Class RoomService

using Model;
using Repository;
using SIMS.Model;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RoomService
    {


        //public RoomsCRUD roomsCrud = new RoomsCRUD();
        public AppointmentService appointmentService = new AppointmentService();

        public Room FindRoomById(int id)
        {
            return roomsCRUD.FindById(id);
        }

        public bool UpdateRoom(Room r)
        {
            roomsCRUD.Update(r);
            return true;
        }

        public bool DeleteRoomById(int id)
        {
            roomsCRUD.DeleteById(id);
            return true;
        }

        public bool DeleteAllRooms()
        {
            throw new NotImplementedException();
        }

        public bool AddRoom(Room room)
        {
            roomsCRUD.Create(room);
            return true;
        }

        public List<Room> FindAll()
        {
            return roomsCRUD.FindAll();
        }



        public List<Room> getRoomsByType(RoomType type)
        {
            return roomsCRUD.getRoomsByType(type);
        }

        public bool StorageExist(Room room)
        {
            List<Room> rooms = new List<Room>();
            rooms = roomsCRUD.FindAll();
            if (CheckIfWarehouse(room, rooms)) return true;
            return false;
        }

        private static bool CheckIfWarehouse(Room room, List<Room> rooms)
        {
            if (Conversion.RoomTypeToString(room.roomType).Equals("Magacin"))
            {
                if (FindWarehouse(rooms)) return true;
            }

            return false;
        }

        private static bool FindWarehouse(List<Room> rooms)
        {
            bool exists = false;
            foreach (Room r in rooms)
            {
                if (Conversion.RoomTypeToString(r.roomType).Equals("Magacin"))
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        public Room findFreeRoom(DateTime dt)
        {

            bool roomIsFree = false;

            List<Room> rooms = roomsCRUD.FindAll();

            foreach (Room r in rooms)
            {
                Room temp = new();
                temp = r;
                temp.appointment = new AppointmentRepository().FindByRoomId(r.id);
                if (temp.appointment.Count == 0)
                {
                    roomIsFree = true;
                }

                if (temp.roomType != RoomType.examination)
                {
                    continue;
                }

                foreach (Appointment app in temp.appointment)
                {


                    if (!(app.startTime.AddMinutes(app.duration) <= dt && app.startTime <= dt || (dt.AddMinutes(30) <= app.startTime && dt <= app.startTime)))
                    {
                        roomIsFree = false;
                    }
                    else
                    {
                        roomIsFree = true;
                    }
                }

                if (roomIsFree)
                {
                    return r;
                }
            }
            return null;
        }

        internal int GetRoomIdByStorage(RoomType storage)
        {
            int idRoom = 0;
            foreach (Room r in FindAll())
            {
                if (Conversion.RoomTypeToString(r.roomType).Equals(Conversion.RoomTypeToString(storage)))
                {
                    idRoom =  r.id;
                }
            }
            return idRoom;
        }

        public int FindRoomId(int floor, int roomNum)
        {
            int roomId = 0;
            foreach (Room r in FindAll())
            {
                if (r.floor == floor && r.roomNum == roomNum)
                {
                    roomId = r.id;
                }
            }
            return roomId;

        }

        public int FindRoomFloorByRoomId(int roomId1)
        {
            int roomFloor = 0;
            foreach (Room r in FindAll())
            {
                if (r.id == roomId1)
                {
                    roomFloor = r.floor;
                }
            }
            return roomFloor;

        }

        public bool FindRoomByFloor(int roomNum, int floor)
        {
            if (roomsCRUD.FindRoomByFloor(roomNum, floor))
            {
                return true;
            }
            return false;
        }

        public int FindSmallerRoomNumber(int room1Id, int room2Id)
        {
            Room room1 = FindRoomById(room1Id);
            Room room2 = FindRoomById(room2Id);
            int smallerRoomNum = room2.roomNum;
            if (room1.roomNum < room2.roomNum)
            {
                smallerRoomNum = room1.roomNum;
            }
            return smallerRoomNum;

        }


        public List<Room> GetAvailableRooms(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public String GetRoomTypeById(int id)
        {
            string roomType = "";
            foreach (Room r in FindAll())
            {
                if (r.id == id)
                {
                   roomType = Conversion.RoomTypeToString(r.roomType);
                }
            }
            return roomType;
        }

        public Appointment getAppointmentWithRoom(Appointment appointment, DateRange dateRange)
        {

            List<Room> rooms = getRoomsByType(dateRange.type);
            foreach (Room r in rooms)
            {
                if (!checkIfRoomIsBusy(r, dateRange))
                {
                    appointment.Room = r;
                    return appointment;
                }
            }
            return null;
        }

       /* public void findRoomForAppointment(Appointment appointment, DateRange dateRange, List<Appointment> returnAppointmets)
        {
            Appointment a = new Appointment();
            List<Room> rooms = FindAll();
            foreach (Room r in rooms)
            {
                if (!checkIfRoomIsBusy(r, dateRange))
                {
                    a.Room = r;
                    a.startTime = dateRange.startTime;
                    a.Doctor = appointment.Doctor;
                    returnAppointmets.Add(a);
                    break;
                }
            }
        }
*/
        public bool checkIfRoomIsBusy(Room r, DateRange dateRange)
        {
            AppointmentService appointmentService = new AppointmentService();
            List<Appointment> appointments = appointmentService.getAppointmentsByRoomId(r.id);
            foreach (Appointment a in appointments)
            {
                if (dateRange.checkForIntersection(a.startTime, a.duration))
                    return true;
            }
            return false;
        }

        public Repository.RoomsCRUD roomsCRUD = new Repository.RoomsCRUD();


    }
}