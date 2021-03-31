using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;

namespace BirthClinicPlanningDB.Repositories
{
    public interface IAppointmentRepository: IRepository<Appointments>
    {
        List<Appointments> getAllAppointments();
    }
}
