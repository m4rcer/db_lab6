using Backend.Models;
using Frontend.Forms;
using Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var email = emailTextBox.Text;
                var password = passwordTextBox.Text;

                Data.email = email;
                Data.password = password;

               /* Data.email = "Analyst";
                Data.password = "Analyst";*/
                email = Data.email;
                var employee = await Fetch.Get<Employee>($"/employee/email/{email}");

                Data.employee = employee;

                switch (employee.EMPLOYEE_SPECIALIZATION_NAME)
                {
                    case "Администратор":
                        var adminForm = new AdminMain();
                        adminForm.Show();
                        this.Hide();
                        break;
                    case "Аналитик":
                        var analystForm = new AnalystMain();
                        analystForm.Show();
                        this.Hide();
                        break;
                    case "Бригадир":
                        var foremanForm = new ForemanMain();
                        foremanForm.Show();
                        this.Hide();
                        break;
                    case "Диспетчер":
                        var dispatcherForm = new DispatcherMain();
                        dispatcherForm.Show();
                        this.Hide();
                        break;
                    case "Сотрудник":
                        var employeeForm = new EmployeeMain();
                        employeeForm.Show();
                        this.Hide();
                        break;

                    default:
                        break;
                }
            }
            catch(Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
