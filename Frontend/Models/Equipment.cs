using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Equipment
    {
        public int? EQUIPMENT_ID { get; set; }
        public string INVENTORY_NUMBER { get; set; }
        public int? EQUIPMENT_TYPE_ID { get; set; }
        public string EQUIPMENT_TYPE_NAME { get; set; }


        public Equipment()
        {
        }

        public Equipment(int? id, string inventoryNumber, int typeId, string typeName)
        {
            EQUIPMENT_ID = id;
            INVENTORY_NUMBER = inventoryNumber;
            EQUIPMENT_TYPE_ID = typeId;
            EQUIPMENT_TYPE_NAME = typeName;
        }
    }
}
