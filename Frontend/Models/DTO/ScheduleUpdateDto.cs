using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class ScheduleUpdateDto
    {
        public int? SCHEDULE_ID { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public int? BRIGADE_ID { get; set; }
        public int? EMPLOYEE_ID { get; set; }


        public ScheduleUpdateDto()
        {
        }
    }
}
