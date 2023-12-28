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
    public partial class UpdateCall : Form
    {
        Call call;
        Brigade[] brigades;
        Building[] buildings;
        public UpdateCall(Call call)
        {
            this.call = call;
            InitializeComponent();

            initForm();
        }

        public async void initForm()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            if (call.BRIGADE_DISPATCH_TIME != null)
            {
                try
                {
                    dateTimePicker1.Value = call.BRIGADE_DISPATCH_TIME;
                }
                catch(Exception e)
                {
                }
            }

            if (call.BRIGADE_ARRIVAL_TIME != null)
            {
                try
                {
                    dateTimePicker2.Value = call.BRIGADE_ARRIVAL_TIME;

                }
                catch (Exception e)
                {
                }
            }

            if (call.BRIGADE_RETURN_TIME != null)
            {
                try
                {
                    dateTimePicker3.Value = call.BRIGADE_RETURN_TIME;

                }
                catch (Exception e)
                {
                }
            }

            richTextBox1.Text = call.CALL_TEXT;
            richTextBox2.Text = call.REPORT;
            textBox1.Text = call.VICTIMS_FULL_NAME;


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
                var employeeId = this.call.EMPLOYEE_ID;
                var victimName = textBox1.Text;
                var text = richTextBox1.Text;
                var report = richTextBox2.Text;
                var dispatchTime = dateTimePicker1.Value;
                var arrivalTime = dateTimePicker2.Value;
                var returnTime = dateTimePicker3.Value;

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


                var call = new CallUpdateDto() { 
                    CALL_ID = this.call.CALL_ID,
                    VICTIMS_FULL_NAME = victimName,
                    EMPLOYEE_ID = employeeId,
                    BRIGADE_IDS = brigadeIds.ToArray(),
                    CALL_TEXT = text,
                    BUILDING_IDS = buildingIds.ToArray(),
                    REPORT = report,
                    BRIGADE_RETURN_TIME = returnTime,
                    BRIGADE_ARRIVAL_TIME = arrivalTime,
                    BRIGADE_DISPATCH_TIME = dispatchTime
                };


                await Fetch.Put("/call", call);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }

        private void label3_Click(object sender, EventArgs e)
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
