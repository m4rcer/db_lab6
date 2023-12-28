using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Brigade
    {
        public int BRIGADE_ID { get; set; }
        public string? BRIGADE_NAME { get; set; }
        public List<Equipment> EQUIPMENT { get; set; }

        public Brigade()
        {

        }

        public Brigade(int id, string? name)
        {
            BRIGADE_ID = id;
            BRIGADE_NAME = name;
        }
    }
}
