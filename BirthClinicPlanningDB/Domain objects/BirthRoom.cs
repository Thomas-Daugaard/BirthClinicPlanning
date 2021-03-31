using BirthClinicPlanningDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Domain_objects
{
    class BirthRoom
    {
        [Key]
        public int BirthRoomId { get; set; }
        public string Date { get; set; }
        [ForeignKey("BirthID")]
        public Birth CurrentBirth { get; set; }
        [ForeignKey("StaffID")]
        public List<Clinician> Clinicians { get; set; }
        [ForeignKey("AppointmentsID")]
        public List<Appointments> BirthRoomSchedule { get; set; }
    }
}
