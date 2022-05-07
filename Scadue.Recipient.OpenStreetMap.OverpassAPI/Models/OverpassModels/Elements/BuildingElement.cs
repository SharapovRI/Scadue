using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Elements
{
    public class BuildingElement<TTags> : IElements<TTags> where TTags : class, ITags
    {
        public Center center { get; set; }
        public TTags tags { get; set; }
    }
}
