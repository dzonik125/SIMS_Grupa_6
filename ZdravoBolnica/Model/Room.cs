// File:    Room.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:12:47
// Purpose: Definition of Class Room

using SIMS.Model;
using System;
using System.Collections.Generic;
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

        public List<Appointment> appointment;


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
                else if (roomType == RoomType.meetingRoom)
                    return "Sala za sastanke";
                else
                    return "Laboratorija";
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

    }
}