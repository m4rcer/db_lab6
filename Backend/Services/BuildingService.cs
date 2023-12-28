using Backend.DbServices;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.Services
{
    public class BuildingService : DbServiceBase
    {
        public static async Task<List<Building>> GetList()
        {
            var result = await Read<Building>("EXEC GET_BUILDINGS");

            foreach (var building in result)
            {
                building.FIRE_SYSTEMS = await FireSystemTypeService.GetListByBuildingId(building.BUILDING_ID);
            }


            return result;
        }

        public static async Task<List<Building>> GetListByCallId(int callId)
        {
            var result = await Read<Building>($"EXEC GET_CALL_BUILDINGS {callId}");

            foreach (var building in result)
            {
                building.FIRE_SYSTEMS = await FireSystemTypeService.GetListByBuildingId(building.BUILDING_ID);
            }


            return result;
        }

        public static async Task<Building> GetById(int id)
        {
            var result = await Read<Building>($"GET_BUILDING_BY_ID {id}");

            var building = result.First();

            building.FIRE_SYSTEMS = await FireSystemTypeService.GetListByBuildingId(building.BUILDING_ID);

            return building;

        }

        public static void Create(BuildingCreateDto building)
        {
            string fireSystemTypes = "";

            foreach (var id in building.FIRE_SYSTEM_TYPE_IDS)
            {
                fireSystemTypes += $"{id};";
            }

            Procedure($"EXEC CREATE_BUILDING '{building.BUILDING_ADDRESS}', {building.NUMBER_OF_FLOORS}, {building.BUILDING_TYPE_ID}, '{fireSystemTypes}'");
        }

        public static void Put(BuildingUpdateDto building)
        {
            string fireSystemTypes = "";

            foreach (var id in building.FIRE_SYSTEM_TYPE_IDS)
            {
                fireSystemTypes += $"{id};";
            }

            Procedure($"EXEC UPDATE_BUILDING {building.BUILDING_ID}, '{building.BUILDING_ADDRESS}', '{building.NUMBER_OF_FLOORS}', {building.BUILDING_TYPE_ID}, '{fireSystemTypes}'");
        }

        public static void Delete(int buildingId)
        {
            Procedure($"DELETE FROM BUILDINGS WHERE BUILDING_ID = {buildingId}");
        }
    }
}
