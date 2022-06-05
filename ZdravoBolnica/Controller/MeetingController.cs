using SIMS.Model;
using SIMS.Service;
using System.Collections.Generic;

namespace SIMS.Controller
{
    public class MeetingController
    {
        public MeetingService meetingService = new MeetingService();
        public bool AddMeeting(Meeting meeting)
        {
            meetingService.AddMeeting(meeting);
            return true;
        }

        public List<Meeting> GetAllMeetings()
        {
            return meetingService.GetAllMeetings();
        }

        public void DeleteMeetingById(int id)
        {
            meetingService.DeleteMeetingById(id);
        }

    }
}
