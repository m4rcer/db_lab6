using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class BrigadeUpdateDto
    {
        public int BRIGADE_ID { get; set; }
        public string? BRIGADE_NAME { get; set; }
        public int[] EQUIPMENT_IDS { get; set; }

        public BrigadeUpdateDto()
        {

        }

        public BrigadeUpdateDto(string? name)
        {
            BRIGADE_NAME = name;
        }
    }
}
