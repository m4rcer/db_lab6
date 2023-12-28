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
    public partial class AdminEquipment : Form
    {
        Equipment[] equipments;
        public AdminEquipment()
        {
            InitializeComponent();

            setupForm();
        }

        public async void setupForm()
        {
            var equipment = await Fetch.Get<Equipment[]>("/equipment");

            DataTable table = new DataTable();

            // добавляем колонки
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Инвентарный номер", typeof(string));
            table.Columns.Add("Тип", typeof(string));

            foreach (var eq in equipment)
            {
                table.Rows.Add(eq.EQUIPMENT_ID, eq.INVENTORY_NUMBER, eq.EQUIPMENT_TYPE_NAME);
            }

            // привязываем таблицу к DataGridView
            dataGridView1.DataSource = table;

            equipments = equipment;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createEquipment = new CreateEquipment();

            createEquipment.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Обработка двойного клика
                // Пример: получение значения выбранной ячейки
                var selectedCell = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                Equipment equipment = equipments.FirstOrDefault(el => el.EQUIPMENT_ID == selectedCell);

                var updateEquipmentForm = new UpdateEquipment(equipment);

                updateEquipmentForm.ShowDialog();
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
                        await Fetch.Delete($"/equipment/{rowData}");
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
