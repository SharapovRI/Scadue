using AutoMapper;
using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using Scadue.Data.Models;

namespace Scadue.Business.MappingProfiles
{
    public class AdministrativeUnitProfile : Profile
    {
        public AdministrativeUnitProfile()
        {
            CreateMap<AdministrativeUnitRequestBusinessModel, AdministrativeUnitEntity>();
            CreateMap<AdministrativeUnitEntity, AdministrativeUnitResponseBusinessModel>();
        }
    }
}
