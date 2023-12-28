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
    public class EquipmentTypeController : ControllerBase
    {
        private readonly ILogger<EquipmentTypeController> _logger;

        public EquipmentTypeController(ILogger<EquipmentTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<EquipmentType>> Get()
        {
            var result = await EquipmentTypeService.GetList();
            return result.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EquipmentType> GetById(int id)
        {
            var result = await EquipmentTypeService.GetById(id);
            return result;
        }
    }
}
