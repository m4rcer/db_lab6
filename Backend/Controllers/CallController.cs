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
    public class CallController : ControllerBase
    {
        private readonly ILogger<CallController> _logger;

        public CallController(ILogger<CallController> logger)
        {
            _logger = logger;
        }

        [Decorators.Auth("Бригадир", "Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Call>> Get()
        {
            var result = await CallService.GetList();
            return result.ToArray();
        }

        [Decorators.Auth("Диспетчер")]
        [HttpPost]
        [Route("")]
        public void Create(CallCreateDto call)
        {
            CallService.Create(call);
        }

        [Decorators.Auth("Бригадир", "Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("{id}")]
        public async Task<Call> GetById(int id)
        {
            var result = await CallService.GetById(id);
            return result;
        }

        [Decorators.Auth("Бригадир", "Диспетчер")]
        [HttpPut]
        [Route("")]
        public void Put(CallUpdateDto call)
        {
            CallService.Put(call);
        }

        [Decorators.Auth()]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            CallService.Delete(id);
        }
    }
}
