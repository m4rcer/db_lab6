using Backend.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Call
    {
        public int CALL_ID { get; set; }
        public string VICTIMS_FULL_NAME { get; set; }
        public DateTime CALL_TIME { get; set; }
        public string CALL_TEXT { get; set; }
        public string REPORT { get; set; }
        public DateTime BRIGADE_DISPATCH_TIME { get; set; }
        public DateTime BRIGADE_ARRIVAL_TIME { get; set; }
        public DateTime BRIGADE_RETURN_TIME { get; set; }
        public int? EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_SURNAME { get; set; }
        public string EMPLOYEE_FATHERS_NAME { get; set; }
        public List<Brigade> BRIGADES { get; set; }
        public List<Building> BUILDINGS { get; set; }



        public Call()
        {
        }
    }
}
