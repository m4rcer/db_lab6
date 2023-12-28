using Frontend.Forms.AdminForms;
using Frontend.Forms.Base;
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
    public partial class AnalystMain : Form
    {
        public AnalystMain()
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
            var employees = new Employees();

            employees.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var brigades = new Brigades();

            brigades.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var equipment = new EquipmentForm();

            equipment.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var building = new Buildings();

            building.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var schedule = new Schedule();

            schedule.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var calls = new ForemanCalls();

            calls.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var equipment = new AdminEquipment();

            equipment.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var analyst = new Analyst();

            analyst.ShowDialog();
        }
    }
}
