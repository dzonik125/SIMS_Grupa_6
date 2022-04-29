// File:    RoomController.cs
// Author:  dZoNi
// Created: Thursday, April 7, 2022 18:38:45
// Purpose: Definition of Class RoomController
using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
   public class RoomController
   {

      public RoomService rs = new RoomService();
      public Room FindRoomById(int id)
      {
         return rs.FindRoomById(id);
      }
      
      public bool UpdateRoom(Room r)
      {
            rs.UpdateRoom(r);
            return true;
      }
      
      public bool DeleteRoomById(int id)
      {
            rs.DeleteRoomById(id);
            return true;
      }
      
      public bool DeleteAllRooms()
      {
         throw new NotImplementedException();
      }
      
      public bool AddRoom(Room room)
      {
            roomService.AddRoom(room);
            return true;
      }
      
      public List<Room> FindAll()
      {
            return rs.FindAll();
      }
      
      public List<Room> GetAvailableRooms(DateTime startTime, DateTime endTime)
      {
         throw new NotImplementedException();
      }

        public bool StorageExist(Room room)
        {
           return rs.StorageExist(room);
        }

        public List<Room> getRoomsByType(RoomType type)
        {
            return roomService.getRoomsByType(type);
        }

        public Room findFreeRoom(DateTime dt)
        {
            return roomService.findFreeRoom(dt);
        }
        public bool FindRoomByFloor(int roomNum, int floor)
        {
            if (rs.FindRoomByFloor(roomNum, floor))
            {
                return true;
            }
            return false;
        }

        public Service.RoomService roomService = new Service.RoomService();

        public int FindRoomId(int floor, int roomNum)
        {
            return rs.FindRoomId(floor, roomNum);
        }
    }
}