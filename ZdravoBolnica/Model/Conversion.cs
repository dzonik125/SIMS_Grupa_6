using Model;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    class Conversion
    {

        public static string RoomTypeToString(RoomType tip)
        {
            return tip switch
            {
                RoomType.surgery => "Operaciona sala",
                RoomType.examination => "Prostorija za preglede",
                RoomType.ward => "Bolesnička soba",
                RoomType.laboratory => "laboratorija",
                RoomType.waitingRoom => "cekaonica",

                _ => "",
            };
        }

        public static string BloodTypeToString(BloodType tip)
        {
            return tip switch
            {
                BloodType.ONegative => "O-",
                BloodType.APositive => "A+",
                BloodType.ANegative => "A-",
                BloodType.BPositive => "B+",
                BloodType.BNegative => "B-",
                BloodType.ABPositive => "AB+",
                BloodType.ABNegative => "AB-",
                BloodType.OPositive => "O+",
                _ => "",
            };
        }


        public static List<string> GetRoomTypes()
        {
            List<string> tipovi = new List<string>();
            foreach (RoomType tip in Enum.GetValues(typeof(RoomType)))
            {
                string s = RoomTypeToString(tip);
                tipovi.Add(s);
            }
            return tipovi;
        }

        public static List<string> GetBloodType()
        {
            List<string> tipovi = new List<string>();
            foreach (BloodType tip in Enum.GetValues(typeof(BloodType)))
            {
                string s = BloodTypeToString(tip);
                tipovi.Add(s);
            }
            return tipovi;
        }

        public static RoomType StringToRoomType(string str)
        {
            return str switch
            {
                "Prostorija za preglede" => RoomType.examination,
                "Operaciona sala" => RoomType.surgery,
                "cekaonica" => RoomType.waitingRoom,
                "laboratorija" => RoomType.laboratory,
                "bolnicka soba" => RoomType.ward,
                _ => RoomType.ward,

            };
        }

        public static BloodType StringToBloodType(string str)
        {
            return str switch
            {
                "O-" => BloodType.ONegative,
                "A+" => BloodType.APositive,
                "A-" => BloodType.ANegative,
                "B+" => BloodType.BPositive,
                "B-" => BloodType.BNegative,
                "AB+" => BloodType.ABPositive,
                "AB-" => BloodType.ABNegative,
                "O+" => BloodType.OPositive,
                _ => BloodType.OPositive,
            };
        }

        public static string AppointmentTypeToString(AppointmentType tip)
        {
            return tip switch
            {
                AppointmentType.examination => "pregled",
                AppointmentType.surgery => "operacija",
                _ => "",
            };
        }

        public static AppointmentType StringToAppointmentType(string str)
        {
            return str switch
            {
                "pregled" => AppointmentType.examination,
                "operacija" => AppointmentType.surgery,
                _ => AppointmentType.surgery,
            };
        }
        public static string SpecializationToString(Specialization spec)
        {

            return spec switch
            {
                Specialization.cardiovascular => "Kardiovaskularni hirurg",
                Specialization.dermatological => "Dermatolog",
                Specialization.general => "Lekar opste prakse",
                Specialization.nerulogical => "Neurohirurg",
                Specialization.oncological => "Onkolog",
                Specialization.otolaryngolical => "ORL",

                _ => "",

            };

        }

        public static Specialization StringToSpecialization(string spec)
        {
            return spec switch
            {
                "Kardiovaskularni hirurg" => Specialization.cardiovascular,
                "Dermatolog" => Specialization.dermatological,
                "Lekar opste prakse" => Specialization.general,
                "Neurohirurg" => Specialization.nerulogical,
                "Onkolog" => Specialization.oncological,
                "ORL" => Specialization.otolaryngolical,
                _ => Specialization.otolaryngolical,
            };
        }

        public static String EquipmentTypeToString(EquipmentType type)
        {
            return type switch
            {
                EquipmentType.potrosna => "potrosna",
                EquipmentType.nepotrosna => "nepotrosna",
                _ => "nepotrosna",
            };
        }

        public static EquipmentType StringToEquipmentType(string type)
        {
            return type switch
            {
                "potrosna" => EquipmentType.potrosna,
                "nepotrosna" => EquipmentType.nepotrosna,
                _ => EquipmentType.nepotrosna,
            };
        }

    }
}
