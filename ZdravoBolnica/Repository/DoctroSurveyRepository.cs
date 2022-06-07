using System.Collections.Generic;
using Model;
using Repository;
using SIMS.ManagerView;
using SIMS.Model;

namespace SIMS.Repository
{
    public class DoctroSurveyRepository: IRepository<DoctorSurvey,string>
    {
        private string filename = @".\..\..\..\Data\doctorSurvey.txt";
        private Serializer<DoctorSurvey> doctorSurveySerializer = new Serializer<DoctorSurvey>();
        
        public List<DoctorSurvey> FindAll()
        {
            return doctorSurveySerializer.fromCSV(filename);
        }

        public DoctorSurvey FindById(string key)
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

        public void Create(DoctorSurvey entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DoctorSurvey entity)
        {
            throw new System.NotImplementedException();
        }
    
        
    }
}