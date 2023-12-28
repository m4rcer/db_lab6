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
    public partial class Brigades : Form
    {

        Brigade[] brigades;
        public Brigades()
        {
            InitializeComponent();

            setupForm();
        }

        public async void setupForm()
        {
            var brigade = await Fetch.Get<Brigade[]>("/brigade");

            DataTable table = new DataTable();

            // добавляем колонки
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Название", typeof(string));
            table.Columns.Add("Оборудование", typeof(string));

            foreach (var br in brigade)
            {
                var equipmentList = string.Join(",", br.EQUIPMENT.Select(eq => eq.EQUIPMENT_TYPE_NAME));
                table.Rows.Add(br.BRIGADE_ID,br.BRIGADE_NAME,equipmentList);
            }

            // привязываем таблицу к DataGridView
            dataGridView1.DataSource = table;

            brigades = brigade;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createBrigade = new CreateBrigade();

            createBrigade.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Обработка двойного клика
                // Пример: получение значения выбранной ячейки
                var selectedCell = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                var brigade = brigades.FirstOrDefault(el => el.BRIGADE_ID == selectedCell);

                var updateBrigadeForm = new UpdateBrigade(brigade);

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
                        await Fetch.Delete($"/brigade/{rowData}");
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
