using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;
using BirthClinicPlanningDB.Models;

namespace BirthClinicPlanningDB.Repositories
{
    public interface IBirthRoomRepository : IRepository<BirthRoom>
    {
        public List<BirthRoom> GetAllBirthsRooms();

        public BirthRoom GetSingleBirthRoom(int id);
    }
}
