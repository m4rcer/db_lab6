
namespace Backend.Models
{
    public class BrigadeCreateDto
    {
        public string BRIGADE_NAME { get; set; }
        public int[] EQUIPMENT_IDS { get; set; }

        public BrigadeCreateDto()
        {

        }

        public BrigadeCreateDto(string name)
        {
            BRIGADE_NAME = name;
        }
    }
}
