using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.Tags;
using System.Collections.Generic;
using System.Linq;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Converters
{
    public class AdministrativeUnitsConverter
    {
        public static List<AdministrativeUnitConverted> ConvertToChildAdministrativeUnitCollection(int id, Rootobject<UnitElement<ChildUnitTags>, ChildUnitTags> rootobject)
        {
            List<AdministrativeUnitConverted> administrativeUnits = new();

            foreach (var item in rootobject?.elements)
            {
                administrativeUnits.Add(ConvertToChildAdministrativeUnit(id, item));
            }

            return administrativeUnits;
        }

        public static AdministrativeUnitConverted ConvertToChildAdministrativeUnit(int id, UnitElement<ChildUnitTags> element)
        {
            var tags = element?.tags;
            var members = element?.members;

            var childUnit = new AdministrativeUnitConverted
            {
                ISO3166 = tags?.ISO31662,
                Name = tags?.name,
                Population = tags.population,
                AdminLevel = tags.admin_level,
                Place = tags.place,
                ParentAdminUnitId = id,
                UnitCoordinates = ConvertUnitCoordinates(members),
            };

            var centerNode = members?.FirstOrDefault(p => p.type == "node" && p.role == "label");
            if (centerNode != null)
            {
                childUnit.CenterLatitude = centerNode.lat;
                childUnit.CenterLongitude = centerNode.lon;
            }

            return childUnit;
        }

        public static AdministrativeUnitConverted ConvertToCountryAdministrativeUnit(UnitElement<CountryUnitTags> element)
        {
            var tags = element?.tags;
            var members = element?.members;

            var childUnit = new AdministrativeUnitConverted
            {
                ISO3166 = tags?.ISO31661,
                Name = tags?.name,
                Population = tags.population,
                AdminLevel = tags.admin_level,
                UnitCoordinates = ConvertUnitCoordinates(members),
            };

            var centerNode = members?.FirstOrDefault(p => p.type == "node" && p.role == "label");
            if (centerNode != null)
            {
                childUnit.CenterLatitude = centerNode.lat;
                childUnit.CenterLongitude = centerNode.lon;
            }

            return childUnit;
        }

        public static IList<UnitCoordinatesConverted> ConvertUnitCoordinates(Member[] members)
        {
            List<UnitCoordinatesConverted> unitCoordinates = new();
            int number = 1;

            foreach (var item in members)
            {
                if (item.role == "outer")
                {
                    foreach (var geom in item.geometry)
                    {
                        UnitCoordinatesConverted coordinatesConverted = new()
                        {
                            Lat = geom.lat,
                            Lon = geom.lon,
                            Number = number,
                        };

                        number++;
                        unitCoordinates.Add(coordinatesConverted);
                    }
                }
            }

            return unitCoordinates;
        }
    }
}
