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
            var result = _mapper.Map<IList<BuildingResponseBusinessModel>, IList< BuildingResponseAPIModel>>(units);
            return Ok(result);
        }
    }
}
