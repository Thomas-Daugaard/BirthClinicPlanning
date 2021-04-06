using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.DomainObjects;

namespace BirthClinicPlanningDB.Repositories.RepositoryInterfaces
{
    public interface IMaternityRoomRepository : IRepository<MaternityRoom>
    {
        public ObservableCollection<MaternityRoom> GetAllMaternityRooms();

        public MaternityRoom GetSingleMaternityRoom(int id);
    }
}
