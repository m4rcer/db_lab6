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
    public partial class CreateBrigade : Form
    {
        Equipment[] equipment;
        public CreateBrigade()
        {
            InitializeComponent();

            initForm();
        }

        public async void initForm()
        {
            var equipment = await Fetch.Get<Equipment[]>("/equipment");

            foreach (var eq in equipment)
            {
                checkedListBox1.Items.Add($"{eq.INVENTORY_NUMBER};{eq.EQUIPMENT_TYPE_NAME}");
            }

            this.equipment = equipment;
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBox1.Text;
                var equipmentIds = new List<int>();

                foreach (object item in checkedListBox1.CheckedItems)
                {
                    var el = item.ToString();

                    var inventoryNumber = el.Split(';')[0];

                    var id = this.equipment.First(l => l.INVENTORY_NUMBER == inventoryNumber).EQUIPMENT_ID;

                    equipmentIds.Add((int)id);
                }


                var brigade = new BrigadeCreateDto() { BRIGADE_NAME = name, EQUIPMENT_IDS = equipmentIds.ToArray()};


                await Fetch.Post("/brigade", brigade);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
