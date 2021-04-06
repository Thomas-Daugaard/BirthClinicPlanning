using BirthClinicPlanningDB.DomainObjects;
using BirthClinicPlanningDB.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Repositories
{
    public class ClinicianRepository : Repository<Clinician>, IClinicianRepository
    {
        public ClinicianRepository(DbContext context) : base(context)
        {
        }
        public ObservableCollection<Clinician> GetAllClinicians()
        {
            return new ObservableCollection<Clinician>(context.Clinicians.ToList());
        }

        public Clinician GetSingleClinician(int id)
        {
            return context.Clinicians.SingleOrDefault(a => a.ID == id);
        }
        public Context context
        {
            get { return Context as Context; }
        }
    }
}
