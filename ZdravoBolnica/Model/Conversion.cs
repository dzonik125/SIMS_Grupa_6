using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
