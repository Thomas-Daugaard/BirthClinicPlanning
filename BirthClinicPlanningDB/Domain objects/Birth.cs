using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Models;

namespace BirthClinicPlanningDB.Domain_objects
{
    public class Birth
    {
        [Key]
        public int BirthID { get; set; }
        [ForeignKey("ParentsID")]
        public Parents Parents { get; set; }

        [ForeignKey("BirthRoomId")]
        public BirthRoom BirthRoom { get; set; }
        [ForeignKey("StaffID")]
        public List<Clinician> Clinicians { get; set; }
    }
}
