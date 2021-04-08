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
                .Include(p => p.Parents)
                .Include(c => c.Child)
                .Include(cl => cl.Clinicians)
                .Include(j=>j.Appointments)
                .ToList());
        }

        public ObservableCollection<RestRoom> GetAllRestRoomsWithSpecificNumber(int no)
        {
            var restRooms = context.Restrooms
                //.Include(p => p.Parents)
                //.Include(c => c.Child)
                //.Include(cl => cl.Clinicians)
                .Include(j => j.Appointments)
                .Where(r => r.RoomNumber == no)
                .ToList();

            return new ObservableCollection<RestRoom>(restRooms);
        }

        public RestRoom GetSingleRestRoom(int id)
        {
            return context.Restrooms.Find(id);
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
