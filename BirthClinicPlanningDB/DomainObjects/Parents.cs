using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.DomainObjects
{
    public class Parents
    {
        [Key]
        public int ParentsID { get; set; }
        public string MomCPR { get; set; }
        public string MomFirstName { get; set; }
        public string MomLastName { get; set; }
        public string DadCPR { get; set; }
        public string DadFirstName { get; set; }
        public string DadLastName { get; set; }
        public Child Child { get; set; }
    }
}
