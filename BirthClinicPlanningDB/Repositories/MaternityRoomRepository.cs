using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Domain_objects;
using BirthClinicPlanningDB.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanningDB.Repositories
{
    public class MaternityRoomRepository:Repository<MaternityRoom>, IMaternityRoomRepository
    {
        public MaternityRoomRepository(DbContext context) : base(context)
        {
        }

        public List<MaternityRoom> GetAllBirthsRooms()
        {
            return context.maternityrooms.ToList();
        }

        public MaternityRoom GetSingleBirthRoom(int id)
        {
            return context.maternityrooms.SingleOrDefault(a => a.MaternityRoomId == id);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
