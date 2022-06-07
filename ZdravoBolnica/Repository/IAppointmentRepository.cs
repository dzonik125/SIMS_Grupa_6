using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    public interface IAppointmentRepository
    {
        List<Appointment> FindByRoomId(int rid);
        List<Appointment> FindByDoctorId(int doctorId);
        List<Appointment> FindByPatientId(int doctorId);

    }
}
