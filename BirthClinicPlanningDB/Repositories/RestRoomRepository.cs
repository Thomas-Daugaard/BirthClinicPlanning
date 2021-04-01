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
            return new ObservableCollection<RestRoom>(context.Restrooms.ToList());
        }

        public RestRoom GetSingleRestRoom(int id)
        {
            return context.Restrooms.SingleOrDefault(a => a.RoomID == id);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
