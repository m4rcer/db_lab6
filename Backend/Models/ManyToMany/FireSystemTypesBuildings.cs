using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class FireSystemTypesBuildings
    {
        public int? FIRE_SYSTEM_TYPES_BUILDINGS_ID { get; set; }
        public int? FIRE_SYSTEM_TYPE_ID { get; set; }
        public int? BUILDING_ID { get; set; }

        public FireSystemTypesBuildings()
        {

        }
    }
}
