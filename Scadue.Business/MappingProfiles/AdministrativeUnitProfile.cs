using AutoMapper;
using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using Scadue.Data.Models;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;

namespace Scadue.Business.MappingProfiles
{
    public class AdministrativeUnitProfile : Profile
    {
        public AdministrativeUnitProfile()
        {
            CreateMap<AdministrativeUnitRequestBusinessModel, AdministrativeUnitEntity>();
            CreateMap<AdministrativeUnitEntity, AdministrativeUnitResponseBusinessModel>();

            CreateMap<AdministrativeUnitConverted, AdministrativeUnitRequestBusinessModel>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.ParentAdministrativeUnit, act => act.Ignore())
                .ForMember(dest => dest.ChildUnits, act => act.Ignore());

            CreateMap<AdministrativeUnitConverted, AdministrativeUnitResponseBusinessModel>()
                .ForMember(dest => dest.ParentAdministrativeUnit, act => act.Ignore())
                .ForMember(dest => dest.ChildUnits, act => act.Ignore())
                .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<UnitCoordinatesConverted, UnitCoordinatesRequestBusinessModel>();
            CreateMap<UnitCoordinatesRequestBusinessModel, UnitCoordinatesEntity>()
                .ForMember(dest => dest.AdministrativeUnit, act => act.Ignore());
            CreateMap<UnitCoordinatesEntity, UnitCoordinatesResponseBusinessModel>();
        }
    }
}
