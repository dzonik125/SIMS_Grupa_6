using System.Collections.Generic;
using Model;
using Repository;
using SIMS.Model;

namespace SIMS.Repository
{
    public class HospitalSurveyRepository : IRepository<HospitalSurvey,string>
    {
        private string filename = @".\..\..\..\Data\hospitalSurvey.txt";
        private Serializer<HospitalSurvey> hospitalSurveySerializer = new Serializer<HospitalSurvey>();
        
        public List<HospitalSurvey> FindAll()
        {
            return hospitalSurveySerializer.fromCSV(filename);
        }

        public HospitalSurvey FindById(string key)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(HospitalSurvey entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(HospitalSurvey entity)
        {
            throw new System.NotImplementedException();
        }
    }
}