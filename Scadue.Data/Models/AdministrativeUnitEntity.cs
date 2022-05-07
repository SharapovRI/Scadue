using System.Collections.Generic;

namespace Scadue.Data.Models
{
    public class AdministrativeUnitEntity : Entity
    {
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int? ParentAdminUnitId { get; set; }
        public virtual AdministrativeUnitEntity ParentAdministrativeUnit { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public float CenterLatitude { get; set; }
        public float CenterLongitude { get; set; }
        public virtual IList<AdministrativeUnitEntity> ChildUnits { get; set; }
        public string Place { get; set; }
        public string UnitCoordinates { get; set; }
        public float RectangleArea { get; set; }
        public virtual IList<BuildingEntity> Buildings { get; set; }
    }   
}
