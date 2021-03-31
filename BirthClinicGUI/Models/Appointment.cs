using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DryIoc;
using Unity.Events;

namespace BirthClinicGUI.Models
{
    public class Appointment
    {
        public int RoomID { get; set; }
        public DateTime Date { get; set; }
        public string DisplayDate { get => Date.ToShortDateString(); set => Date = DateTime.Parse(value); }

        public bool BirthInProgess { get; set; }

        public Parents Parents { get; set; }

        public Child Child { get; set; }

        public ObservableCollection<Clinician> Clinicians { get; set; }
    }
}
