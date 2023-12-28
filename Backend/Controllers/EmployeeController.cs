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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [Decorators.Auth("Диспетчер", "Аналитик","Бригадир")]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Employee>> Get()
        {
            var result = await EmployeeService.GetList();
            return result.ToArray();
        }

        [Decorators.Auth()]
        [HttpPost]
        [Route("")]
        public void Create(EmployeeCreateDto employee)
        {
            EmployeeService.Create(employee);
        }

        [Decorators.Auth("Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("{id}")]
        public async Task<Employee> GetById(int id)
        {
            var result = await EmployeeService.GetById(id);
            return result;
        }

        [Decorators.Auth("Бригадир", "Сотрудник", "Диспетчер", "Аналитик")]
        [HttpGet]
        [Route("email/{email}")]
        public async Task<Employee> GetByEmail(string email)
        {
            var result = EmployeeService.GetByEmail(email);
            return result;
        }

        [Decorators.Auth()]
        [HttpPut]
        [Route("")]
        public void Put(EmployeeUpdateDto employee)
        {
            EmployeeService.Put(employee);
        }

        [Decorators.Auth()]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            EmployeeService.Delete(id);
        }
    }
}
