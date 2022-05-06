using Newtonsoft.Json;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Constants;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Converters;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.NominantimModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Elements;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Tags;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Recipients
{
    public class AdministrativeUnitRecipient : IAdministrativeUnitRecipient
    {
        public AdministrativeUnitConverted GetUnitsByName(string unit_name)
        {
            AdministrativeUnitConverted result = new();

            string requestUrl = URLs.OVERPASS_API_URL + $"[out:json];rel[admin_level][name=\"{unit_name.Replace(" ", "+")}\"];);out;";
            string response = DoRequest(requestUrl);
            var rootobject = JsonConvert.DeserializeObject<Rootobject<UnitElement<ChildUnitTags>, ChildUnitTags>>(response);
            if (rootobject.elements.Length < 1) return result;

            var coordinates = GetUnitCoordinates(rootobject.elements[0].tags.name);
            rootobject.elements[0].NominatimRoot = coordinates;

            result = AdministrativeUnitsConverter.ConvertToChildAdministrativeUnit(-1, rootobject.elements[0]);

            return result;
        }

        public AdministrativeUnitConverted GetCountry(string country)
        {
            string requestUrl = URLs.OVERPASS_API_URL + $"[out:json];rel[admin_level=2][name=\"{country.Replace(" ", "+")}\"];out;";
            string response = DoRequest(requestUrl);
            var rootobject = JsonConvert.DeserializeObject<Rootobject<UnitElement<CountryUnitTags>, CountryUnitTags>>(response.Replace("ISO3166-", "ISO3166"));
            if (rootobject.elements.Length < 1) return null;

            var coordinates = GetUnitCoordinates(rootobject.elements[0].tags.name);
            rootobject.elements[0].NominatimRoot = coordinates;

            var result = AdministrativeUnitsConverter.ConvertToCountryAdministrativeUnit(rootobject.elements[0]);
            return result;
        }

        public List<AdministrativeUnitConverted> GetChildUnits(int id, string parentName, int admin_level)
        {
            Rootobject<UnitElement<ChildUnitTags>, ChildUnitTags> responseObject = new();

            if (admin_level < PropertyRestrictions.MIN_ADMIN_LEVEL || admin_level > PropertyRestrictions.MAX_ADMIN_LEVEL)
            {
                return null;
            }

            bool isChildFinded = false;
            while (!isChildFinded && admin_level < PropertyRestrictions.MAX_ADMIN_LEVEL)
            {
                admin_level++;
                string requestUrl = URLs.OVERPASS_API_URL + $"[out:json];area[name=\"{parentName.Replace(" ", "+")}\"];(rel[admin_level={admin_level}](area););out;";
                string response = DoRequest(requestUrl);
                var rootobject = JsonConvert.DeserializeObject<Rootobject<UnitElement<ChildUnitTags>,ChildUnitTags>>(response);
                if (rootobject.elements.Length < 1) continue;
                else isChildFinded = true;
                responseObject = rootobject;
            }

            foreach (var item in responseObject.elements)
            {
                var coordinates = GetUnitCoordinates(item.tags.name);
                item.NominatimRoot = coordinates;
            }

            var result = AdministrativeUnitsConverter.ConvertToChildAdministrativeUnitCollection(id, responseObject);

            return result;
        }

        public static Class1 GetUnitCoordinates(string unitName)
        {
            string requestUrl = URLs.NOMINATIM_API_URL + $"q={unitName}&polygon_geojson=1&format=jsonv2";
            string response = DoRequest(requestUrl);
            var rootobject = JsonConvert.DeserializeObject<List<Class1>>(response);
            return rootobject[0];
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
