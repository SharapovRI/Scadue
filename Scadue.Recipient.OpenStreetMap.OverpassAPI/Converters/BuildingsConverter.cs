using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Elements;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Models.OverpassModels.Tags;
using System;
using System.Collections.Generic;

namespace Scadue.Recipient.OpenStreetMap.OverpassAPI.Converters
{
    public class BuildingsConverter
    {
        public static List<BuildingConverted> ConvertToBuildingCollection(int id, string buildingClass, List<BuildingElement<BuildingTags>> buildings)
        {
            List<BuildingConverted> administrativeUnits = new();

            foreach (var item in buildings)
            {
                administrativeUnits.Add(ConvertToBuilding(id, buildingClass, item));
            }

            return administrativeUnits;
        }

        public static BuildingConverted ConvertToBuilding(int id, string buildingClass, BuildingElement<BuildingTags> element)
        {
            var tags = (BuildingTags)element?.tags;

            var building = new BuildingConverted
            {
                Class = buildingClass,
                Type = tags?.building ?? buildingClass,
                Name = tags?.name,
                FloorsNumber = 0,
                Adress = tags?.addrstreet + ", " + tags?.addrhousenumber,
                CenterLatitude = element.center.lat,
                CenterLongitude = element.center.lon,
                UnitId = id,
            };

            int floors = 0;
            int.TryParse(tags.buildinglevels, out floors);
            building.FloorsNumber = floors;

            return building;
        }
    }
}
