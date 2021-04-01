using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.DomainObjects
{
    public class MaternityRoom
    {
        [Key]
        public int MaternityRoomID { get; set; }
        public int RoomID { get; set; }
        public bool Occupied { get; set; }
        public Parents Parents { get; set; }
        public Child Child { get; set; }
    }
}
