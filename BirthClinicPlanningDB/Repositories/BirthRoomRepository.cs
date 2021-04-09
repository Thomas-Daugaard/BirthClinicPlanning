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
                .Include(a => a.Appointments)
                .ToList());
        }

        public BirthRoom GetBirthRoomWithSpecificNumber(int no)
        {
            return context.BirthRooms
                .Include(a => a.Appointments)
                .SingleOrDefault(r=>r.RoomNumber ==no);
        }


        public BirthRoom GetSingleBirthRoom(int id)
        {
            return context.BirthRooms
                .Include(r => r.Appointments)
                .SingleOrDefault(a => a.RoomID == id);
        }

        public void AddBirthRoom(BirthRoom room)
        {
            context.BirthRooms.Add(room);
        }

        public void AddAppointmentToRoom(int roomid, Appointment appointment)
        {
            var roomloaded = context.Restrooms
                .Include(r => r.Appointments)
                .SingleOrDefault(a => a.RoomID == roomid);

            roomloaded?.Appointments.Add(appointment);

            context.SaveChanges();
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
