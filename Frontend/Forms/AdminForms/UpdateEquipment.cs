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
    public partial class UpdateEquipment : Form
    {
        EquipmentType[] types;
        Equipment equipment;
        public UpdateEquipment(Equipment equipment)
        {
            InitializeComponent();

            initForm(equipment);

            this.equipment = equipment;
        }

        public async void initForm(Equipment equipment)
        {
            var equipmentTypes = await Fetch.Get<EquipmentType[]>("/equipmentType");

            foreach (var equipmentType in equipmentTypes)
            {
                comboBox1.Items.Add(equipmentType.EQUIPMENT_TYPE_NAME);
            }

            types = equipmentTypes;

            textBox1.Text = equipment.INVENTORY_NUMBER;
            comboBox1.SelectedItem = equipment.EQUIPMENT_TYPE_NAME;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var inventoryNumber = textBox1.Text;
                var equipmentTypeName = comboBox1.SelectedItem.ToString();
                int? equipmentTypeId = types.FirstOrDefault(el => el.EQUIPMENT_TYPE_NAME == equipmentTypeName).EQUIPMENT_TYPE_ID;

                var equipment = new EquipmentUpdateDto() { EQUIPMENT_TYPE_ID = equipmentTypeId, INVENTORY_NUMBER = inventoryNumber,
                EQUIPMENT_ID = this.equipment.EQUIPMENT_ID};


                await Fetch.Put($"/equipment", equipment);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
