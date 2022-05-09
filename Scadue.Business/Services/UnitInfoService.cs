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
    public class UnitInfoService : IUnitInfoService
    {
        private readonly IMapper _mapper;
        private readonly IAdministrativeUnitRepository _administrativeUnitRepository;
        private readonly IUnitInfoRecipient _unitInfoRecipient;
        private readonly IBuildingRepository _buildingRepository;

        public UnitInfoService(IMapper mapper, IAdministrativeUnitRepository administrativeUnitRepository, IUnitInfoRecipient unitInfoRecipient, IBuildingRepository buildingRepository)
        {
            _mapper = mapper;
            _administrativeUnitRepository = administrativeUnitRepository;
            _unitInfoRecipient = unitInfoRecipient;
            _buildingRepository = buildingRepository;
        }

        public async Task<IList<BuildingResponseBusinessModel>> GetUnitInfo(int adminLevel, string unitName)
        {
            var unit = await _administrativeUnitRepository.GetUnitByName(unitName, true);

            if (unit is null)
            {
                return null;
            }

            if (unit.ChildUnits is null || unit.ChildUnits.Count < 1)
            {
                if (unit.Buildings?.Count > 0)
                {
                    return _mapper.Map<IList<BuildingEntity>, IList<BuildingResponseBusinessModel>>(unit.Buildings);  
                }

                var buildings = _unitInfoRecipient.GetUnitInfo(unit.Id, unit.Name, unit.AdminLevel);
                var buildingsToCreate = _mapper.Map<IList<BuildingConverted>, IList<BuildingRequestBusinessModel>>(buildings);

                List<BuildingResponseBusinessModel> resultList = new();

                await CreateRangeAsync(buildingsToCreate);

                unit = await _administrativeUnitRepository.GetUnitByName(unitName, true);

                resultList = _mapper.Map<List<BuildingEntity>, List<BuildingResponseBusinessModel>>((List<BuildingEntity>)unit.Buildings);
                return resultList;
            }
            else
            {
                List<BuildingResponseBusinessModel> resultList = new();
                foreach (var item in unit.ChildUnits)
                {
                    var buildings = await GetUnitInfo(item.AdminLevel, item.Name);
                    resultList.AddRange(buildings);
                }

                return resultList;
            }
        }

        public Task GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetListAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<BuildingResponseBusinessModel> CreateAsync(BuildingRequestBusinessModel buildingRequestBusinessModel)
        {
            var building = _mapper.Map<BuildingRequestBusinessModel, BuildingEntity>(buildingRequestBusinessModel);

            var existingEntity = await _buildingRepository.CreateAsync(building);

            var result = _mapper.Map<BuildingEntity, BuildingResponseBusinessModel>(existingEntity);

            return result;
        }

        public async Task CreateRangeAsync(IList<BuildingRequestBusinessModel> buildingRequestBusinessModel)
        {
            var building = _mapper.Map<IList<BuildingRequestBusinessModel>, IList<BuildingEntity>>(buildingRequestBusinessModel);

            await _buildingRepository.CreateRangeAsync(building);
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public object GetBuildingClassCounts(IList<BuildingResponseBusinessModel> buildingsCollection)
        {
            var companies = buildingsCollection
                    .GroupBy(p => p.Class)
                    .Select(g => new { Class = g.Key, Count = g.Count() });
            object result = new
            {
                buildings = companies,
                unitId = buildingsCollection[0].UnitId,
            };
            return result;
        }
    }
}
