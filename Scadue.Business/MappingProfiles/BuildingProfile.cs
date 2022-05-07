using AutoMapper;
using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using Scadue.Data.Models;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;

namespace Scadue.Business.MappingProfiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingEntity, BuildingResponseBusinessModel>();
            CreateMap<BuildingConverted, BuildingRequestBusinessModel>();
            CreateMap<BuildingRequestBusinessModel, BuildingEntity>();            
        }
    }
}