using Model;
using System;
using static SIMS.Model.VacationPeriodStatus;

namespace SIMS.Model
{
    public class VacationPeriod : Serializable
    {
        public int id;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public String comment { get; set; }

        public String rejectComment { get; set; }

        public Doctor doctor { get; set; }

        public VacationPeriodStatusType status { get; set; }
        public VacationPeriodType type { get; set; }

        public String VacationPeriodTypeString
        {
            get
            {
                if (type == VacationPeriodType.regular)
                    return "Regularno";
                if (type == VacationPeriodType.urgent)
                    return "Hitno";
                else
                    return "Regularno";
            }
        }

        public String VacationPeriodStatusTypeString
        {
            get
            {
                if (status == VacationPeriodStatusType.accepted)
                    return "Odobreno";
                else if (status == VacationPeriodStatusType.waiting)
                    return "Na cekanju";
                else if (status == VacationPeriodStatusType.rejected)
                    return "Odbijeno";
                else
                    return "Na cekanju";
            }
        }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            doctor = new Doctor();
            doctor.id = int.Parse(values[1]);
            StartTime = DateTime.Parse(values[2]);
            EndTime = DateTime.Parse(values[3]);
            status = Conversion.StringToVacationStatusType(values[4]);
            comment = values[5];
            rejectComment = values[6];
            type = Conversion.StringToVacationPeriodType(values[7]);
        }

        public string[] ToCSV()
        {
            string[] values =
            {
                id.ToString(),
                doctor.id.ToString(),
                StartTime.ToString(),
                EndTime.ToString(),
                Conversion.VacationPeriodStatusTypeToString(status),
                comment,
                rejectComment,
                Conversion.VacationPeriodTypeToString(type),
            };
            return values;
        }
    }
}
