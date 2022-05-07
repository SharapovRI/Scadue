using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using System.Collections.Generic;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces
{
    public interface IUnitInfoRecipient
    {
        List<BuildingConverted> GetUnitInfo(int id, string name, int adminLevel);
        List<BuildingConverted> GetClassedBuildings(int id, string name, int adminLevel, string buildingClass, Dictionary<string, string> tags);
    }
}
