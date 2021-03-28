using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Models;

namespace BirthClinicPlanningDB.Domain_objects
{
    class Birth
    {
        public int BirthID { get; set; }
        public Parents Parents { get; set; }
        public BirthRoom BirthRoom { get; set; }
        public List<Clinician> Clinicians { get; set; }
    }
}
