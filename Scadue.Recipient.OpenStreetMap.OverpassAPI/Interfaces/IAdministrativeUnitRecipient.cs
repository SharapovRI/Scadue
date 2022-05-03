using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces
{
    public interface IAdministrativeUnitRecipient
    {
        List<AdministrativeUnitConverted> GetUnitsByName(string unit_name);
        AdministrativeUnitConverted GetCountry(string country);
        Task<List<AdministrativeUnitConverted>> GetChildUnits(int id, string parentName, int admin_level);
    }
}
