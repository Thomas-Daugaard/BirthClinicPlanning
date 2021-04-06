using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthClinicPlanningDB.DomainObjects
{
    public class BirthRoom : Room
    {
        [NotMapped] public new string RoomType => "Birth Room";
    }
}