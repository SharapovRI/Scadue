using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Models
{
    public class ChildUnitTags : ITags
    {
        public string ISO31662 { get; set; }
        public string addrcountry { get; set; }
        public int admin_level { get; set; }
        public string name { get; set; }
        public int population { get; set; }
        public string place { get; set; }
    }
}
