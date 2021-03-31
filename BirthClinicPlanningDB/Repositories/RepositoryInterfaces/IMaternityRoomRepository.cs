using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;
using BirthClinicPlanningDB.Models;

namespace BirthClinicPlanningDB.Repositories.RepositoryInterfaces
{
    public interface IMaternityRoomRepository : IRepository<MaternityRoom>
    {
        public List<MaternityRoom> GetAllBirthsRooms();

        public MaternityRoom GetSingleBirthRoom(int id);
    }
}
