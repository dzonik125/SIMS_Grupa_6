using Model;
using SIMS.Model;
using System;

namespace SIMS.Util
{
    public class Scheduler
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

        public bool overlapsWithExistingTerm(DateTime startTimeAppoinment, double appointmentDuration)
        {
            bool overlaps = false;
            if (!((startTimeAppoinment.AddMinutes(appointmentDuration) <= startTime && startTimeAppoinment <= startTime ||
                (startTime.AddMinutes(duration) <= startTimeAppoinment && startTime <= startTimeAppoinment))))
                overlaps = true;
            return overlaps;
        }      
  
    }

}
