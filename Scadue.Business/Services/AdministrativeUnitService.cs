using AutoMapper;
using Scadue.Business.Interfaces;
using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using Scadue.Data.Interfaces;
using Scadue.Data.Models;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.ConvertedModels;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;
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
        private readonly IAdministrativeUnitRecipient _administrativeUnitRecipient;
        public AdministrativeUnitService(IMapper mapper, IAdministrativeUnitRepository administrativeUnitRepository, IAdministrativeUnitRecipient administrativeUnitRecipient)
        {
            _mapper = mapper;
            _administrativeUnitRepository = administrativeUnitRepository;
            _administrativeUnitRecipient = administrativeUnitRecipient;
        }
        public async Task<AdministrativeUnitResponseBusinessModel> CreateAsync(AdministrativeUnitRequestBusinessModel administrativeUnitRequestBusinessModel)
        {
            var administrativeUnit = _mapper.Map<AdministrativeUnitRequestBusinessModel, AdministrativeUnitEntity>(administrativeUnitRequestBusinessModel);

            var existingEntity = await _administrativeUnitRepository.CreateAsync(administrativeUnit);

            var result = _mapper.Map<AdministrativeUnitEntity, AdministrativeUnitResponseBusinessModel>(existingEntity);

            return result;
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

        public async Task<AdministrativeUnitResponseBusinessModel> GetCountryAsync(string unitName)
        {
            if (string.IsNullOrWhiteSpace(unitName))
            {
                throw new Exception("Bad request");
            }

            var unit = await _administrativeUnitRepository.GetUnitByName(unitName, false);

            if (unit != null)
            {
                return _mapper.Map<AdministrativeUnitEntity, AdministrativeUnitResponseBusinessModel> (unit);
            }

            var country = _administrativeUnitRecipient.GetCountry(unitName);
            var createRequestModel = _mapper.Map<AdministrativeUnitConverted, AdministrativeUnitRequestBusinessModel>(country);
            var responseModel = await CreateAsync(createRequestModel);

            return responseModel;
        }


        public async Task<IList<AdministrativeUnitResponseBusinessModel>> GetChildUnitsAsync(string parentName)
        {
            if (string.IsNullOrWhiteSpace(parentName))
            {
                throw new Exception("Bad request");
            }

            var parentUnit = await _administrativeUnitRepository.GetUnitByName(parentName);

            if (parentUnit is null)
            {
                throw new Exception("В бд нет такого родительского юнита");
            }
            else if (parentUnit?.ChildUnits.Count > 0)
            {
                return _mapper.Map<IList<AdministrativeUnitEntity>, IList<AdministrativeUnitResponseBusinessModel>>(parentUnit.ChildUnits);
            }
            else
            {
                var convertedModels = await _administrativeUnitRecipient.GetChildUnits(parentUnit.Id, parentUnit.Name, parentUnit.AdminLevel);
                var createRequestModel = _mapper.Map<IList<AdministrativeUnitConverted>, IList<AdministrativeUnitRequestBusinessModel>>(convertedModels);
                
                List<AdministrativeUnitResponseBusinessModel> resultList = new();
                foreach (var item in createRequestModel)
                {
                    resultList.Add(await CreateAsync(item));
                }

                return resultList;
            }
        }

        public async Task<IList<AdministrativeUnitResponseBusinessModel>> GetUnitByNameAsync(string unitName)
        {
            if (string.IsNullOrWhiteSpace(unitName))
            {
                throw new Exception("Bad request");
            }

            var unit = await _administrativeUnitRepository.GetUnitByName(unitName);

            if (unit != null)
            {
                return null;
            }

            var units = _administrativeUnitRecipient.GetUnitsByName(unitName);
            var responseModel = _mapper.Map<IList<AdministrativeUnitConverted>, IList<AdministrativeUnitResponseBusinessModel>>(units);

            return responseModel;
        }
        public Task<AdministrativeUnitResponseBusinessModel> UpdateAsync(AdministrativeUnitRequestBusinessModel hotelModel)
        {
            throw new NotImplementedException();
        }
    }
}
