using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;
using BirthClinicPlanningDB.Models;

namespace BirthClinicPlanningDB.Repositories
{
    public interface IFourHourRestRoomRepository : IRepository<FourHoursRestRoom>
    {
        public List<FourHoursRestRoom> GetAllRestRoom();

        public FourHoursRestRoom GetSingleRestRoom(int id);
    }
}
