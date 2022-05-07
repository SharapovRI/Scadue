using Newtonsoft.Json;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Tags
{
    public class BuildingTags : ITags
    {
        public string addrhousenumber { get; set; }
        public string addrstreet { get; set; }
        public string building { get; set; }
        [JsonProperty("building:levels")]
        public string buildinglevels { get; set; }
        public string name { get; set; }
    }
}
