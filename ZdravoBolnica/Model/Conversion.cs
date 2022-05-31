using Model;
using System;
using System.Collections.Generic;
using static SIMS.Model.VacationPeriodStatus;

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
                RoomType.storage => "Magacin",
                RoomType.laboratory => "laboratorija",
                RoomType.waitingRoom => "Cekaonica",

                _ => "",
            };
        }

        public static string MedicationStatusTypeToString(MedicationStatusType tip)
        {
            return tip switch
            {
                MedicationStatusType.accepted => "Odobreno",
                MedicationStatusType.waiting => "Na cekanju",
                MedicationStatusType.rejected => "Odbijeno",
                _ => "",
            };
        }

        public static MedicationStatusType StringToMedicationStatusType(string tip)
        {
            return tip switch
            {
                "Odobreno" => MedicationStatusType.accepted,
                "Na cekanju" => MedicationStatusType.waiting,
                "Odbijeno" => MedicationStatusType.rejected,
                _ => MedicationStatusType.waiting,
            };
        }

        public static string VacationPeriodStatusTypeToString(VacationPeriodStatusType tip)
        {
            return tip switch
            {
                VacationPeriodStatusType.accepted => "Odobreno",
                VacationPeriodStatusType.waiting => "Na cekanju",
                VacationPeriodStatusType.rejected => "Odbijeno",
                _ => "",
            };
        }

        public static VacationPeriodStatusType StringToVacationStatusType(string tip)
        {
            return tip switch
            {
                "Odobreno" => VacationPeriodStatusType.accepted,
                "Na cekanju" => VacationPeriodStatusType.waiting,
                "Odbijeno" => VacationPeriodStatusType.rejected,
                _ => VacationPeriodStatusType.waiting,
            };
        }

        public static string VacationPeriodTypeToString(VacationPeriodType tip)
        {
            return tip switch
            {
                VacationPeriodType.regular => "Regularno",
                VacationPeriodType.urgent => "Hitno",
                _ => "",
            };
        }

        public static VacationPeriodType StringToVacationPeriodType(string tip)
        {
            return tip switch
            {
                "Regularno" => VacationPeriodType.regular,
                "Hitno" => VacationPeriodType.urgent,
                _ => VacationPeriodType.regular,
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

        public static List<string> GetVacationPeriodStatusType()
        {
            List<string> tipovi = new List<string>();
            foreach (VacationPeriodStatusType vacationPeriod in Enum.GetValues(typeof(VacationPeriodStatusType)))
            {
                string s = VacationPeriodStatusTypeToString(vacationPeriod);
                tipovi.Add(s);
            }
            return tipovi;
        }



        public static List<string> GetMEdicationStatusTypes()
        {
            List<string> tipovi = new List<string>();
            foreach (MedicationStatusType tip in Enum.GetValues(typeof(MedicationStatusType)))
            {
                string s = MedicationStatusTypeToString(tip);
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

        public static List<string> GetSpecializationType()
        {
            List<string> tipovi = new List<string>();
            foreach (Specialization tip in Enum.GetValues(typeof(Specialization)))
            {
                string s = SpecializationToString(tip);
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
                "Cekaonica" => RoomType.waitingRoom,
                "Laboratorija" => RoomType.laboratory,
                "Magacin" => RoomType.storage,
                "Bolesnička soba" => RoomType.ward,
                _ => RoomType.ward,

            };
        }

        internal static List<String> GetEquipmentTypes()
        {
            List<string> tipovi = new List<string>();
            foreach (EquipmentType tip in Enum.GetValues(typeof(EquipmentType)))
            {
                string s = EquipmentTypeToString(tip);
                tipovi.Add(s);
            }
            return tipovi;
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
                AppointmentType.renovation => "renoviranje",
                AppointmentType.transfer => "premestanje opreme",
                _ => "",
            };
        }

        public static AppointmentType StringToAppointmentType(string str)
        {
            return str switch
            {
                "pregled" => AppointmentType.examination,
                "operacija" => AppointmentType.surgery,
                "renoviranje" => AppointmentType.renovation,
                "premestanje opreme" => AppointmentType.transfer,
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
