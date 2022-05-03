using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.Tags
{
    public class CountryUnitTags : ITags
    {
        public string ISO31661 { get; set; }
        public string addrcountry { get; set; }
        public int admin_level { get; set; }
        public string name { get; set; }
        public int population { get; set; }
    }
}
