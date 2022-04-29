using System.Collections.Generic;

namespace Scadue.Models.Response
{
    public class AdministrativeUnitResponseAPIModel
    {
        public int Id { get; set; }
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int ParentAdminUnitId { get; set; }
        public AdministrativeUnitResponseAPIModel ParentAdministrativeUnit { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public decimal CenterLatitude { get; set; }
        public decimal CenterLongitude { get; set; }
        public virtual IList<AdministrativeUnitResponseAPIModel> ChildUnits { get; set; }
    }
}
