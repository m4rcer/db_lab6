using Backend.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Schedule
    {
        public int? SCHEDULE_ID { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public int? BRIGADE_ID { get; set; }
        public int? EMPLOYEE_ID { get; set; }
        public string BRIGADE_NAME { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_SURNAME { get; set; }
        public string EMPLOYEE_FATHERS_NAME { get; set; }


        public Schedule()
        {
        }
    }
}
