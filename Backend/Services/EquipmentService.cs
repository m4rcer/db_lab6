using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.Services
{
    public class EquipmentService : DbServiceBase
    {
        public static async Task<List<Equipment>> GetList()
        {
            var result = await Read<Equipment>("EXEC GET_EQUIPMENT");

            return result;
        }

        public static async Task<List<Equipment>> GetListByBrigadeId(int brigadeId)
        {
            var result = await Read<Equipment>($"EXEC GET_EQUIPMENT_BY_BRIGADE_IDS {brigadeId}");

            return result;
        }

        public static async Task<Equipment> GetById(int id)
        {
            var result = await Read<Equipment>($"GET_EQUIPMENT_BY_ID {id}");

            return result.First();

        }

        public static void Create(EquipmentCreateDto equipment)
        {
            Procedure($"INSERT INTO EQUIPMENT (INVENTORY_NUMBER,EQUIPMENT_TYPE_ID) VALUES ('{equipment.INVENTORY_NUMBER}',{equipment.EQUIPMENT_TYPE_ID})");
        }

        public static void Put(EquipmentUpdateDto equipment)
        {
            Procedure($"UPDATE EQUIPMENT SET INVENTORY_NUMBER='{equipment.INVENTORY_NUMBER}',EQUIPMENT_TYPE_ID = {equipment.EQUIPMENT_TYPE_ID} WHERE EQUIPMENT.EQUIPMENT_ID = {equipment.EQUIPMENT_ID}");
        }

        public static void Delete(int equipmentId)
        {
            Procedure($"DELETE FROM EQUIPMENT WHERE EQUIPMENT_ID = {equipmentId}");
        }
    }
}
