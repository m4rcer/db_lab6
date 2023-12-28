namespace Backend.Models
{
    public class EmployeeSpecialization
    {
        public int? EMPLOYEE_SPECIALIZATION_ID { get; set; }
        public string EMPLOYEE_SPECIALIZATION_NAME { get; set; }

        public EmployeeSpecialization()
        {

        }

        public EmployeeSpecialization(int? id, string name)
        {
            EMPLOYEE_SPECIALIZATION_ID = id;
            EMPLOYEE_SPECIALIZATION_NAME = name;
        }
    }
}
