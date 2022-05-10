namespace Scadue.Data.Models
{
    public class BuildingEntity : Entity
    {
        public string Data { get; set; }
        public int UnitId { get; set; }
        public AdministrativeUnitEntity Unit { get; set; }
    }
}
