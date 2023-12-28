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
    public class EmployeeSpecializationController : ControllerBase
    {
        
        private readonly ILogger<EmployeeSpecializationController> _logger;

        public EmployeeSpecializationController(ILogger<EmployeeSpecializationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<EmployeeSpecialization>> Get()
        {
            var result = await EmployeeSpecializationService.GetList();
            return result.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeSpecialization> GetById(int id)
        {
            var result = await EmployeeSpecializationService.GetById(id);
            return result;
        }
    }
}
