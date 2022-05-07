namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels
{
    public class BuildingConverted
    {
        public string Class { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public int FloorsNumber { get; set; }
        public float CenterLatitude { get; set; }
        public float CenterLongitude { get; set; }
        public int UnitId { get; set; }
    }
}
