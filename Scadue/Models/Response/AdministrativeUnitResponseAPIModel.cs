using System.Collections.Generic;

namespace Scadue.Models.Response
{
    public class AdministrativeUnitResponseAPIModel
    {
        public int Id { get; set; }
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int ParentAdminUnitId { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public decimal CenterLatitude { get; set; }
        public decimal CenterLongitude { get; set; }
        public IList<AdministrativeUnitResponseAPIModel> ChildUnits { get; set; }
        public IList<UnitCoordinatesResponseAPIModel> UnitCoordinates { get; set; }
        public string Place { get; set; }
    }
}
