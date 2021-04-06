using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BirthClinicPlanningDB.DomainObjects
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public bool Occupied { get; set; }
        public Parents Parents { get; set; }
        public Child Child { get; set; }
        public ObservableCollection<Clinician> Clinicians { get; set; }
    }
}