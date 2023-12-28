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
    public class EquipmentController : ControllerBase
    {
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(ILogger<EquipmentController> logger)
        {
            _logger = logger;
        }

        [Decorators.Auth("Бригадир", "Аналитик")]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Equipment>> Get()
        {
            var result = await EquipmentService.GetList();
            return result.ToArray();
        }

        [Decorators.Auth("Бригадир")]
        [HttpPost]
        [Route("")]
        public void Create(EquipmentCreateDto equipment)
        {
            EquipmentService.Create(equipment);
        }

        [Decorators.Auth("Бригадир","Аналитик")]
        [HttpGet]
        [Route("{id}")]
        public async Task<Equipment> GetById(int id)
        {
            var result = await EquipmentService.GetById(id);
            return result;
        }

        [Decorators.Auth()]
        [HttpPut]
        [Route("")]
        public void Put(EquipmentUpdateDto equipment)
        {
            EquipmentService.Put(equipment);
        }

        [Decorators.Auth()]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            EquipmentService.Delete(id);
        }
    }
}
