using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanningDB.Repositories
{
    public class BirthRoomRepository:Repository<BirthRoom>, IBirthRoomRepository
    {
        public BirthRoomRepository(DbContext context) : base(context)
        {
        }

        public List<BirthRoom> GetAllBirthsRooms()
        {
            return context.birthRooms.ToList();
        }

        public BirthRoom GetSingleBirthRoom(int id)
        {
            return context.birthRooms.SingleOrDefault(a => a.BirthRoomId == id);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
