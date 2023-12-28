using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class BuildingTypeService: DbServiceBase
    {
        public static async Task<List<BuildingType>> GetList()
        {
            var result = await Read<BuildingType>("SELECT * FROM BUILDING_TYPES ORDER BY BUILDING_TYPE_ID DESC");

            return result;
        }

        public static async Task<BuildingType> GetById(int id)
        {
            var result = await Read<BuildingType>($"SELECT * FROM BUILDING_TYPES WHERE BUILDING_TYPE_ID = {id}");

            return result.First();
        }
    }
}
