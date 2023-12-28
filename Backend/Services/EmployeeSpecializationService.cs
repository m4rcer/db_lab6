using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class EmployeeSpecializationService : DbServiceBase
    {
        public static async Task<List<EmployeeSpecialization>> GetList()
        {
            var result = await Read<EmployeeSpecialization>("SELECT * FROM EMPLOYEE_SPECIALIZATIONS ORDER BY EMPLOYEE_SPECIALIZATION_ID DESC");

            return result;
        }

        public static async Task<EmployeeSpecialization> GetById(int id)
        {
            var result = await Read<EmployeeSpecialization>($"SELECT * FROM EMPLOYEE_SPECIALIZATIONS WHERE EMPLOYEE_SPECIALIZATION_ID = {id}");

            return result.First();
        }
    }
}
