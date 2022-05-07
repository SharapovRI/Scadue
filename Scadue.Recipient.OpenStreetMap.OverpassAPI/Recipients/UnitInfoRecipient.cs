using Newtonsoft.Json;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Constants;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Converters;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Elements;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Tags;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Recipients
{
    public class UnitInfoRecipient : IUnitInfoRecipient
    {
        public List<BuildingConverted> GetUnitInfo(int id, string name, int adminLevel)
        {
            List<BuildingConverted> buildingConverteds = new();

            foreach (var item in TagDictionaries.BuildingClasses)
            {
                var classedBuildings = GetClassedBuildings(id, name, adminLevel, item.Key, item.Value);
                buildingConverteds.AddRange(classedBuildings);
            }

            return buildingConverteds;
        }

        public List<BuildingConverted> GetClassedBuildings(int id, string name, int adminLevel, string buildingClass, Dictionary<string, string> tags)
        {
            List<BuildingElement<BuildingTags>> residentialBuildings = new();

            foreach (var item in tags)
            {
                string requestUrl = URLs.OVERPASS_API_URL + $"[out:json];area[admin_level={adminLevel}][name=\"{name}\"];(way[\"{item.Value}\"=\"{item.Key}\"](area);rel[\"{item.Value}\"=\"{item.Key}\"](area););out+center;";
                string response = DoRequest(requestUrl);
                var rootobject = JsonConvert.DeserializeObject<Rootobject<BuildingElement<BuildingTags>, BuildingTags>>(response.Replace("addr:", "addr"));
                if (rootobject.elements.Length < 1) continue;
                residentialBuildings.AddRange(rootobject.elements);
            }
            
            var buildings = BuildingsConverter.ConvertToBuildingCollection(id, buildingClass, residentialBuildings);

            return buildings;
        }

        public static string DoRequest(string url)
        {
            string result = "";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 91.0) Gecko / 20100101 Firefox / 91.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            response.Close();

            return result;
        }
    }
}
