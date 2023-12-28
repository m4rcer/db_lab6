using Backend.Services;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Employee
    {
        public int? EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_SURNAME { get; set; }
        public string EMPLOYEE_FATHERS_NAME { get; set; }
        public string EMPLOYEE_PHONE_NUMBER { get; set; }
        public string EMPLOYEE_EMAIL { get; set; }
        public string EMPLOYEE_PASSWORD { get; set; }
        public int? EMPLOYEE_SPECIALIZATION_ID { get; set; }
        public string EMPLOYEE_SPECIALIZATION_NAME { get; set; }
        public int? BRIGADE_ID { get; set; }
        public string BRIGADE_NAME { get; set; }


        public Employee()
        {
        }

        public Employee(int? id, string name, string surname, string fathersName, string phoneNumber,
            string email, string password, int? specializationId, int? brigadeId,
            string employeeSpecializationName, string brigadeName)
        {
            EMPLOYEE_ID = id;
            EMPLOYEE_NAME = name;
            EMPLOYEE_SURNAME = surname;
            EMPLOYEE_FATHERS_NAME = fathersName;
            EMPLOYEE_PHONE_NUMBER = phoneNumber;
            EMPLOYEE_EMAIL = email;
            EMPLOYEE_PASSWORD = password;
            EMPLOYEE_SPECIALIZATION_ID = specializationId;
            BRIGADE_ID = brigadeId;
            EMPLOYEE_SPECIALIZATION_NAME = employeeSpecializationName;
            BRIGADE_NAME = brigadeName;
        }
    }
}
