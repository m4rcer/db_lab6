using Backend.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class CallUpdateDto
    {
        public int? CALL_ID { get; set; }
        public string VICTIMS_FULL_NAME { get; set; }
        public string CALL_TEXT { get; set; }
        public string REPORT { get; set; }
        public DateTime BRIGADE_DISPATCH_TIME { get; set; }
        public DateTime BRIGADE_ARRIVAL_TIME { get; set; }
        public DateTime BRIGADE_RETURN_TIME { get; set; }
        public int? EMPLOYEE_ID { get; set; }
        public int[] BRIGADE_IDS { get; set; }
        public int[] BUILDING_IDS { get; set; }




        public CallUpdateDto()
        {
        }
    }
}
