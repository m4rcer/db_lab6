using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class CallService : DbServiceBase
    {
        public static async Task<List<Call>> GetList()
        {
            var result = await Read<Call>("EXEC GET_CALLS");

            foreach (var call in result)
            {
                call.BUILDINGS = await BuildingService.GetListByCallId(call.CALL_ID);
                call.BRIGADES = await BrigadeService.GetListByCallId(call.CALL_ID);
            }

            return result;
        }

        public static async Task<Call> GetById(int id)
        {
            var result = await Read<Call>($"EXEC GET_CALL_BY_ID {id}");

            var call = result.First();

            call.BUILDINGS = await BuildingService.GetListByCallId(call.CALL_ID);

            call.BRIGADES = await BrigadeService.GetListByCallId(call.CALL_ID);

            return call;
        }

        public static void Create(CallCreateDto call)
        {
            string buildings = "";

            foreach (var id in call.BUILDING_IDS)
            {
                buildings += $"{id};";
            }

            string brigades = "";

            foreach (var id in call.BRIGADE_IDS)
            {
                brigades += $"{id};";
            }

            Procedure($"EXEC CREATE_CALL '{call.VICTIMS_FULL_NAME}', '{call.@CALL_TEXT}', {call.EMPLOYEE_ID},'{brigades}', '{buildings}'");
        }

        public static void Put(CallUpdateDto call)
        {
            string buildings = "";

            foreach (var id in call.BUILDING_IDS)
            {
                buildings += $"{id};";
            }

            string brigades = "";

            foreach (var id in call.BRIGADE_IDS)
            {
                brigades += $"{id};";
            }

            Procedure($"EXEC UPDATE_CALL {call.CALL_ID}, '{call.VICTIMS_FULL_NAME}', '{call.@CALL_TEXT}', {call.EMPLOYEE_ID},'{brigades}', '{buildings}', '{call.REPORT}', {(call.BRIGADE_DISPATCH_TIME == null ? "null" : $"'{call.BRIGADE_DISPATCH_TIME}'")}, {(call.BRIGADE_ARRIVAL_TIME == null ? "null" : $"'{call.BRIGADE_ARRIVAL_TIME}'")}, {(call.BRIGADE_RETURN_TIME == null ? "null" : $"'{call.BRIGADE_RETURN_TIME}'")}");
        }

        public static void Delete(int callId)
        {
            Procedure($"DELETE FROM CALLS WHERE CALL_ID = {callId}");
        }
    }
}
