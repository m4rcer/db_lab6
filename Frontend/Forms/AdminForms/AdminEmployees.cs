using Backend.Models;
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
using System.Linq;

namespace Frontend.Forms.AdminForms
{
    public partial class AdminEmployees : Form
    {
        Employee[] employees; 
        public AdminEmployees()
        {
            InitializeComponent();

            setupForm();
        }

        public async void setupForm()
        {
            var employees = await Fetch.Get<Employee[]>("/employee");

            DataTable table = new DataTable();

            // добавляем колонки
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Имя", typeof(string));
            table.Columns.Add("Фамилия", typeof(string));
            table.Columns.Add("Отчество", typeof(string));
            table.Columns.Add("Номер телефона", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Специализация", typeof(string));
            table.Columns.Add("Бригада", typeof(string));

            foreach (var emp in employees)
            {
                table.Rows.Add(emp.EMPLOYEE_ID,emp.EMPLOYEE_NAME, emp.EMPLOYEE_SURNAME, emp.EMPLOYEE_FATHERS_NAME,
                    emp.EMPLOYEE_PHONE_NUMBER, emp.EMPLOYEE_EMAIL, emp.EMPLOYEE_SPECIALIZATION_NAME,
                    emp.BRIGADE_NAME);
            }

            // привязываем таблицу к DataGridView
            dataGridView1.DataSource = table;

            this.employees = employees;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createEmployeeForm = new CreateEmployee();

            createEmployeeForm.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Обработка двойного клика
                // Пример: получение значения выбранной ячейки
                var selectedCell = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                var employee = employees.FirstOrDefault(el => el.EMPLOYEE_ID == selectedCell);

                var updateBrigadeForm = new UpdateEmployee(employee);

                updateBrigadeForm.ShowDialog();
            }
        }


        private async void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Получаем данные из строки, по которой произошел правый клик
                var rowData = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                // Далее работаем с полученными данными

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await Fetch.Delete($"/employee/{rowData}");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Неверные данные");
                    }
                }
            }
        }
    }
}
