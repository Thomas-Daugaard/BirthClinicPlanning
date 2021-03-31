using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Models
{
    public class Parents
    {
        [Key]
        public int ParentsID { get; set; }
        public string MothersName { get; set; }
        public int MothersCPR { get; set; }
        public string FathersName { get; set; }
        public string FathersCPR { get; set; }

        [ForeignKey("ChildID")]
        public Child Child { get; set; }
    }
}
