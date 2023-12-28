using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.Models
{
    public class EmployeeUpdateDto
    {
        public int EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_SURNAME { get; set; }
        public string EMPLOYEE_FATHERS_NAME { get; set; }
        public string EMPLOYEE_PHONE_NUMBER { get; set; }
        public string EMPLOYEE_EMAIL { get; set; }
        public string EMPLOYEE_PASSWORD { get; set; }
        public int? EMPLOYEE_SPECIALIZATION_ID { get; set; }
        public int? BRIGADE_ID { get; set; }

        public EmployeeUpdateDto()
        {
        }

        public EmployeeUpdateDto(int id, string name, string surname, string fathersName, string phoneNumber,
            string email, string password, int? specializationId, int? brigadeId)
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
        }
    }
}
