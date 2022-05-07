using AutoMapper;
using Scadue.Business.Models.Response;
using Scadue.Models.Response;

namespace Scadue.MappingProfiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingResponseBusinessModel, BuildingResponseAPIModel>();
        }
    }
}
