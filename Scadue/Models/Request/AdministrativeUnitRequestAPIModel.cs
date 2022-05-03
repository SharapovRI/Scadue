using System.Collections.Generic;

namespace Scadue.Models.Request
{
    public class AdministrativeUnitRequestAPIModel
    {
        public int Id { get; set; }
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int ParentAdminUnitId { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public float CenterLatitude { get; set; }
        public float CenterLongitude { get; set; }
        public virtual IList<AdministrativeUnitRequestAPIModel> ChildUnits { get; set; }
        public string Place { get; set; }
    }
}
