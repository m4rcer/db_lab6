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
    public partial class AdminSchedule : Form
    {
        Backend.Models.Schedule[] schedule;
        public AdminSchedule()
        {
            InitializeComponent();

            setupForm();
        }

        public async void setupForm()
        {
            var schedule = await Fetch.Get<Backend.Models.Schedule[]>("/Schedule");

            DataTable table = new DataTable();

            // добавляем колонки
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Дата начала", typeof(string));
            table.Columns.Add("Дата окончания", typeof(string));
            table.Columns.Add("Бригада", typeof(string));
            table.Columns.Add("Сотрудник", typeof(string));

            foreach (var eq in schedule)
            {
                table.Rows.Add(eq.SCHEDULE_ID, eq.START_DATE, eq.END_DATE, eq.BRIGADE_NAME,
                    $"{eq.EMPLOYEE_SURNAME} {eq.EMPLOYEE_NAME} {eq.EMPLOYEE_FATHERS_NAME}");
            }

            // привязываем таблицу к DataGridView
            dataGridView1.DataSource = table;

            this.schedule = schedule;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createSchedule = new CreateSchedule();

            createSchedule.ShowDialog();
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

                Backend.Models.Schedule schedule = this.schedule.FirstOrDefault((el) => el.SCHEDULE_ID == selectedCell);

                var updateScheduleForm = new UpdateSchedule(schedule);

                updateScheduleForm.ShowDialog();
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
                        await Fetch.Delete($"/schedule/{rowData}");
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
