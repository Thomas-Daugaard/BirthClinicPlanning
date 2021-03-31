using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanningDB.Repositories
{
    public class FourHourRestRoomRepository: Repository<FourHoursRestRoom>, IFourHourRestRoomRepository
    {
        public FourHourRestRoomRepository(DbContext context) : base(context)
        {
        }

        public List<FourHoursRestRoom> GetAllRestRoom()
        {
            return context.fourhourrestrooms.ToList();
        }

        public FourHoursRestRoom GetSingleRestRoom(int id)
        {
            return context.fourhourrestrooms.SingleOrDefault(a => a.FourHourRestRoomId == id);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
