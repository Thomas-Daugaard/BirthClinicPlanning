using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicGUI.Models
{
    public class Child
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public DateTime BirthDate { get; set; }
        public string DisplayDate { get => BirthDate.ToShortDateString(); set => DateTime.Parse(value); }
    }
}
