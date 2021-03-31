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

        IFourHourRestRoomRepository RestRooms { get; }

        IMaternityRoomRepository MaternityRooms { get; }

        int Complete();
    }
}
