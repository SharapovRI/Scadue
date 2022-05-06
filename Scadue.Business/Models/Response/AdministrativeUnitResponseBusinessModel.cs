using System.Collections.Generic;

namespace Scadue.Business.Models.Response
{
    public class AdministrativeUnitResponseBusinessModel
    {
        public int Id { get; set; }
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int ParentAdminUnitId { get; set; }
        public AdministrativeUnitResponseBusinessModel ParentAdministrativeUnit { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public float CenterLatitude { get; set; }
        public float CenterLongitude { get; set; }
        public IList<AdministrativeUnitResponseBusinessModel> ChildUnits { get; set; }
        public IList<UnitCoordinatesResponseBusinessModel> UnitCoordinates { get; set; }
        public string Place { get; set; }
    }
}
