using Model;
using SIMS.Model;
using System;

namespace SIMS.Util
{
    public class DateRange
    {
        public DateTime startTime;

       
        public DateTime endTime { get; set; }

        public double duration { get; set; }
        public RoomType roomType { get; set; }
        public Specialization specializationType { get; set; }


        public void step()
        {
            startTime = startTime.AddMinutes(duration);
            if (startTime.Hour >= 20)
            {
                startTime = startTime.AddHours(12);
            }
        }

        public bool checkForIntersection(DateTime startTimeAppoinment, double appointmentDuration)
        {
            bool hasIntersection = false;
            if (!((startTimeAppoinment.AddMinutes(appointmentDuration) <= startTime && startTimeAppoinment <= startTime ||
                (startTime.AddMinutes(duration) <= startTimeAppoinment && startTime <= startTimeAppoinment))))
                hasIntersection = true;

            return hasIntersection;
        }      
  
    }

}
