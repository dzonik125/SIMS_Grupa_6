using Model;
using Repository;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    public class ExaminationReportRepository : Repository<ExaminationReport, int>
    {
        private String filename = @".\..\..\..\Data\examinationReports.txt";
        private Serializer<ExaminationReport> reportSerializer = new Serializer<ExaminationReport>();
        public void Create(ExaminationReport entity)
        {
            List<ExaminationReport> reports = new List<ExaminationReport>();
            reports = reportSerializer.fromCSV(filename);
            int num = reports.Count;
            if (num > 0)
            {
                entity.id = reports[num - 1].id;
                entity.id++;
            }
            else
            {
                entity.id = 1;
            }
            reports.Add(entity);
            reportSerializer.toCSV(filename, reports);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationReport> FindAll()
        {
            return reportSerializer.fromCSV(filename);
        }

        public ExaminationReport FindById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(ExaminationReport entity)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationReport> findReportsByMRecordId(int id)
        {
            List<ExaminationReport> temp = new List<ExaminationReport>();
            temp = reportSerializer.fromCSV(filename);
            List<ExaminationReport> reports = new List<ExaminationReport>();
            foreach (ExaminationReport p in temp)
            {
                if (p.medicalRecord.id == id)
                    reports.Add(p);
            }
            return reports;
        }
    }
}
