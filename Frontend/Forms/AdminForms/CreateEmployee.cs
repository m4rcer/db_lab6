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
    public partial class CreateEmployee : Form
    {
        Brigade[] brigades;
        EmployeeSpecialization[] specializations;
        public CreateEmployee()
        {
            InitializeComponent();

            initForm();
        }

        public async void initForm()
        {
            var brigades = await Fetch.Get<Brigade[]>("/brigade");

            foreach (var br in brigades)
            {
                comboBox1.Items.Add(br.BRIGADE_NAME);
            }

            this.brigades = brigades;

            var specializations = await Fetch.Get<EmployeeSpecialization[]>("/EmployeeSpecialization");

            foreach (var sp in specializations)
            {
                comboBox2.Items.Add(sp.EMPLOYEE_SPECIALIZATION_NAME);
            }

            this.specializations = specializations;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBox1.Text;
                var surname = textBox2.Text;
                var fathersname = textBox3.Text;
                var phone = textBox4.Text;
                var email = textBox5.Text;
                var password = textBox6.Text;
                string brigadeName = comboBox1.SelectedItem == null ? null : comboBox1.SelectedItem.ToString();
                int? brigadeId = brigadeName == null ? null : (int?)brigades.FirstOrDefault(el => el.BRIGADE_NAME == brigadeName).BRIGADE_ID;
                var specializationName = comboBox2.SelectedItem.ToString();
                int? specializationId = specializations.FirstOrDefault(el => el.EMPLOYEE_SPECIALIZATION_NAME == specializationName).EMPLOYEE_SPECIALIZATION_ID;

                var employee = new EmployeeCreateDto() {
                    BRIGADE_ID = brigadeId,
                    EMPLOYEE_EMAIL = email,
                    EMPLOYEE_PASSWORD = password,
                    EMPLOYEE_NAME = name,
                    EMPLOYEE_FATHERS_NAME = fathersname,
                    EMPLOYEE_PHONE_NUMBER = phone,
                    EMPLOYEE_SPECIALIZATION_ID = specializationId,
                    EMPLOYEE_SURNAME = surname
                };


                await Fetch.Post("/employee", employee);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
