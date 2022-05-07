using System.Collections.Generic;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels
{
    public class AdministrativeUnitConverted
    {
        public string ISO3166 { get; set; }
        public int AdminLevel { get; set; }
        public int ParentAdminUnitId { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public float CenterLatitude { get; set; }
        public float CenterLongitude { get; set; }
        public string Place { get; set; }
        public string UnitCoordinates { get; set; }
        public float RectangleArea { get; set; }
    }
}
