using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Repositories.RepositoryInterfaces;

namespace BirthClinicPlanningDB
{
    public interface IDataAccessActions: IDisposable
    {
        IAppointmentRepository Appointments { get; }

        IRestRoomRepository RestRooms { get; }

        IMaternityRoomRepository MaternityRooms { get; }
        IClinicianRepository Clinicians { get; }
        IBirthRoomRepository BirthRooms { get; }

        public static IDataAccessActions Access() => access ?? (access = new DataAccessActions(new Context()));

        private static IDataAccessActions access;

        int Complete();
    }
}
