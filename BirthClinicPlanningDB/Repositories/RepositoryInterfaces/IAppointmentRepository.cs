using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;
using BirthClinicPlanningDB.Models;

namespace BirthClinicPlanningDB.Repositories.RepositoryInterfaces
{
    public interface IAppointmentRepository: IRepository<Appointments>
    {
        public List<Appointments> getAllAppointments();
        public Appointments getSingleAppointment(int id);

        public void AddAppointment(DateTime date,Parents parents, List<Clinician> clinician);
    }
}
