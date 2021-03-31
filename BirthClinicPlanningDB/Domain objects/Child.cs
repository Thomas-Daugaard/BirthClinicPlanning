using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Models
{
    public class Child
    {
        [Key]
        public int ChildID { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public DateTime BirthDateTime { get; set; }
        [ForeignKey("ParentsID")]
        public Parents Parents { get; set; }
    }
}
