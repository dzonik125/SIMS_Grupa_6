using Model;
using Service;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class MergeRoomsService
    {
        private MergeRoomsRepository _mergeRoomsRepository = new MergeRoomsRepository();
        private RoomService _roomService = new RoomService();
        private AppointmentService _appointmentService = new AppointmentService();
        private RoomEquipmentService _roomEquipmentService = new RoomEquipmentService();
        public void SaveRoomMerging(Room room1, Room room2, RoomType roomType, DateTime startTimeRenovation, DateTime endTimeRenovation)
        {
            MergeRooms mergeRooms = new MergeRooms();
            mergeRooms = SetMergeRoomsAttributes(room1.id, room2.id, roomType, startTimeRenovation,endTimeRenovation);
            _mergeRoomsRepository.Create(mergeRooms);
            SaveRoomRenovationAppointemnt(room1, room2,startTimeRenovation,endTimeRenovation);
            MergeRooms(mergeRooms);

       
        }

        public void SaveRoomRenovationAppointemnt(Room room1, Room room2, DateTime startTimeRenovation, DateTime endTimeRenovation)
        {
            Appointment appointmentRoom1 = new Appointment();
            Appointment appointmentRoom2 = new Appointment();
            appointmentRoom1 = SetAppointmentAttributes(room1, startTimeRenovation, endTimeRenovation);
            appointmentRoom2 = SetAppointmentAttributes(room2, startTimeRenovation, endTimeRenovation);
            _appointmentService.SaveAppointment(appointmentRoom1);
            _appointmentService.SaveAppointment(appointmentRoom2);


        }

        public Appointment SetAppointmentAttributes(Room room, DateTime startTimeRenovation, DateTime endTimeRenovation)
        {
            Appointment appointment = new Appointment();
            appointment.Room = room;
            appointment.Doctor = SetDoctorForRenovation();
            appointment.patient = SetPatientForRenovation();
            appointment.startTime = startTimeRenovation;
            appointment.duration = CalculateAppointmentDuration(startTimeRenovation, endTimeRenovation);
            appointment.timesEdited = 0;
            appointment.Type = AppointmentType.renovation;
            return appointment;
       
        }

        public Patient SetPatientForRenovation()
        {
            Patient patient = new Patient();
            patient.id = 0;
            return patient;
        }

        public Doctor SetDoctorForRenovation()
        {
            Doctor doctor = new Doctor();
            doctor.id = 0;
            return doctor;
        }

        public int CalculateAppointmentDuration(DateTime startTimeRenovation, DateTime endTimeRenovation)
        {

            return (((endTimeRenovation - startTimeRenovation).Days)*24 * 60);
        }

        public MergeRooms SetMergeRoomsAttributes(int roomId1, int roomI2, RoomType roomType, DateTime startTimeRenovation, DateTime endTimeRenovation)
        {
            MergeRooms mergeRooms = new MergeRooms();
            mergeRooms.roomId1 = roomId1;
            mergeRooms.roomId2 = roomI2;
            mergeRooms.newRoomType = roomType;
            mergeRooms.startDate = startTimeRenovation;
            mergeRooms.endDate = endTimeRenovation;
            return mergeRooms;
        }

        public void MergeRooms(MergeRooms mergeRooms) 
        {
            Room room = new Room(); 
            room.roomNum = _roomService.FindSmallerRoomNumber(mergeRooms.roomId1, mergeRooms.roomId2);
            room.floor = _roomService.FindRoomFloorByRoomId(mergeRooms.roomId1);
            room.id = FindSmallerId(mergeRooms.roomId1, mergeRooms.roomId2);
            room.roomType = mergeRooms.newRoomType;
            UpdateRoomMerge(room, mergeRooms);
        }

        public void UpdateRoomMerge(Room room , MergeRooms mergeRooms)
        {
            _roomService.UpdateRoom(room);
            _roomEquipmentService.MoveEquipmentToWarehouse(mergeRooms.roomId1, mergeRooms.roomId2);
            if(room.id != mergeRooms.roomId1)
            {
                _roomService.DeleteRoomById(mergeRooms.roomId1);
            }
            _roomService.DeleteRoomById(mergeRooms.roomId2);
        }

        public int FindSmallerId(int id1, int id2)
        {
            if(id1 < id2)
            {
                return id1;
            }
            return id2;
        }

    }
}
