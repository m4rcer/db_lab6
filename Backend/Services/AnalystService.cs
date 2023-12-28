using Backend.DbServices;
using Backend.Models;
using Backend.Models.Analyst;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class AnalystService : DbServiceBase
    {
        public static async Task<CallsCountByBuilding> CountCallsByBuildingType(string buildingTypeName)
        {
            var result = await Read<CallsCountByBuilding>($"EXEC CountCallsByBuildingType '{buildingTypeName}'");

            return result.First();
        }

        public static async Task<List<CallDateCount>> CountCallsByDate()
        {
            var result = await Read<CallDateCount>($"EXEC CountCallsPerDay");

            return result;
        }

        public static async Task<BrigadesPerCall> CountBrigadesPerCall()
        {
            var result = await Read<BrigadesPerCall>($"EXEC CalculateAverageBrigadesPerCall");

            return result.First();
        }

        public static async Task<AverageTravelTime> CalculateAverageTravelTime()
        {
            var result = await Read<AverageTravelTime>($"EXEC CalculateAverageTravelTime");

            return result.First();
        }
    }
}
