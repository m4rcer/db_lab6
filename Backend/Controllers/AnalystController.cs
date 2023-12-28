using Backend.Models;
using Backend.Models.Analyst;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalystController : ControllerBase
    {
        private readonly ILogger<AnalystController> _logger;

        public AnalystController(ILogger<AnalystController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("CountCallsPerDate")]
        public async Task<List<CallDateCount>> CountCallsPerDate()
        {
            var result = await AnalystService.CountCallsByDate();
            return result;
        }

        [HttpGet]
        [Route("CountCallsByBuildingType/{type}")]
        public async Task<CallsCountByBuilding> CountCallsByBuildingType(string type)
        {
            var result = await AnalystService.CountCallsByBuildingType(type);
            return result;
        }

        [HttpGet]
        [Route("CountBrigadesPerCall")]
        public async Task<BrigadesPerCall> CountBrigadesPerCall()
        {
            var result = await AnalystService.CountBrigadesPerCall();
            return result;
        }

        [HttpGet]
        [Route("CalculateAverageTravelTime")]
        public async Task<AverageTravelTime> CalculateAverageTravelTime()
        {
            var result = await AnalystService.CalculateAverageTravelTime();
            return result;
        }
    }
}
