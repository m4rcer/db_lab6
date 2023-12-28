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
    public partial class Calls : Form
    {

        Call[] calls;
        public Calls()
        {
            InitializeComponent();

            setupForm();
        }

        public async void setupForm()
        {
            var calls = await Fetch.Get<Call[]>("/call");

            DataTable table = new DataTable();

            // добавляем колонки
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("ФИО звонившего", typeof(string));
            table.Columns.Add("Время звонка", typeof(string));
            table.Columns.Add("Текст", typeof(string));
            table.Columns.Add("Отчет", typeof(string));
            table.Columns.Add("Время отправления бригады", typeof(string));
            table.Columns.Add("Время прибытия бригады", typeof(string));
            table.Columns.Add("Время возвращения бригады", typeof(string));
            table.Columns.Add("Диспетчер", typeof(string));
            table.Columns.Add("Бригады", typeof(string));
            table.Columns.Add("Здания", typeof(string));

            foreach (var br in calls)
            {
                var brigades = string.Join(",", br.BRIGADES.Select(eq => eq.BRIGADE_NAME));
                var buildings = string.Join(",", br.BUILDINGS.Select(eq => eq.BUILDING_ADDRESS));
                var dispatcher = $"{br.EMPLOYEE_SURNAME} {br.EMPLOYEE_NAME} {br.EMPLOYEE_FATHERS_NAME}";
                table.Rows.Add(br.CALL_ID, br.VICTIMS_FULL_NAME,br.CALL_TIME, br.CALL_TEXT,
                    br.REPORT, br.BRIGADE_DISPATCH_TIME, br.BRIGADE_ARRIVAL_TIME, br.BRIGADE_RETURN_TIME,
                    dispatcher,brigades, buildings);
            }

            // привязываем таблицу к DataGridView
            dataGridView1.DataSource = table;

            this.calls = calls;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createCall = new CreateCall();

            createCall.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Обработка двойного клика
                // Пример: получение значения выбранной ячейки
                var selectedCell = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                var call = calls.FirstOrDefault(el => el.CALL_ID == selectedCell);

                var updateCallForm = new UpdateCall(call);

                updateCallForm.ShowDialog();
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
                        await Fetch.Delete($"/call/{rowData}");
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
