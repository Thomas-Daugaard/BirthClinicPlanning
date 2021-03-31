﻿using BirthClinicPlanningDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Domain_objects
{
    public class MaternityRoom
    {
        [Key]
        public int MaternityRoomId { get; set; }
        [ForeignKey("ParentsID")]
        public Parents CurrentParrents { get; set; }
        [ForeignKey("AppointmentsID")]
        public List<Appointments> MaternatyRoomSchedule { get; set; }
    }
}
