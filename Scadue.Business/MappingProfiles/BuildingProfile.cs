using AutoMapper;
using Scadue.Business.Models;
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
            CreateMap<BuildingEntity, BuildingResponseBusinessModel>()
                .ForMember(dest => dest.Type, act => act.Ignore())
                .ForMember(dest => dest.Adress, act => act.Ignore())
                .ForMember(dest => dest.CenterLatitude, act => act.Ignore())
                .ForMember(dest => dest.CenterLongitude, act => act.Ignore())
                .ForMember(dest => dest.Class, act => act.Ignore())
                .ForMember(dest => dest.FloorsNumber, act => act.Ignore())
                .ForMember(dest => dest.Name, act => act.Ignore());
            CreateMap<BuildingJSONModel, BuildingResponseBusinessModel>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.Unit, act => act.Ignore())
                .ForMember(dest => dest.UnitId, act => act.Ignore());
            CreateMap<BuildingConverted, BuildingRequestBusinessModel>();
            CreateMap<BuildingConverted, BuildingJSONModel>();
            CreateMap<BuildingRequestBusinessModel, BuildingEntity>();            
        }
    }
}