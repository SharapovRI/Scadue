using AutoMapper;
using Scadue.Business.Interfaces;
using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using Scadue.Data.Interfaces;
using Scadue.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scadue.Business.Services
{
    public class AdministrativeUnitService : IAdministrativeUnitService
    {
        private readonly IMapper _mapper;
        private readonly IAdministrativeUnitRepository _administrativeUnitRepository;
        public AdministrativeUnitService(IMapper mapper, IAdministrativeUnitRepository administrativeUnitRepository)
        {
            _mapper = mapper;
            _administrativeUnitRepository = administrativeUnitRepository;
        }
        public Task<AdministrativeUnitResponseBusinessModel> CreateAsync(AdministrativeUnitRequestBusinessModel hotelModel)
        {
            throw new NotImplementedException();
        }

        public Task<AdministrativeUnitResponseBusinessModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdministrativeUnitResponseBusinessModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AdministrativeUnitResponseBusinessModel>> GetListAsync()
        {
            var units = await _administrativeUnitRepository.GetListAsync();

            return _mapper.Map<IEnumerable<AdministrativeUnitEntity>, IEnumerable<AdministrativeUnitResponseBusinessModel>>(units);
        }

        public Task<AdministrativeUnitResponseBusinessModel> UpdateAsync(AdministrativeUnitRequestBusinessModel hotelModel)
        {
            throw new NotImplementedException();
        }
    }
}
