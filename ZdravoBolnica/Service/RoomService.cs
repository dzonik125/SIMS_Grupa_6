// File:    RoomService.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:05:19
// Purpose: Definition of Class RoomService

using System;
using System.Collections.Generic;
using Model;
using Repository;

namespace Service
{
   public class RoomService
   {

        public RoomsCRUD roomsCrud = new RoomsCRUD();

      public Room FindRoomById(string id)
      {
         throw new NotImplementedException();
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

        public Room findFreeRoom()
        {
            List<Room> rooms = roomsCRUD.FindAll();
            foreach (Room r in rooms)
            {
                if (r.appointment == null)
                {
                    return r;
                }


            }
            return null;
        }

        public List<Room> GetAvailableRooms(DateTime startTime, DateTime endTime)
      {
         throw new NotImplementedException();
      }
      
      public Repository.RoomsCRUD roomsCRUD = new Repository.RoomsCRUD();
   
   }
}