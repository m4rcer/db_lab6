using Frontend.Forms.AdminForms;
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

namespace Frontend.Forms
{
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
            nameLabel.Text = $"{Data.employee.EMPLOYEE_SURNAME} {Data.employee.EMPLOYEE_NAME}";
            specializationLabel.Text = $"{Data.employee.EMPLOYEE_SPECIALIZATION_NAME}";
        }


        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
            base.OnClosed(e);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var employees = new AdminEmployees();

            employees.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var brigades = new AdminBrigades();

            brigades.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var equipment = new AdminEquipment();

            equipment.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var building = new AdminBuildings();

            building.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var schedule = new AdminSchedule();

            schedule.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var calls = new Calls();

            calls.ShowDialog();
        }
    }
}
