using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class BuildingType
    {
        public int? BUILDING_TYPE_ID { get; set; }
        public string? BUILDING_TYPE_NAME { get; set; }

        public BuildingType()
        {

        }

        public BuildingType(int? id, string? name)
        {
            BUILDING_TYPE_ID = id;
            BUILDING_TYPE_NAME = name;
        }
    }
}
