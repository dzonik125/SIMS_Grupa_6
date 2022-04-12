// File:    RoomsCRUD.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:38:41
// Purpose: Definition of Class RoomsCRUD

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class RoomsCRUD : Repository<Room, string>
    {

        private String filename = @".\..\..\..\Data\rooms.txt";
        private Serializer<Room> roomSerializer = new Serializer<Room>();
        public void Create(Room entity)
        {
            List<Room> rooms = new List<Room>();
            rooms = roomSerializer.fromCSV(filename);
            rooms.Add(entity);
            roomSerializer.toCSV(filename, rooms);

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            List<Room> rooms = FindAll();
            foreach (Room r in rooms)
            {
                if (r.id.Equals(id))
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

        public Room FindByAppointment(Appointment a)
        {
            throw new NotImplementedException();
        }

        public List<Room> FindByEquipment(Equipment e)
        {
            throw new NotImplementedException();
        }

        public Room FindById(string key)
        {
            List<Room> rooms = FindAll();
            foreach (Room r in rooms)
            {
                if (key.Equals(r.id))
                {
                    return r;
                }
            }

            return null;
        }

        public void Update(Room r)
        {
            List<Room> rooms = FindAll();
            foreach (Room rm in rooms)
            {
                if (rm.id.Equals(r.id))
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
    }
}