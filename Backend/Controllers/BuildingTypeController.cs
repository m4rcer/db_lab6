using Backend.Models;
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
    public class BuildingTypeController : ControllerBase
    {
        private readonly ILogger<BuildingTypeController> _logger;

        public BuildingTypeController(ILogger<BuildingTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BuildingType>> Get()
        {
            var result = await BuildingTypeService.GetList();
            return result.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BuildingType> GetById(int id)
        {
            var result = await BuildingTypeService.GetById(id);
            return result;
        }
    }
}
