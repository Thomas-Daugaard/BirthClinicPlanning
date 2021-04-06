using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.DomainObjects;
using BirthClinicPlanningDB.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanningDB.Repositories
{
    public class AppointmentsRepository: Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentsRepository(DbContext context) : base(context)
        {
        }

        public ObservableCollection<Appointment> getAllAppointments()
        {
            return new ObservableCollection<Appointment>(context.Appointments.Include(p => p.Parents)
                .Include(c => c.Child).Include(c => c.Clinicians).ToList());
        }

        public Appointment getSingleAppointment(int id)
        {
            Appointment appointment = context.Appointments.Include(p => p.Parents).Include(c => c.Child)
                .Include(c => c.Clinicians).Where(a => a.AppointmentID == id).SingleOrDefault();
            return appointment;
        }

        public void AddAppointment(Appointment appointment)
        {
            context.Appointments.Add(appointment);
        }

        public void DelAppointment(int id)
        {
            Appointment appointmentToDelete = context.Appointments.Find(id);
            context.Appointments.Remove(appointmentToDelete);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
