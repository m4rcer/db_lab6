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
    public partial class UpdateBuilding : Form
    {
        FireSystemType[] fireSystemTypes;
        BuildingType[] buildingTypes;
        Building building;
        public UpdateBuilding(Building building)
        {
            this.building = building;
            InitializeComponent();

            initForm();
            this.building = building;
        }

        public async void initForm()
        {
            var fireSystems = await Fetch.Get<FireSystemType[]>("/FireSystemType");

            foreach (var eq in fireSystems)
            {
                checkedListBox1.Items.Add(eq.FIRE_SYSTEM_TYPE_NAME);
            }

            this.fireSystemTypes = fireSystems;

            var buildingTypes = await Fetch.Get<BuildingType[]>("/BuildingType");

            foreach (var br in buildingTypes)
            {
                comboBox1.Items.Add(br.BUILDING_TYPE_NAME);
            }

            this.buildingTypes = buildingTypes;

            textBox1.Text = building.BUILDING_ADDRESS;
            comboBox1.SelectedItem = building.BUILDING_TYPE_NAME;
            numericUpDown1.Value = (decimal)building.NUMBER_OF_FLOORS;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var address = textBox1.Text;
                var numberOfFloors = (int)numericUpDown1.Value;
                var buildingTypeName = comboBox1.SelectedItem.ToString();
                int buildingTypeId = (int)buildingTypes.FirstOrDefault(el => el.BUILDING_TYPE_NAME == buildingTypeName).BUILDING_TYPE_ID;

                var fireSystemsIds = new List<int>();

                foreach (object item in checkedListBox1.CheckedItems)
                {
                    var el = item.ToString();

                    var id = this.fireSystemTypes.First(l => l.FIRE_SYSTEM_TYPE_NAME == el).FIRE_SYSTEM_TYPE_ID;

                    fireSystemsIds.Add((int)id);
                }


                var building = new BuildingUpdateDto() { 
                    BUILDING_ID = this.building.BUILDING_ID,
                    BUILDING_ADDRESS = address,
                    BUILDING_TYPE_ID = buildingTypeId,
                    FIRE_SYSTEM_TYPE_IDS = fireSystemsIds.ToArray(),
                    NUMBER_OF_FLOORS = numberOfFloors
                };


                await Fetch.Put("/building", building);

                this.Close();
            }
            catch (Exception err) {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
