using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BirthClinicGUI.Models
{
    public class Appointment
    {
        public int RoomID { get; set; }
        public DateTime Date { get; set; }
        public string MomName { get; set; }
        public string DadName { get; set; }
        public bool BirthInProgess { get; set; }

        public ObservableCollection<Clinician> Clinicians { get; set; }
    }
}
