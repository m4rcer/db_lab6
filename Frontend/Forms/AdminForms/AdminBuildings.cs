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
    public partial class AdminBuildings : Form
    {

        Building[] buildings;
        public AdminBuildings()
        {
            InitializeComponent();

            setupForm();
        }

        public async void setupForm()
        {
            var building = await Fetch.Get<Building[]>("/building");

            DataTable table = new DataTable();

            // добавляем колонки
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Адрес", typeof(string));
            table.Columns.Add("Количество этажей", typeof(int));
            table.Columns.Add("Тип", typeof(string));
            table.Columns.Add("Пожарные системы", typeof(string));

            foreach (var br in building)
            {
                var fireSystemsList = string.Join(",", br.FIRE_SYSTEMS.Select(eq => eq.FIRE_SYSTEM_TYPE_NAME));
                table.Rows.Add(br.BUILDING_ID,br.BUILDING_ADDRESS,br.NUMBER_OF_FLOORS,br.BUILDING_TYPE_NAME,fireSystemsList);
            }

            // привязываем таблицу к DataGridView
            dataGridView1.DataSource = table;

            buildings = building;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createBuilding = new CreateBuilding();

            createBuilding.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Обработка двойного клика
                // Пример: получение значения выбранной ячейки
                var selectedCell = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                var building = buildings.FirstOrDefault(el => el.BUILDING_ID == selectedCell);

                var updateBrigadeForm = new UpdateBuilding(building);

                updateBrigadeForm.ShowDialog();
            }
        }


        private async void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Получаем данные из строки, по которой произошел правый клик
                var rowData = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                // Далее работаем с полученными данными

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await Fetch.Delete($"/building/{rowData}");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Неверные данные");
                    }
                }
            }
        }
    }
}
