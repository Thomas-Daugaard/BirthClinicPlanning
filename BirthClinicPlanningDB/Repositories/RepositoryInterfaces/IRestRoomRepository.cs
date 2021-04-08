using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.DomainObjects;

namespace BirthClinicPlanningDB.Repositories.RepositoryInterfaces
{
    public interface IRestRoomRepository : IRepository<RestRoom>
    {
        public ObservableCollection<RestRoom> GetAllRestRoom();

        public ObservableCollection<RestRoom> GetAllRestRoomsWithSpecificNumber(int no);

        public RestRoom GetSingleRestRoom(int id);

        public void DelRestRoom(RestRoom restRoom);


        public void AddRestRoom(RestRoom restRoom);
    }
}
