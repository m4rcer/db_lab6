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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Frontend.Forms.AdminForms
{
    public partial class CreateCall : Form
    {
        Brigade[] brigades;
        Building[] buildings;
        public CreateCall()
        {
            InitializeComponent();

            initForm();
        }

        public async void initForm()
        {
            var brigade = await Fetch.Get<Brigade[]>("/brigade");

            foreach (var br in brigade)
            {
                checkedListBox1.Items.Add(br.BRIGADE_NAME);
            }

            this.brigades = brigade;

            var building = await Fetch.Get<Building[]>("/building");

            foreach (var br in building)
            {
                checkedListBox2.Items.Add(br.BUILDING_ADDRESS);
            }

            this.buildings = building;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeId = Data.employee.EMPLOYEE_ID;
                var victimName = textBox1.Text;
                var text = richTextBox1.Text;

                var brigadeIds = new List<int>();

                foreach (object item in checkedListBox1.CheckedItems)
                {
                    var el = item.ToString();

                    var id = this.brigades.First(l => l.BRIGADE_NAME == el).BRIGADE_ID;

                    brigadeIds.Add((int)id);
                }

                var buildingIds = new List<int>();

                foreach (object item in checkedListBox2.CheckedItems)
                {
                    var el = item.ToString();

                    var id = this.buildings.First(l => l.BUILDING_ADDRESS == el).BUILDING_ID;

                    buildingIds.Add((int)id);
                }


                var call = new CallCreateDto() { 
                VICTIMS_FULL_NAME = victimName,
                EMPLOYEE_ID = employeeId,
                BRIGADE_IDS = brigadeIds.ToArray(),
                CALL_TEXT = text,
                BUILDING_IDS = buildingIds.ToArray(),
                };


                await Fetch.Post("/call", call);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
