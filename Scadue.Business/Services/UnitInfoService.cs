using AutoMapper;
using Newtonsoft.Json;
using Scadue.Business.Interfaces;
using Scadue.Business.Models;
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

            /*if (unit.ChildUnits is null || unit.ChildUnits.Count < 1)
            {*/
                if (unit.Buildings?.Count > 0)
                {
                    var existingEntity = unit.Buildings.Last();
                    var deserializeEntity = JsonConvert.DeserializeObject<IList<BuildingJSONModel>>(existingEntity.Data);

                    var result = _mapper.Map<IList<BuildingJSONModel>, IList<BuildingResponseBusinessModel>>(deserializeEntity);

                    foreach (var item in result)
                    {
                        item.UnitId = existingEntity.UnitId;
                        item.Unit = _mapper.Map<AdministrativeUnitEntity, AdministrativeUnitResponseBusinessModel>(existingEntity.Unit);
                    }

                    return result;
                }

                var buildings = _unitInfoRecipient.GetUnitInfo(unit.Id, unit.Name, unit.AdminLevel);
                var buildingsToJson = _mapper.Map<IList<BuildingConverted>, IList<BuildingJSONModel>>(buildings);

                var buildingsString = JsonConvert.SerializeObject(buildingsToJson);
                var buildingsToCreate = new BuildingRequestBusinessModel()
                {
                    Data = buildingsString,
                    UnitId = unit.Id,
                };

                var resultList = await CreateAsync(buildingsToCreate);

                return resultList;
            /*}
            else
            {
                List<BuildingResponseBusinessModel> resultList = new();
                foreach (var item in unit.ChildUnits)
                {
                    var buildings = await GetUnitInfo(item.AdminLevel, item.Name);
                    resultList.AddRange(buildings);
                }

                return resultList;
            }*/
        }

        public Task GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetListAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IList<BuildingResponseBusinessModel>> CreateAsync(BuildingRequestBusinessModel buildingRequestBusinessModel)
        {
            var building = _mapper.Map<BuildingRequestBusinessModel, BuildingEntity>(buildingRequestBusinessModel);

            var existingEntity = await _buildingRepository.CreateAsync(building);

            var deserializeEntity = JsonConvert.DeserializeObject<IList<BuildingJSONModel>>(existingEntity.Data);

            var result = _mapper.Map<IList<BuildingJSONModel>, IList<BuildingResponseBusinessModel>>(deserializeEntity);

            foreach (var item in result)
            {
                item.UnitId = existingEntity.UnitId;
                item.Unit = _mapper.Map<AdministrativeUnitEntity, AdministrativeUnitResponseBusinessModel>(existingEntity.Unit);
            }

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
