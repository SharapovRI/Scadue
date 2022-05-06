namespace Scadue.Business.Models.Request
{
    public class UnitCoordinatesRequestBusinessModel
    {
        public int Id { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public int Number { get; set; }
        public int UnitId { get; set; }
    }
}
