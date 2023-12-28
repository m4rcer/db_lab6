using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class EmployeeService : DbServiceBase
    {
        public static async Task<List<Employee>> GetList()
        {
            var result = await Read<Employee>("EXEC GET_EMPLOYEES");

            return result;
        }

        public static async Task<Employee> GetById(int id)
        {
            var result = await Read<Employee>($"EXEC GET_EMPLOYEE_BY_ID {id}");

            return result.First();
        }

        public static Employee GetByEmail(string email)
        {
            var result = ReadSync<Employee>($"EXEC GET_EMPLOYEE_BY_EMAIL '{email}'");

            return result.First();
        }

        public static void Create(EmployeeCreateDto employee)
        {
            Procedure($"EXEC CREATE_EMPLOYEE '{employee.EMPLOYEE_NAME}', '{employee.EMPLOYEE_SURNAME}', '{employee.EMPLOYEE_FATHERS_NAME}','{employee.EMPLOYEE_PHONE_NUMBER}', '{employee.EMPLOYEE_EMAIL}', '{employee.EMPLOYEE_PASSWORD}',{(employee.EMPLOYEE_SPECIALIZATION_ID == null ? "null" : employee.EMPLOYEE_SPECIALIZATION_ID)}, {(employee.BRIGADE_ID == null ? "null" : employee.BRIGADE_ID)}");
        }

        public static void Put(EmployeeUpdateDto employee)
        {
            Procedure($"EXEC UPDATE_EMPLOYEE {employee.EMPLOYEE_ID}, '{employee.EMPLOYEE_NAME}', '{employee.EMPLOYEE_SURNAME}', '{employee.EMPLOYEE_FATHERS_NAME}','{employee.EMPLOYEE_PHONE_NUMBER}', '{employee.EMPLOYEE_EMAIL}', '{employee.EMPLOYEE_PASSWORD}',{(employee.EMPLOYEE_SPECIALIZATION_ID == null ? "null" : employee.EMPLOYEE_SPECIALIZATION_ID)}, {(employee.BRIGADE_ID == null ? "null" : employee.BRIGADE_ID)}");
        }

        public static void Delete(int employeeId)
        {
            Procedure($"DELETE FROM EMPLOYEES WHERE EMPLOYEE_ID = {employeeId}");
        }
    }
}
