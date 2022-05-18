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
            if (Conversion.RoomTypeToString(room.roomType).Equals("Magacin"))
            {
                foreach (Room r in rooms)
                {

                    if (Conversion.RoomTypeToString(r.roomType).Equals("Magacin"))
                    {
                        return true;
                    }
                }
            }
            return false;
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
            List<Room> rooms = new List<Room>();
            rooms = FindAll();
            foreach (Room r in rooms)
            {
                if (Conversion.RoomTypeToString(r.roomType).Equals(Conversion.RoomTypeToString(storage)))
                {
                    return r.id;
                }
            }
            return 0;
        }

        public int FindRoomId(int floor, int roomNum)
        {
            List<Room> rooms = new List<Room>();
            rooms = roomsCRUD.FindAll();
            foreach (Room r in rooms)
            {
                if (r.floor == floor && r.roomNum == roomNum)
                {
                    return r.id;
                }
            }
            return 0;

        }

        public int FindRoomFloorByRoomId(int roomId1)
        {
            List<Room> rooms = new List<Room>();
            rooms = roomsCRUD.FindAll();
            foreach (Room r in rooms)
            {
                if (r.id == roomId1)
                {
                    return r.floor;
                }
            }
            return 0;

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
            Room room1 = new Room();
            room1 = FindRoomById(room1Id);
            Room room2 = new Room();
            room2 = FindRoomById(room2Id);
            if (room1.roomNum < room2.roomNum)
            {
                return room1.roomNum;
            }
            return room2.roomNum;

        }


        public List<Room> GetAvailableRooms(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public String GetRoomTypeById(int id)
        {
            List<Room> rooms = new List<Room>();
            rooms = FindAll();
            foreach (Room r in rooms)
            {
                if (r.id == id)
                {
                    return Conversion.RoomTypeToString(r.roomType);
                }
            }
            return "";
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

        public Appointment findRoomForAppointment(Appointment appointment, DateRange dateRange, List<Appointment> returnAppointmets)
        {
            Appointment a = new Appointment();
            List<Room> rooms = FindAll();
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