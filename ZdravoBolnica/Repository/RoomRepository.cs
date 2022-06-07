// File:    RoomsCRUD.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:38:41
// Purpose: Definition of Class RoomsCRUD

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class RoomRepository : IRepository<Room, int>
    {

        private String filename = @".\..\..\..\Data\rooms.txt";
        private Serializer<Room> roomSerializer = new Serializer<Room>();
        public void Create(Room entity)
        {
            List<Room> rooms = new List<Room>();
            rooms = roomSerializer.fromCSV(filename);
            if (rooms.Count > 0)
            {
                entity.id = rooms[rooms.Count - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            rooms.Add(entity);
            roomSerializer.toCSV(filename, rooms);

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            List<Room> rooms = FindAll();
            foreach (Room r in rooms)
            {
                if (r.id == id)
                {
                    rooms.Remove(r);
                    break;
                }

            }
            roomSerializer.toCSV(filename, rooms);

        }


        public List<Room> FindAll()
        {
            return roomSerializer.fromCSV(filename);
        }


        public Room FindById(int key)
        {
            Room returnRoom = new();
            foreach (Room r in FindAll())
            {
                if (key == r.id)
                {
                    returnRoom = r;
                    break;
                }
                else
                    returnRoom = null;
            }

            return returnRoom;
        }

        public void Update(Room r)
        {
            List<Room> rooms = FindAll();
            foreach (Room rm in rooms)
            {
                if (rm.id == r.id)
                {
                    rm.floor = r.floor;
                    rm.roomNum = r.roomNum;
                    rm.roomType = r.roomType;
                }
            }
            roomSerializer.toCSV(filename, rooms);
        }

        public List<Room> getRoomsByType(RoomType type)
        {
            List<Room> rooms = FindAll();
            List<Room> roomsByType = new();
            foreach (Room r in rooms)
            {
                if (r.roomType == type)
                {
                    roomsByType.Add(r);
                }
            }
            return roomsByType;
        }



        public bool FindRoomByFloor(int roomNum, int floor)
        {

            List<Room> rooms = FindAll();
            List<Room> roomsByFloor = new();
            foreach (Room r in rooms)
            {
                if (r.floor == floor)
                {
                    roomsByFloor.Add(r);
                }

            }
            bool foundRoomByFloor = false;
            foreach (Room r in roomsByFloor)
            {
                if (r.roomNum == roomNum)
                {
                    foundRoomByFloor = true;
                }
            }
            return foundRoomByFloor;
        }

        public Room FindByAppointment(Appointment a)
        {
            throw new NotImplementedException();
        }

        public List<Room> FindByEquipment(Equipment e)
        {
            throw new NotImplementedException();
        }
    }
}