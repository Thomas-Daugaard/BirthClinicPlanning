using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.DomainObjects
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int RoomID { get; set; }
        public DateTime Date { get; set; }

        public bool BirthInProgess { get; set; }

        public Parents Parents { get; set; }

        public Child Child { get; set; }

        public ObservableCollection<Clinician> Clinicians { get; set; }

        public string DisplayDate { get => Date.ToShortDateString(); set => DateTime.Parse(value); }
    }
}
