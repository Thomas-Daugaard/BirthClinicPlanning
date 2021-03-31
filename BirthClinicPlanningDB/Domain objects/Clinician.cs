using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Domain_objects
{
    class Clinician
    {
        [Key]
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
