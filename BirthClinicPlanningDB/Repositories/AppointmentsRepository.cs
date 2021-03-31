using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;
using BirthClinicPlanningDB.Models;
using BirthClinicPlanningDB.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanningDB.Repositories
{
    public class AppointmentsRepository: Repository<Appointments>, IAppointmentRepository
    {
        public AppointmentsRepository(DbContext context) : base(context)
        {
        }

        public List<Appointments> getAllAppointments()
        {
            return context.appointments.ToList();
        }

        public Appointments getSingleAppointment(int id)
        {
            return context.appointments.SingleOrDefault(a=>a.AppointmentsID==id);
        }

        public void AddAppointment(DateTime date, Parents parents, List<Clinician> clinicians)
        {
            var newappointment = new Appointments();
            newappointment.AppointmentTimeDate = date;
            newappointment.parents = parents;
            newappointment.clinicians = clinicians;

            context.appointments.Add(newappointment);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
