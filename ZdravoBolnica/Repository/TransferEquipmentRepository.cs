using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class EquipmentTransferRepository : IRepository<EquipmentTransfer, int>
    {

        private String filename = @".\..\..\..\Data\transferinventory.txt";
        private Serializer<EquipmentTransfer> transferEquipmentSerilizer = new Serializer<EquipmentTransfer>();
        public void Create(EquipmentTransfer entity)
        {

            List<EquipmentTransfer> transferEquipmentList = new List<EquipmentTransfer>();
            transferEquipmentList = transferEquipmentSerilizer.fromCSV(filename);
            
            transferEquipmentList.Add(entity);
            transferEquipmentSerilizer.toCSV(filename, transferEquipmentList);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EquipmentTransfer> FindAll()
        {
            return transferEquipmentSerilizer.fromCSV(filename);
        }

        public EquipmentTransfer FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(EquipmentTransfer entity)
        {
            throw new NotImplementedException();
        }

        internal void Remove(EquipmentTransfer et)
        {

            List<EquipmentTransfer> equipTransfer = new List<EquipmentTransfer>();
            equipTransfer = FindAll();
            foreach (EquipmentTransfer e in equipTransfer)
            {
                if (e.roomSourceId == et.roomSourceId && DateTime.Compare(e.transferDate, et.transferDate) == 0) 
                {
                    equipTransfer.Remove(e);
                    break;
                }
            }
            transferEquipmentSerilizer.toCSV(filename, equipTransfer);
        }
    }
}
