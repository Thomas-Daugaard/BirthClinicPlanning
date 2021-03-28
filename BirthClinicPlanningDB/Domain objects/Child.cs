using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Models
{
    class Child
    {
        public int ChildID { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public DateTime BirthDateTime { get; set; }
        public Parents Parents { get; set; }
    }
}
