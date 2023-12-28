using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class EquipmentCreateDto
    {
        public string INVENTORY_NUMBER { get; set; }
        public int? EQUIPMENT_TYPE_ID { get; set; }


        public EquipmentCreateDto()
        {
        }

        public EquipmentCreateDto(string inventoryNumber, int typeId)
        {
            INVENTORY_NUMBER = inventoryNumber;
            EQUIPMENT_TYPE_ID = typeId;
        }
    }
}
