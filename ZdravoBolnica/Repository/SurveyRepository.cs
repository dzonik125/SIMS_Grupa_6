using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using SIMS.Model;

namespace SIMS.Repository
{
    class SurveyRepository : Repository<Survey, int>
    {
        private String filename = @".\..\..\..\Data\surveys.txt";
        private Serializer<Survey> surveySerializer = new Serializer<Survey>();

        public List<Survey> FindAll()
        {
            return surveySerializer.fromCSV(filename);
        }

        public Survey FindById(int key)
        {
            List<Survey> survs = FindAll();
            foreach (Survey s in survs)
            {
                if (s.id == key)
                {
                    return s;
                }
            }

            return null;
        }

        public void DeleteAll()
        {
            List<Survey> survs = FindAll();
            foreach (Survey s in survs)
            {
                survs.Remove(s);
            }
        }

        public void DeleteById(int id)
        {
            List<Survey> survs = FindAll();
            foreach (Survey s in survs)
            {
                if (s.id == id)
                {
                    survs.Remove(s);
                }
            }
        }

        public void Create(Survey entity)
        {
            List<Survey> survs = FindAll();
            int num = survs.Count;
            if (num > 0)
            {
                entity.id = survs[num - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }

            survs.Add(entity);
            surveySerializer.toCSV(filename, survs);
        }

        public void Update(Survey entity)
        {
            List<Survey> survs = FindAll();
            foreach (Survey s in survs)
            {
                if (s.id == entity.id)
                {
                    int index = survs.IndexOf(s);
                    if (index != -1)
                    {
                        survs[index] = entity;
                        break;
                    }
                }
            }
            surveySerializer.toCSV(filename, survs);
        }
    }
}
