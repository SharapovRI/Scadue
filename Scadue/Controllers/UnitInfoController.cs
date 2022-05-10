using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scadue.Business.Interfaces;
using Scadue.Business.Models.Response;
using Scadue.Models.Request;
using Scadue.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scadue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UnitInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitInfoService _unitInfoService;

        public UnitInfoController(IMapper mapper, IUnitInfoService unitInfoService)
        {
            _mapper = mapper;
            _unitInfoService = unitInfoService;
        }

        [HttpGet("/UnitInfo")]
        public async Task<IActionResult> GetUnitInfo([FromQuery] UnitInfoRequestAPIModel unitInfoRequest)
        {
            var units = await _unitInfoService.GetUnitInfo(unitInfoRequest.AdminLevel, unitInfoRequest.UnitName);
            if(units is not null && units?.Count > 0)
            {
                var result = _unitInfoService.GetBuildingClassCounts(units);
                return Ok(result);
            }
            else 
            {
                var result = _mapper.Map<IList<BuildingResponseBusinessModel>, IList<BuildingResponseAPIModel>>(units);
                return Ok(result);
            }
        }

        [HttpPost("/UnitCollectionInfo")]
        public async Task<IActionResult> GetUnitCollectionInfo([FromBody] UnitInfoRequestAPIModel[] coll)
        {
            List<object > collection = new();
            foreach (var item in coll)
            {
                var units = await _unitInfoService.GetUnitInfo(item.AdminLevel, item.UnitName);
                if (units is not null || units?.Count > 0)
                {
                    var result = _unitInfoService.GetBuildingClassCounts(units);
                    collection.Add(result);
                }
            }
            return Ok(collection);
            /*else
            {
                var result = _mapper.Map<IList<BuildingResponseBusinessModel>, IList<BuildingResponseAPIModel>>(collection);
                return Ok(result);
            }*/
        }
    }
}
