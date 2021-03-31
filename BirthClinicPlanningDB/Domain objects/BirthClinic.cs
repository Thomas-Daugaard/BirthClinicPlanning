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
    public class BirthClinic
    {
        [Key]
        public int BirthClinicID { get; set; }
        [ForeignKey("FourHourRestRoomId")]
        public List<FourHoursRestRoom> FourHoursRestRooms { get; set; }
        [ForeignKey("BirthRoomId")]
        public List<BirthRoom> BirthRooms { get; set; }
        [ForeignKey("MaternityRoomId")]
        public List<MaternityRoom> MaternityRooms { get; set; }
        [ForeignKey("StaffID")]
        public List<Clinician> Clinicians { get; set; }
    }
}
