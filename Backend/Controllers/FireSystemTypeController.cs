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
    public class FireSystemTypeController : ControllerBase
    {
        private readonly ILogger<FireSystemTypeController> _logger;

        public FireSystemTypeController(ILogger<FireSystemTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<FireSystemType>> Get()
        {
            var result = await FireSystemTypeService.GetList();
            return result.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<FireSystemType> GetById(int id)
        {
            var result = await FireSystemTypeService.GetById(id);
            return result;
        }
    }
}
