// File:    Manager.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:57
// Purpose: Definition of Class Manager

using System;

namespace Model
{
   public class Manager : Account, Serializable
   {
      public System.Collections.Generic.List<Room> room;
      
      /// <summary>
      /// Property for collection of Room
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      /*public System.Collections.Generic.List<Room> Room
      {
         get
         {
            if (room == null)
               room = new System.Collections.Generic.List<Room>();
            return room;
         }
         set
         {
            RemoveAllRoom();
            if (value != null)
            {
               foreach (Room oRoom in value)
                  AddRoom(oRoom);
            }
         }
      }*/

      
        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}