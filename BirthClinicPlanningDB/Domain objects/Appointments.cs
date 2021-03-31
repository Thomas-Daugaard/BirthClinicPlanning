using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Domain_objects
{
    public class Appointments
    {
        [Key]
        public int AppointmentsID { get; set; }
        //ctor for DateTime (month, date, year, hour, minute, second)
        public DateTime AppointmentTimeDate { get; set; }

    }
}
