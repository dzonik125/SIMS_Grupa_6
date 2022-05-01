// File:    Room.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:47
// Purpose: Definition of Class Room

using SIMS.Model;
using System;
using System.ComponentModel;

namespace Model
{
   public class Room : Serializable
    {
        public int roomNum { get; set; }
        public int floor { get; set; }

        public bool empty;
        public int id { get; set; }
        public RoomType roomType { get; set; }

      public System.Collections.Generic.List<Appointment> appointment;

      
        public String RoomTypeString
        {
            get
            {
                if (roomType == RoomType.examination)
                    return "Sala za preglede";
                else if (roomType == RoomType.surgery)
                    return "Operaciona sala";
                else if (roomType == RoomType.ward)
                    return "Bolnicka soba";
                else if (roomType == RoomType.waitingRoom)
                    return "Cekaonica";
                else if (roomType == RoomType.storage)
                    return "Magacin";
                else 
                    return "Laboratorija";
            }
        }

        public void AddAppointment(Appointment newAppointment)
      {
         if (newAppointment == null)
            return;
         if (this.appointment == null)
            this.appointment = new System.Collections.Generic.List<Appointment>();
         if (!this.appointment.Contains(newAppointment))
         {
            this.appointment.Add(newAppointment);
            newAppointment.Room = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAppointment(Appointment oldAppointment)
      {
         if (oldAppointment == null)
            return;
         if (this.appointment != null)
            if (this.appointment.Contains(oldAppointment))
            {
               this.appointment.Remove(oldAppointment);
               oldAppointment.Room = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAppointment()
      {
         if (appointment != null)
         {
            System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
            foreach (Appointment oldAppointment in appointment)
               tmpAppointment.Add(oldAppointment);
            appointment.Clear();
            foreach (Appointment oldAppointment in tmpAppointment)
               oldAppointment.Room = null;
            tmpAppointment.Clear();
         }
      }

        public string[] ToCSV()
        {

            string[] csvValues =
            {
                id.ToString(),
                roomNum.ToString(),
                floor.ToString(),
                empty.ToString(),
                Conversion.RoomTypeToString(roomType),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            roomNum = int.Parse(values[1]);
            floor = int.Parse(values[2]);
            empty = bool.Parse(values[3]);
            roomType = Conversion.StringToRoomType(values[4]);
        }

    

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Property for RoomType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>



    }
}