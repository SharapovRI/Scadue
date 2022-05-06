using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.NominantimModels;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Elements
{
    public class UnitElement<TTags> : IElements<TTags> where TTags : class, ITags
    {
        public string type { get; set; }
        public int id { get; set; }
        public TTags tags { get; set; }

        public Class1 NominatimRoot;
    }
}
