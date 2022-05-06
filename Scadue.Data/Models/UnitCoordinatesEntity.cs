namespace Scadue.Data.Models
{
    public class UnitCoordinatesEntity : Entity
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Number { get; set; }
        public int UnitId { get; set; }
        public AdministrativeUnitEntity AdministrativeUnit { get; set; }
    }
}
