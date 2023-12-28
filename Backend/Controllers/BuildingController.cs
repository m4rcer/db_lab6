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
    public class BuildingController : ControllerBase
    {
        private readonly ILogger<BrigadeController> _logger;

        public BuildingController(ILogger<BrigadeController> logger)
        {
            _logger = logger;
        }

        [Decorators.Auth("Бригадир", "Сотрудник", "Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Building>> Get()
        {
            var result = await BuildingService.GetList();
            return result.ToArray();
        }

        [Decorators.Auth("Бригадир", "Сотрудник", "Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("{id}")]
        public async Task<Building> GetById(int id)
        {
            var result = await BuildingService.GetById(id);
            return result;
        }

        [Decorators.Auth()]
        [HttpPost]
        [Route("")]
        public void Create(BuildingCreateDto building)
        {
            BuildingService.Create(building);
        }

        [Decorators.Auth()]
        [HttpPut]
        [Route("")]
        public void Put(BuildingUpdateDto building)
        {
            BuildingService.Put(building);
        }

        [Decorators.Auth()]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            BuildingService.Delete(id);
        }
    }
}
