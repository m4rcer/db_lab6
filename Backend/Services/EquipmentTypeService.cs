using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class EquipmentTypeService:DbServiceBase
    {
        public static async Task<List<EquipmentType>> GetList()
        {
            var result = await Read<EquipmentType>("SELECT * FROM EQUIPMENT_TYPES ORDER BY EQUIPMENT_TYPE_ID DESC");

            return result;
        }

        public static async Task<EquipmentType> GetById(int id)
        {
            var result = await Read<EquipmentType>($"SELECT * FROM EQUIPMENT_TYPES WHERE EQUIPMENT_TYPE_ID = {id}");

            return result.First();
        }
    }
}
