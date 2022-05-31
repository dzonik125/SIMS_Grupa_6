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
            if (CheckIfWarehouse(room, rooms)) return true;
            return false;
        }

        private static bool CheckIfWarehouse(Room room, List<Room> rooms)
        {
            bool exists = false;
            if (Conversion.RoomTypeToString(room.roomType).Equals("Magacin"))
            {
                if (FindWarehouse(rooms)) exists = true;
            }

            return exists;
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
            Room room = null;
            room = FindIfFreeRoomExists(dt, roomIsFree);
            return room;
        }

        private Room FindIfFreeRoomExists(DateTime dt, bool roomIsFree)
        {
            Room room = null;
            foreach (Room r in roomsCRUD.FindAll())
            {
                var temp = TemporaryRoom(r);
                roomIsFree = RoomIsFree(temp, roomIsFree);
                if (temp.roomType != RoomType.examination)
                {
                    continue;
                }
                roomIsFree = CheckAppointmentDurationInRoom(dt, temp);
                room = CheckIfRoomIsFree(roomIsFree, r);
            }
            return room;
        }

        private static Room CheckIfRoomIsFree(bool roomIsFree, Room r)
        {
            Room room = null;
            if (roomIsFree)
            {
                room = r;
            }
            return room;
        }

        private static bool CheckAppointmentDurationInRoom(DateTime dt, Room temp)
        {
            bool roomIsFree = false;
            foreach (Appointment app in temp.appointment)
            {
                roomIsFree = CompareIfAppointmentsAreInTheSameTime(dt, app);
            }

            return roomIsFree;
        }

        private static bool CompareIfAppointmentsAreInTheSameTime(DateTime dt, Appointment app)
        {
            bool roomIsFree = true;
            if (!(app.startTime.AddMinutes(app.duration) <= dt && app.startTime <= dt || (dt.AddMinutes(30) <= app.startTime && dt <= app.startTime)))
            {
                roomIsFree = false;
            }
            return roomIsFree;
        }

        private static Room TemporaryRoom(Room r)
        {
            Room temp = new();
            temp = r;
            temp.appointment = new AppointmentRepository().FindByRoomId(r.id);
            return temp;
        }

        private static bool RoomIsFree(Room temp, bool roomIsFree)
        {
            if (temp.appointment.Count == 0)
            {
                roomIsFree = true;
            }
            return roomIsFree;
        }

        public int GetRoomIdByStorage(RoomType storage)
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
            foreach (Room r in getRoomsByType(dateRange.type))
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
                     appointment.Room = r;
                     return appointment;
                 }
             }
             return null;
         }
 */
        public bool checkIfRoomIsBusy(Room r, DateRange dateRange)
        {
            bool roomIsBusy = false;
            AppointmentService appointmentService = new AppointmentService();
            foreach (Appointment a in appointmentService.getAppointmentsByRoomId(r.id))
            {
                if (dateRange.checkForIntersection(a.startTime, a.duration))
                    roomIsBusy = true;
            }
            return roomIsBusy;
        }


        public Repository.RoomsCRUD roomsCRUD = new Repository.RoomsCRUD();


    }
}