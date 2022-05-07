namespace Scadue.Business.Models.Response
{
    public class BuildingResponseBusinessModel
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public int FloorsNumber { get; set; }
        public float CenterLatitude { get; set; }
        public float CenterLongitude { get; set; }
        public int UnitId { get; set; }
        public AdministrativeUnitResponseBusinessModel Unit { get; set; }
    }
}
