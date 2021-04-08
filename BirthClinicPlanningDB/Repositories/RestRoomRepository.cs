﻿using System;
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
            return new ObservableCollection<RestRoom>(context.Restrooms
                .Include(j=>j.Appointments)
                .ToList());
        }

        public RestRoom GetRestRoomWithSpecificNumber(int no)
        {
            return context.Restrooms
                .Include(a => a.Appointments)
                .Where(r => r.RoomNumber == no)
                .SingleOrDefault();
        }

        public RestRoom GetSingleRestRoom(int id)
        {
            return context.Restrooms
                .Include(r => r.Appointments)
                .SingleOrDefault(a=>a.RoomID==id);
        }

        public void AddRestRoom(RestRoom restRoom)
        {
            context.Restrooms.Add(restRoom);
        }

        public void DelRestRoom(RestRoom restRoom)
        {
            context.Restrooms.Remove(restRoom);
        }

        public Context context
        {
            get { return Context as Context; }
        }
    }
}
