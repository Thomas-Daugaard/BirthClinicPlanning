using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicGUI.Models
{
    public class Clinician
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Display { get => $"{FirstName} {LastName} - ID {ID}"; }
    }
}
