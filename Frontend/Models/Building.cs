using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Building
    {
        public int? BUILDING_ID { get; set; }
        public string BUILDING_ADDRESS { get; set; }
        public int? NUMBER_OF_FLOORS { get; set; }
        public int BUILDING_TYPE_ID { get; set; }
        public string BUILDING_TYPE_NAME { get; set; }
        public List<FireSystemType> FIRE_SYSTEMS { get; set; }

        public Building()
        {
        }

        public Building(int? id, string address, int floors, int typeId, string typeName)
        {
            BUILDING_ID = id;
            BUILDING_ADDRESS = address;
            NUMBER_OF_FLOORS = floors;
            BUILDING_TYPE_ID = typeId;
            BUILDING_TYPE_NAME = typeName;
        }
    }
}
