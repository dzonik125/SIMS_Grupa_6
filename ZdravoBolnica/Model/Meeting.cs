using Model;
using Repository;
using SIMS.Repository;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class Meeting : Serializable
    {
        public DoctorRepository doctorRepository = new DoctorRepository();
        public SecretaryRepository secretaryRepository = new SecretaryRepository();
        public ManagerRepository managerRepository = new ManagerRepository();
        public int id { get; set; }
        public DateTime startTime { get; set; }
        public int duration { get; set; }
        public Room room { get; set; }
        public List<Doctor> doctors = new List<Doctor>();
        public List<Manager> managers = new List<Manager>();
        public List<Secretary> secretaries = new List<Secretary>();

        public string doctorIds = "";
        public string managerIds = "";
        public string secretaryIds = "";
        public string topic { get; set; }

        public String MeetingDate { get { return startTime.ToString("dd.MM.yyyy."); } }

        public String MeetingTime { get { return startTime.ToString("HH:mm"); } }

        public String GetAppoitmentTime()
        {
            return startTime.ToString("HH:mm");
        }

        public DateTime GetEndTime()
        {
            return startTime.AddMinutes(duration);
        }


        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            room = new Room();
            room.id = int.Parse(values[1]);
            startTime = DateTime.Parse(values[2]);
            duration = int.Parse(values[3]);
            topic = values[4];

            List<int> doctorIds = new List<int>();
            if (values[5] != "")
            {
                string[] parts = values[5].Split(',');

                foreach (string s in parts)
                {
                    doctorIds.Add(Convert.ToInt32(s));
                }
                foreach (int i in doctorIds)
                {
                    doctors.Add(doctorRepository.FindById(i));
                }
            }

            List<int> managerIds = new List<int>();
            if (values[6] != "")
            {
                string[] parts = values[6].Split(',');

                foreach (string s in parts)
                {
                    managerIds.Add(Convert.ToInt32(s));
                }
                foreach (int i in managerIds)
                {
                    managers.Add(managerRepository.FindById(i));
                }
            }

            List<int> secretaryIds = new List<int>();
            if (values[7] != "")
            {
                string[] parts = values[7].Split(',');

                foreach (string s in parts)
                {
                    secretaryIds.Add(Convert.ToInt32(s));
                }
                foreach (int i in secretaryIds)
                {
                    secretaries.Add(secretaryRepository.FindById(i));
                }
            }



            //doctor = new Doctor();
            //doctor.id = int.Parse(values[4]);
        }

        public string[] ToCSV()
        {
            foreach (Doctor doctor in doctors)
            {
                doctorIds = doctorIds + doctor.id + ",";
            }
            if (doctorIds != "")
            {
                doctorIds = doctorIds.Remove(doctorIds.Length - 1, 1);
            }

            foreach (Manager manager in managers)
            {
                managerIds = managerIds + manager.id + ",";
            }
            if (managerIds != "")
            {
                managerIds = managerIds.Remove(managerIds.Length - 1, 1);
            }

            foreach (Secretary secretary in secretaries)
            {
                secretaryIds = secretaryIds + secretary.id + ",";
            }
            if (secretaryIds != "")
            {
                secretaryIds = secretaryIds.Remove(secretaryIds.Length - 1, 1);
            }

            string[] csvValues =
            {
                id.ToString(),
                room.id.ToString(),
                startTime.ToString(),
                duration.ToString(),
                topic,
                doctorIds.ToString(),
                managerIds.ToString(),
                secretaryIds.ToString(),
            };
            return csvValues;
        }
    }
}
