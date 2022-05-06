using Newtonsoft.Json;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Constants;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Converters;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.Tags;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Recipients
{
    public class AdministrativeUnitRecipient : IAdministrativeUnitRecipient
    {
        public List<AdministrativeUnitConverted> GetUnitsByName(string unit_name)
        {
            List<AdministrativeUnitConverted> result = new();

            string requestUrl = URLs.OVERPASS_API_URL + $"[out:json];rel[name=\"{unit_name}\"][place];);out+geom;";
            string response = DoRequest(requestUrl);
            var rootobject = JsonConvert.DeserializeObject<Rootobject<UnitElement<ChildUnitTags>, ChildUnitTags>>(response);
            if (rootobject.elements.Length < 1) return result;

            result = AdministrativeUnitsConverter.ConvertToChildAdministrativeUnitCollection(-1, rootobject);

            return result;
        }

        public AdministrativeUnitConverted GetCountry(string country)
        {
            string requestUrl = URLs.OVERPASS_API_URL + $"[out:json];rel[admin_level=2][name=\"{country}\"];out+geom;";
            string response = DoRequest(requestUrl);
            var rootobject = JsonConvert.DeserializeObject<Rootobject<UnitElement<CountryUnitTags>, CountryUnitTags>>(response.Replace("ISO3166-", "ISO3166"));
            if (rootobject.elements.Length < 1) return null;
            
            var result = AdministrativeUnitsConverter.ConvertToCountryAdministrativeUnit(rootobject.elements[0]);
            return result;
        }

        public async Task<List<AdministrativeUnitConverted>> GetChildUnits(int id, string parentName, int admin_level)
        {
            Rootobject<UnitElement<ChildUnitTags>, ChildUnitTags> responseObject = new();

            if (admin_level < PropertyRestrictions.MIN_ADMIN_LEVEL || admin_level > PropertyRestrictions.MAX_ADMIN_LEVEL)
            {
                return null;
            }

            bool isChildFinded = false;
            while (!isChildFinded && admin_level < 10)
            {
                admin_level++;
                string requestUrl = URLs.OVERPASS_API_URL + $"[out:json];area[name=\"{parentName}\"];(rel[admin_level={admin_level}](area););out+geom;";
                string response = DoRequest(requestUrl);
                var rootobject = JsonConvert.DeserializeObject<Rootobject<UnitElement<ChildUnitTags>,ChildUnitTags>>(response);
                if (rootobject.elements.Length < 1) continue;
                else isChildFinded = true;
                responseObject = rootobject;
            }

            var result = AdministrativeUnitsConverter.ConvertToChildAdministrativeUnitCollection(id, responseObject);

            return result;
        }

        public static string DoRequest(string url)
        {
            string result = "";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
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
