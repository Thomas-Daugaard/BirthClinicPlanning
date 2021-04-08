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
    public class BirthRoomRepository : Repository<BirthRoom>, IBirthRoomRepository
    {
        public BirthRoomRepository(DbContext context) : base(context)
        {
        }
        public ObservableCollection<BirthRoom> GetAllBirthsRooms()
        {
            return new ObservableCollection<BirthRoom>(context.BirthRooms
                .Include(p => p.Parents)
                .Include(c => c.Child)
                .Include(cl => cl.Clinicians)
                .Include(a => a.Appointments)
                .ToList());
        }

        public ObservableCollection<BirthRoom> GetAllBirthRoomsWithSpecificNumber(int no)
        {
            return new ObservableCollection<BirthRoom>(context.BirthRooms
                .Include(p => p.Parents)
                .Include(c => c.Child)
                .Include(cl => cl.Clinicians)
                .Include(a => a.Appointments)
                .Where(r => r.RoomNumber == no)
                .ToList());
        }


        public BirthRoom GetSingleBirthRoom(int id)
        {
            return context.BirthRooms.SingleOrDefault(a => a.RoomID == id);
        }

        public void AddBirthRoom(BirthRoom room)
        {
            context.BirthRooms.Add(room);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
