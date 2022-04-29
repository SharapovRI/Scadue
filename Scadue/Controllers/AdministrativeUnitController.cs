using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scadue.Business.Interfaces;
using Scadue.Business.Models.Response;
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
    }
}
