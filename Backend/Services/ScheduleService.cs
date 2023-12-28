using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.Services
{
    public class ScheduleService : DbServiceBase
    {
        public static async Task<List<Schedule>> GetList()
        {
            var result = await Read<Schedule>("EXEC GET_SCHEDULE");

            return result;
        }

        public static async Task<List<Schedule>> GetListByEmployeeId(int employeeId)
        {
            var result = await Read<Schedule>($"EXEC GET_SCHEDULE_BY_EMPLOYEE_ID {employeeId}");

            return result;
        }

        public static async Task<List<Schedule>> GetListByBrigadeId(int brigadeeId)
        {
            var result = await Read<Schedule>($"EXEC GET_SCHEDULE_BY_BRIGADE_ID {brigadeeId}");

            return result;
        }

        public static async Task<Schedule> GetById(int id)
        {
            var result = await Read<Schedule>($"GET_SCHEDULE_BY_ID {id}");

            return result.First();
        }

        public static void Create(ScheduleCreateDto schedule)
        {
            Procedure($"INSERT INTO SCHEDULE (START_DATE,END_DATE,BRIGADE_ID,EMPLOYEE_ID) VALUES ('{schedule.START_DATE}','{schedule.END_DATE}',{(schedule.BRIGADE_ID == null ? "null" : schedule.BRIGADE_ID)},{(schedule.EMPLOYEE_ID == null ? "null" : schedule.EMPLOYEE_ID)})");
        }

        public static void Put(ScheduleUpdateDto schedule)
        {
            Procedure($"UPDATE SCHEDULE SET START_DATE='{schedule.START_DATE}',END_DATE='{schedule.END_DATE}',BRIGADE_ID={(schedule.BRIGADE_ID == null ? "null" : schedule.BRIGADE_ID)},EMPLOYEE_ID={(schedule.EMPLOYEE_ID == null ? "null" : schedule.EMPLOYEE_ID)} WHERE SCHEDULE_ID={schedule.SCHEDULE_ID}");
        }

        public static void Delete(int scheduleId)
        {
            Procedure($"DELETE FROM SCHEDULE WHERE SCHEDULE_ID = {scheduleId}");
        }
    }
}
