// File:    RoomService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:05:19
// Purpose: Definition of Class RoomService

using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Model;
using Repository;

namespace Service
{
   public class RoomService
   {
        

        public RoomsCRUD roomsCrud = new RoomsCRUD();
        public AppointmentService appointmentService = new AppointmentService();

      public Room FindRoomById(string id)
      {
          return roomsCRUD.FindById(id);
      }
      
      public bool UpdateRoom(Room r)
      {
            roomsCRUD.Update(r);
            return true;
      }
      
      public bool DeleteRoomById(string id)
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
                    

                    if (!(app.startTime.AddMinutes(app.duration) < dt && app.startTime < dt || (dt.AddMinutes(30) < app.startTime && dt < app.startTime)))
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

        public bool FindRoomByFloor(int roomNum, int floor)
        {
            if (roomsCRUD.FindRoomByFloor(roomNum, floor))
            {
                return true;
            }
            return false;
        }


        public List<Room> GetAvailableRooms(DateTime startTime, DateTime endTime)
      {
         throw new NotImplementedException();
      }
      
      public Repository.RoomsCRUD roomsCRUD = new Repository.RoomsCRUD();
      

   }
}