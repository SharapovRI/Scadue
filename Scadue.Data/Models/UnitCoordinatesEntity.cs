namespace Scadue.Data.Models
{
    public class UnitCoordinatesEntity : Entity
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
        public int Number { get; set; }
        public int UnitId { get; set; }
        public AdministrativeUnitEntity AdministrativeUnit { get; set; }
    }
}
