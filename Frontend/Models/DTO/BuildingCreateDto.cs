using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class BuildingCreateDto
    {
        public string BUILDING_ADDRESS { get; set; }
        public int? NUMBER_OF_FLOORS { get; set; }
        public int BUILDING_TYPE_ID { get; set; }
        public int[] FIRE_SYSTEM_TYPE_IDS { get; set; }


        public BuildingCreateDto()
        {
        }

        public BuildingCreateDto(string address, int floors, int typeId)
        {
            BUILDING_ADDRESS = address;
            NUMBER_OF_FLOORS = floors;
            BUILDING_TYPE_ID = typeId;
        }
    }
}
