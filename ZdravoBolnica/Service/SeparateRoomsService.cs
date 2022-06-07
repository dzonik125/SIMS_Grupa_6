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
    public class SeparateRoomsService
    {
        private RoomService _roomService = new RoomService();
        private SeparateRoomsRepository _separateRoomsRepository = new SeparateRoomsRepository();
        private RoomEquipmentService _roomEquipmentService = new RoomEquipmentService();
        public void SaveFutureRenovationForRoomSeparation(SeparateRooms separateRooms)
        {
            _separateRoomsRepository.Create(separateRooms);
            SeparateRooms(separateRooms);
        }

        public void SeparateRooms(SeparateRooms separateRooms)
        {
            separateRooms.roomOne.id = _roomService.FindRoomId(separateRooms.roomOne.floor, separateRooms.roomOne.roomNum);
            _roomService.UpdateRoom(separateRooms.roomOne);
            _roomService.AddRoom(separateRooms.roomTwo);
            MoveEquipmentFromRoomInWarehouse(separateRooms.roomOne);
        }

        public void MoveEquipmentFromRoomInWarehouse(Room roomOne)
        {
            int storageId = _roomService.GetRoomIdByStorage(RoomType.storage);
            List<RoomEquipment> roomEquipment = _roomEquipmentService.GetEquipmentByRoom(roomOne);
            _roomEquipmentService.ExecuteEquipmentMovingToWarehouse(storageId, roomEquipment);
        }
    }
}
