using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Models;

namespace BirthClinicPlanningDB.Domain_objects
{
    class BirthClinic
    {
        public int BirthClinicID { get; set; }
        public List<FourHoursRestRoom> FourHoursRestRooms { get; set; }
        public List<BirthRoom> BirthRooms { get; set; }
        public List<MaternityRoom> MaternityRooms { get; set; }
        public List<Clinician> Clinicians { get; set; }
    }
}
