using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class FireSystemTypeService : DbServiceBase
    {
        public static async Task<List<FireSystemType>> GetList()
        {
            var result = await Read<FireSystemType>("SELECT * FROM FIRE_SYSTEM_TYPES ORDER BY FIRE_SYSTEM_TYPE_ID DESC");

            return result;
        }

        public static async Task<List<FireSystemType>> GetListByBuildingId(int? buildingId)
        {
            var result = await Read<FireSystemType>($"EXEC GET_BUILDING_FIRE_SYSTEMS {buildingId}");

            return result;
        }


        public static async Task<FireSystemType> GetById(int id)
        {
            var result = await Read<FireSystemType>($"SELECT * FROM FIRE_SYSTEM_TYPES WHERE FIRE_SYSTEM_TYPE_ID = {id}");

            return result.First();
        }
    }
}
