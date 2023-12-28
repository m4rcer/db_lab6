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
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(ILogger<ScheduleController> logger)
        {
            _logger = logger;
        }


        [Decorators.Auth("Бригадир", "Диспетчер", "Аналитик","Сотрудник")]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Schedule>> Get()
        {
            var result = await ScheduleService.GetList();
            return result.ToArray();
        }

        [Decorators.Auth()]
        [HttpPost]
        [Route("")]
        public void Create(ScheduleCreateDto schedule)
        {
            ScheduleService.Create(schedule);
        }

        [Decorators.Auth("Бригадир", "Диспетчер", "Аналитик", "Сотрудник")]
        [HttpGet]
        [Route("{id}")]
        public async Task<Schedule> GetById(int id)
        {
            var result = await ScheduleService.GetById(id);
            return result;
        }

        [Decorators.Auth("Бригадир", "Диспетчер", "Аналитик", "Сотрудник")]
        [HttpGet]
        [Route("employee/{id}")]
        public async Task<IEnumerable<Schedule>> GetByEmployeeId(int id)
        {
            var result = await ScheduleService.GetListByEmployeeId(id);
            return result.ToArray();
        }

        [Decorators.Auth("Бригадир", "Диспетчер", "Аналитик", "Сотрудник")]
        [HttpGet]
        [Route("brigade/{id}")]
        public async Task<IEnumerable<Schedule>> GetByBrigadeId(int id)
        {
            var result = await ScheduleService.GetListByBrigadeId(id);
            return result.ToArray();
        }

        [Decorators.Auth()]
        [HttpPut]
        [Route("")]
        public void Put(ScheduleUpdateDto schedule)
        {
            ScheduleService.Put(schedule);
        }

        [Decorators.Auth()]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            ScheduleService.Delete(id);
        }
    }
}
