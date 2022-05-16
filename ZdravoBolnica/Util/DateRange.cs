using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Util
{
    public class DateRange
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }


        public bool checkIfBetween(DateTime first, DateTime second)
        {
            if (startTime > first && startTime < second)
                return true;
            return false;
        }

        public bool checkForIntersection(DateTime startTimeAppoinment, int duration)
        {
            if (!((startTimeAppoinment.AddMinutes(duration) < startTime && startTimeAppoinment < startTime ||
                (startTime.AddMinutes(30) < startTimeAppoinment && startTime < startTimeAppoinment))))
            {
                return true;
            }
            return false;
        }
        
    }

}
