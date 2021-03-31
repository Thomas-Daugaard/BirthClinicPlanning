using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicGUI.Models
{
    public abstract class Room
    {
        public int RoomID { get; set; }
        public bool Occupied { get; set; }
        public Parents Parents { get; set; }
        public Child Child { get; set; }
    }

    class RestRoom : Room
    {
    }

    class MaternityRoom : Room
    {
    }
}
