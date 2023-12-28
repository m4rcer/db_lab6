using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class CallCreateDto
    {
        public string VICTIMS_FULL_NAME { get; set; }
        public string CALL_TEXT { get; set; }
        public int? EMPLOYEE_ID { get; set; }
        public int[] BRIGADE_IDS { get; set; }
        public int[] BUILDING_IDS { get; set; }



        public CallCreateDto()
        {
        }
    }
}
