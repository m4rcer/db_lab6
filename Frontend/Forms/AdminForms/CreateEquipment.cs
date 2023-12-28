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
    public partial class CreateEquipment : Form
    {
        EquipmentType[] types;
        public CreateEquipment()
        {
            InitializeComponent();

            initForm();
        }

        public async void initForm()
        {
            var equipmentTypes = await Fetch.Get<EquipmentType[]>("/equipmentType");

            foreach (var equipmentType in equipmentTypes)
            {
                comboBox1.Items.Add(equipmentType.EQUIPMENT_TYPE_NAME);
            }

            types = equipmentTypes;
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var inventoryNumber = textBox1.Text;
                var equipmentTypeName = comboBox1.SelectedItem.ToString();
                int? equipmentTypeId = types.FirstOrDefault(el => el.EQUIPMENT_TYPE_NAME == equipmentTypeName).EQUIPMENT_TYPE_ID;

                var equipment = new EquipmentCreateDto() { EQUIPMENT_TYPE_ID = equipmentTypeId, INVENTORY_NUMBER = inventoryNumber };


                await Fetch.Post("/equipment", equipment);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
