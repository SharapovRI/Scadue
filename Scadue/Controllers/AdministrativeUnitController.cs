using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scadue.Business.Interfaces;
using Scadue.Business.Models.Response;
using Scadue.Models.Request;
using Scadue.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scadue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdministrativeUnitController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdministrativeUnitService _administrativeUnitService;

        public AdministrativeUnitController(IMapper mapper, IAdministrativeUnitService administrativeUnitService)
        {
            _administrativeUnitService = administrativeUnitService;
            _mapper = mapper;
        }

        [HttpGet("/AdministrativeUnits")]
        public async Task<IActionResult> AdministrativeUnits()
        {
            var units = await _administrativeUnitService.GetListAsync();
            var result = _mapper.Map<IEnumerable<AdministrativeUnitResponseBusinessModel>, IEnumerable<AdministrativeUnitResponseAPIModel>>(units);
            return Ok(result);
        }

        [HttpGet("/AdministrativeUnits/Country/{unit_name}")]
        public async Task<IActionResult> GetCountryUnit(string unit_name)
        {
            var units = await _administrativeUnitService.GetCountryAsync(unit_name);
            var result = _mapper.Map<AdministrativeUnitResponseBusinessModel, AdministrativeUnitResponseAPIModel>(units);
            return Ok(result);
        }

        [HttpGet("/AdministrativeUnits/ChildUnits/{unit_name}")]
        public async Task<IActionResult> GetChildUnits(string unit_name)
        {
            var units = await _administrativeUnitService.GetChildUnitsAsync(unit_name);
            var result = _mapper.Map<IList<AdministrativeUnitResponseBusinessModel>, IList<AdministrativeUnitResponseAPIModel>>(units);
            return Ok(result);
        }

        [HttpGet("/AdministrativeUnits/Unit/{unit_name}")]
        public async Task<IActionResult> GetUnit(string unit_name)
        {
            var units = await _administrativeUnitService.GetUnitByNameAsync(unit_name);
            var result = _mapper.Map<AdministrativeUnitResponseBusinessModel, AdministrativeUnitResponseAPIModel>(units);
            return Ok(result);
        }
    }
}
