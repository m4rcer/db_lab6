using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class EquipmentUpdateDto
    {
        public int? EQUIPMENT_ID { get; set; }
        public string INVENTORY_NUMBER { get; set; }
        public int? EQUIPMENT_TYPE_ID { get; set; }

        public EquipmentUpdateDto()
        {
        }

        public EquipmentUpdateDto(int? id, string inventoryNumber, int typeId)
        {
            EQUIPMENT_ID = id;
            INVENTORY_NUMBER = inventoryNumber;
            EQUIPMENT_TYPE_ID = typeId;
        }
    }
}
