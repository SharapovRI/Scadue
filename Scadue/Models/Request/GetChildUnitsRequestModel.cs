namespace Scadue.Models.Request
{
    public class GetChildUnitsRequestModel
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public int AdminLevel { get; set; }
    }
}
