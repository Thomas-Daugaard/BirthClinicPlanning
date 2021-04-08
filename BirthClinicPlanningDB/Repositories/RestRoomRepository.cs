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
    public class RestRoomRepository: Repository<RestRoom>, IRestRoomRepository
    {
        public RestRoomRepository(DbContext context) : base(context)
        {
        }

        public ObservableCollection<RestRoom> GetAllRestRoom()
        {
            return new ObservableCollection<RestRoom>(context.Restrooms
                .Include(p => p.Parents)
                .Include(c => c.Child)
                .Include(cl => cl.Clinicians)
                .Include(j=>j.Appointments)
                .Include(a => a.Appointments)
                .ToList());
        }

        public ObservableCollection<RestRoom> GetAllRestRoomsWithSpecificNumber(int no)
        {
            return new ObservableCollection<RestRoom>(context.Restrooms
                .Include(p => p.Parents)
                .Include(c => c.Child)
                .Include(cl => cl.Clinicians)
                .Include(j => j.Appointments)
                .Include(a => a.Appointments)
                .Where(r => r.RoomNumber == no)
                .ToList());
        }

        public RestRoom GetSingleRestRoom(int id)
        {
            return context.Restrooms
                .Include(r => r.Appointments)
                .Include(s=>s.Clinicians)
                .Include(p=>p.Child)
                .Include(i=>i.Parents)
                .SingleOrDefault(a=>a.RoomID==id);
        }

        public void AddRestRoom(RestRoom restRoom)
        {
            context.Restrooms.Add(restRoom);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
