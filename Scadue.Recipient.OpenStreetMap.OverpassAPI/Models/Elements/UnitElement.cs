using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Models
{
    public class UnitElement<TTags> : IElements<TTags> where TTags : class, ITags
    {
        public string type { get; set; }
        public int id { get; set; }
        public Member[] members { get; set; }
        public TTags tags { get; set; }
    }
}
