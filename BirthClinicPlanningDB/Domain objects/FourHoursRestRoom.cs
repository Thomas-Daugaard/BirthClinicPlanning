﻿using BirthClinicPlanningDB.Domain_objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Models
{
    class FourHoursRestRoom
    {
        [Key]
        public int FourHourRestRoomId { get; set; }
        public string Date { get; set; }
        [ForeignKey("ParentsID")]
        public Parents CurrentParents { get; set; }
        [ForeignKey("AppointmentsID")]
        public List<Appointments> FourHourRestRoomSchedule { get; set; }

    }
}
