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
        public void SaveRoomMerging(MergeRooms mergeRooms)
        {
            _mergeRoomsRepository.Create(mergeRooms);
            SaveRoomRenovationAppointemnt( mergeRooms);
            MergeRooms(mergeRooms);
        }

        public void SaveRoomRenovationAppointemnt( MergeRooms mergeRooms)
        {
            Appointment appointmentRoom1 = new Appointment();
            Appointment appointmentRoom2 = new Appointment();
            appointmentRoom1 = SetAppointmentAttributes( _roomService.FindRoomById(mergeRooms.roomId1), mergeRooms);
            appointmentRoom2 = SetAppointmentAttributes(_roomService.FindRoomById(mergeRooms.roomId2), mergeRooms);
            _appointmentService.SaveAppointment(appointmentRoom1);
            _appointmentService.SaveAppointment(appointmentRoom2);
        }

        public Appointment SetAppointmentAttributes(Room room, MergeRooms mergeRooms)
        {
            Appointment appointment = new Appointment();
            appointment.room = room;
            appointment.doctor = SetDoctorForRenovation();
            appointment.patient = SetPatientForRenovation();
            appointment.startTime = mergeRooms.startDate;
            appointment.duration = CalculateAppointmentDuration(mergeRooms.startDate, mergeRooms.endDate);
            appointment.timesEdited = 0;
            appointment.type = AppointmentType.renovation;
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
            if (room.id != mergeRooms.roomId1)
            {
                _roomService.DeleteRoomById(mergeRooms.roomId1);
            }
            else
            {
                _roomService.DeleteRoomById(mergeRooms.roomId2);
            }
        }

        public int FindSmallerId(int id1, int id2)
        {
            int id = id2;
            if(id1 < id2)
            {
                id = id1;
            }
            return id;
        }

    }
}
