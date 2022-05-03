using AutoMapper;
using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using Scadue.Models.Request;
using Scadue.Models.Response;

namespace Scadue.MappingProfiles
{
    public class AdministrativeUnitProfile : Profile
    {
        public AdministrativeUnitProfile()
        {
            CreateMap<AdministrativeUnitRequestAPIModel, AdministrativeUnitRequestBusinessModel>()
                .ForMember(dest => dest.ParentAdministrativeUnit, act => act.Ignore());
            CreateMap<AdministrativeUnitResponseBusinessModel, AdministrativeUnitResponseAPIModel>();

            CreateMap<UnitCoordinatesRequestAPIModel, UnitCoordinatesRequestBusinessModel>();
            CreateMap<UnitCoordinatesResponseBusinessModel, UnitCoordinatesResponseAPIModel>();
        }
    }
}
