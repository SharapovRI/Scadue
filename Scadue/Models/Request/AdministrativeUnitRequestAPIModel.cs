using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scadue.Models.Request
{
    public class AdministrativeUnitRequestAPIModel
    {
        public int Id { get; set; }
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int ParentAdminUnitId { get; set; }
        public AdministrativeUnitRequestAPIModel ParentAdministrativeUnit { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public decimal CenterLatitude { get; set; }
        public decimal CenterLongitude { get; set; }
        public virtual IList<AdministrativeUnitRequestAPIModel> ChildUnits { get; set; }
    }
}
