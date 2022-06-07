using Model;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Repository
{
    public class AllergenRepository
    {
        private String filename = @".\..\..\..\Data\allergies.txt";
        private Serializer<Allergen> allergiesSerializer = new Serializer<Allergen>();

        public List<Allergen> FindAll()
        {
            return allergiesSerializer.fromCSV(filename);
        }

        public void DeleteById(int id)
        {
            List<Allergen> allergies = FindAll();
            foreach (Allergen a in allergies)
            {
                if (a.id.Equals(id))
                {
                    allergies.Remove(a);
                    break;
                }
            }
            allergiesSerializer.toCSV(filename, allergies);
        }
        public Allergen FindById(int key)
        {
            Allergen returnAllergen = new();
            foreach (Allergen a in FindAll())
            {
                if (a.id.Equals(key))
                {
                    returnAllergen = a;
                    break;
                }
                else
                    returnAllergen = null;
            }
            return returnAllergen;
        }

        public void Update(RoomEquipment entity)
        {
            throw new NotImplementedException();
        }

        public void Create(RoomEquipment entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

    }
}

