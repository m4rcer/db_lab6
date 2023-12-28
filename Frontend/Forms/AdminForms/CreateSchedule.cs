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

namespace Frontend.Forms.AdminForms
{
    public partial class CreateSchedule : Form
    {
        Employee[] employees;
        Brigade[] brigades;
        public CreateSchedule()
        {
            InitializeComponent();

            initForm();
        }

        public async void initForm()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            var employee = await Fetch.Get<Employee[]>("/employee");

            foreach (var emp in employee)
            {
                comboBox1.Items.Add($"{emp.EMPLOYEE_ID};{emp.EMPLOYEE_SURNAME} {emp.EMPLOYEE_NAME} {emp.EMPLOYEE_FATHERS_NAME}");
            }

            employees = employee;


            var brigade = await Fetch.Get<Brigade[]>("/brigade");

            foreach (var br in brigade)
            {
                comboBox2.Items.Add(br.BRIGADE_NAME);
            }

            brigades = brigade;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dateTimePicker1.Value;
                var endDate = dateTimePicker2.Value;
                string brigadeName = comboBox2.SelectedItem == null ? null : comboBox2.SelectedItem.ToString();
                int? brigadeId = brigadeName == null ? null : (int?)brigades.FirstOrDefault(br => br.BRIGADE_NAME == brigadeName).BRIGADE_ID;



                var el = comboBox1.SelectedItem == null ? null : comboBox1.SelectedItem.ToString(); ;

                int? employeeId = el == null ? null : (int?)int.Parse(el.Split(';')[0]);

                var schedule = new ScheduleCreateDto() { 
                BRIGADE_ID = brigadeId,
                EMPLOYEE_ID = employeeId,
                END_DATE = endDate,
                START_DATE = startDate
                };



                await Fetch.Post("/schedule", schedule);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
