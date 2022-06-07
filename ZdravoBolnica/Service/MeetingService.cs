using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class MeetingService
    {
        public MeetingRepository meetingRepository = new MeetingRepository();
        public bool AddMeeting(Meeting meeting)
        {
            meetingRepository.Create(meeting);
            return true;
        }

        public List<Meeting> GetAllMeetings()
        {
            return meetingRepository.FindAll();
        }

        public void DeleteMeetingById(int id)
        {
            meetingRepository.DeleteById(id);
        }

    }
}
