using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class BrigadeService: DbServiceBase
    {
        public static async Task<List<Brigade>> GetList()
        {
            var result = await Read<Brigade>("SELECT * FROM BRIGADES ORDER BY BRIGADE_ID DESC");

            foreach (var brigade in result)
            {
                brigade.EQUIPMENT = await EquipmentService.GetListByBrigadeId(brigade.BRIGADE_ID);
            }

            return result;
        }

        public static async Task<Brigade> GetById(int id)
        {
            var result = await Read<Brigade>($"SELECT * FROM BRIGADES WHERE BRIGADE_ID = {id}");

            var brigade = result.First();

            brigade.EQUIPMENT = await EquipmentService.GetListByBrigadeId(brigade.BRIGADE_ID);

            return brigade;
        }

        public static async Task<List<Brigade>> GetListByCallId(int callId)
        {
            var result = await Read<Brigade>($"EXEC GET_CALL_BRIGADES {callId}");

            foreach (var brigade in result)
            {
                brigade.EQUIPMENT = await EquipmentService.GetListByBrigadeId(brigade.BRIGADE_ID);
            }

            return result;
        }

        public static void Create(BrigadeCreateDto brigade)
        {
            string equipment = "";

            foreach (var id in brigade.EQUIPMENT_IDS)
            {
                equipment += $"{id};";
            }

            Procedure($"EXEC CREATE_BRIGADE '{brigade.BRIGADE_NAME}', '{equipment}'");
        }

        public static void Put(BrigadeUpdateDto brigade)
        {
            string equipment = "";

            foreach (var id in brigade.EQUIPMENT_IDS)
            {
                equipment += $"{id};";
            }

            Procedure($"EXEC UPDATE_BRIGADE {brigade.BRIGADE_ID},'{brigade.BRIGADE_NAME}', '{equipment}'");
        }

        public static void Delete(int brigadeId)
        {
            Procedure($"DELETE FROM BRIGADES WHERE BRIGADE_ID = {brigadeId}");
        }
    }
}
