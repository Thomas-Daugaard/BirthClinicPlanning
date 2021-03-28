using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Models
{
    class Parents
    {
        public int ParentsID { get; set; }
        public string MothersName { get; set; }
        public int MothersCPR { get; set; }
        public string FathersName { get; set; }
        public string FathersCPR { get; set; }
        public Child Child { get; set; }
    }
}
