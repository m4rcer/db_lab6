using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class EquipmentType
    {
        public int? EQUIPMENT_TYPE_ID { get; set; }
        public string? EQUIPMENT_TYPE_NAME { get; set; }

        public EquipmentType()
        {

        }

        public EquipmentType(int? id, string? name)
        {
            EQUIPMENT_TYPE_ID = id;
            EQUIPMENT_TYPE_NAME = name;
        }
    }
}
