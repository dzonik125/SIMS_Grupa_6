using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class MeetingRepository : IRepository<Meeting, int>
    {
        private String filename = @".\..\..\..\Data\meetings.txt";
        private Serializer<Meeting> meetingSerializer = new Serializer<Meeting>();
        public void Create(Meeting entity)
        {
            List<Meeting> meetings = meetingSerializer.fromCSV(filename);
            if (meetings.Count > 0)
            {
                entity.id = meetings[meetings.Count - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }

            meetings.Add(entity);
            meetingSerializer.toCSV(filename, meetings);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            List<Meeting> meetings = FindAll();
            foreach (Meeting meeting in meetings)
            {
                if (meeting.id == id)
                {
                    meetings.Remove(meeting);
                    break;
                }
            }
            meetingSerializer.toCSV(filename, meetings);
        }

        public List<Meeting> FindAll()
        {
            return meetingSerializer.fromCSV(filename);
        }

        public Meeting FindById(int key)
        {
            Meeting returnMeeting = new();
            foreach (Meeting meeting in FindAll())
            {
                if (meeting.id == key)
                {
                    returnMeeting = meeting;
                    break;
                }
                else
                {
                    returnMeeting = null; 
                }

            }
            return returnMeeting;
        }

        public void Update(Meeting entity)
        {
            throw new NotImplementedException();
        }
    }
}
