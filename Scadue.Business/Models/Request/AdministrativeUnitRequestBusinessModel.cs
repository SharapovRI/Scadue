using System.Collections.Generic;

namespace Scadue.Business.Models.Request
{
    public class AdministrativeUnitRequestBusinessModel
    {
        public int Id { get; set; }
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int ParentAdminUnitId { get; set; }
        public AdministrativeUnitRequestBusinessModel ParentAdministrativeUnit { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public float CenterLatitude { get; set; }
        public float CenterLongitude { get; set; }
        public IList<AdministrativeUnitRequestBusinessModel> ChildUnits { get; set; }
        public string Place { get; set; }
        public string UnitCoordinates { get; set; }
        public float RectangleArea { get; set; }
    }
}
