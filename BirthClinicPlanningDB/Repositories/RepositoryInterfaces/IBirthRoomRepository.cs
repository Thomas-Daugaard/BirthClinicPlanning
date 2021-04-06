﻿using BirthClinicPlanningDB.DomainObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Repositories.RepositoryInterfaces
{
    public interface IBirthRoomRepository: IRepository<BirthRoom>
    {
        public ObservableCollection<BirthRoom> GetAllBirthsRooms();

        public BirthRoom GetSingleBirthRoom(int id);
    }
}
