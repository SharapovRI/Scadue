namespace Scadue.Business.Models.Request
{
    public class BuildingRequestBusinessModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int UnitId { get; set; }
        public AdministrativeUnitRequestBusinessModel Unit { get; set; }
    }
}
