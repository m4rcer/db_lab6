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
    public class BrigadeController : ControllerBase
    {
        private readonly ILogger<BrigadeController> _logger;

        public BrigadeController(ILogger<BrigadeController> logger)
        {
            _logger = logger;
        }

        [Decorators.Auth("Бригадир", "Сотрудник", "Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Brigade>> Get()
        {
            var result = await BrigadeService.GetList();
            return result.ToArray();
        }

        [Decorators.Auth("Бригадир", "Сотрудник", "Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("{id}")]
        public async Task<Brigade> GetById(int id)
        {
            var result = await BrigadeService.GetById(id);
            return result;
        }

        [Decorators.Auth()]
        [HttpPost]
        [Route("")]
        public void Create(BrigadeCreateDto brigade)
        {
            BrigadeService.Create(brigade);
        }

        [Decorators.Auth()]
        [HttpPut]
        [Route("")]
        public void Put(BrigadeUpdateDto brigade)
        {
            BrigadeService.Put(brigade);
        }

        [Decorators.Auth()]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            BrigadeService.Delete(id);
        }
    }
}
