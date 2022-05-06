using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels
{
    public class Rootobject<TElement, TTags> where TElement : class, IElements<TTags> where TTags : class, ITags
    {
        public TElement[] elements { get; set; }
    }
}
