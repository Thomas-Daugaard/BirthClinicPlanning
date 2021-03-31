using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB
{
    public interface IDataAccessActions: IDisposable
    {
        //Repository interface 1
        //Repository interface 2 etc..

        int Complete();
    }
}
