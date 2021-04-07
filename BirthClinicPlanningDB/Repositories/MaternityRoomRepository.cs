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
    public class MaternityRoomRepository:Repository<MaternityRoom>, IMaternityRoomRepository
    {
        public MaternityRoomRepository(DbContext context) : base(context)
        {
        }

        public ObservableCollection<MaternityRoom> GetAllMaternityRooms()
        {
            return new ObservableCollection<MaternityRoom>(context.maternityrooms
                .Include(p => p.Parents)
                .Include(c => c.Child)
                .Include(cl => cl.Clinicians)
                .ToList());
        }

        public MaternityRoom GetSingleMaternityRoom(int id)
        {
            return context.maternityrooms.SingleOrDefault(a => a.RoomID == id);
        }

        public void AddMaternity(MaternityRoom maternityRoom)
        {
            context.maternityrooms.Add(maternityRoom);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
