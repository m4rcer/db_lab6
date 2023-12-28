using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend.Models;
using Frontend.Helpers;
using Backend.Models.Analyst;

namespace Frontend.Forms.Base
{
    public partial class Analyst : Form
    {
        public Analyst()
        {
            InitializeComponent();

            initForm();
        }

        public async void initForm()
        {
            var callsDate = await Fetch.Get<CallsCountByBuilding[]>("/Analyst/CountCallsPerDate");

            SeriesCollection series = new SeriesCollection(); //отображение данных на график. Линии и т.д.
            ChartValues<int> zp = new ChartValues<int>(); //Значения которые будут на линии, будет создания чуть позже.
            List<string> date = new List<string>(); //здесь будут храниться значения для оси X
            foreach (var item in callsDate) //Заполняем коллекции
            {
                zp.Add(item.CallsCount);
                date.Add($"{item.CALL_DATE.Day}.{item.CALL_DATE.Month}.{item.CALL_DATE.Year}");
            }
            cartesianChart1.AxisX.Clear(); //Очищаем ось X от значений по умолчанию
            cartesianChart1.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "Дата",
                Labels = date.Select(x => x).ToArray()
            });

            LineSeries line = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line.Title = "Число звонков";
            line.Values = zp;

            series.Add(line); //Добавляем линию на график
            cartesianChart1.Series = series; //Отрисовываем график в интерфейсе


            var type1 = await Fetch.Get<CallsCountByBuilding>("/Analyst/CountCallsByBuildingType/Жилое");

            textBox1.Text = type1.CallsCount.ToString();

            var type2 = await Fetch.Get<CallsCountByBuilding>("/Analyst/CountCallsByBuildingType/Административное");

            textBox2.Text = type2.CallsCount.ToString();

            var type3 = await Fetch.Get<CallsCountByBuilding>("/Analyst/CountCallsByBuildingType/Производственное");

            textBox3.Text = type3.CallsCount.ToString();

            var type4 = await Fetch.Get<CallsCountByBuilding>("/Analyst/CountCallsByBuildingType/Сельскохозяйственное");

            textBox4.Text = type4.CallsCount.ToString();

            var brigadesPerCall = await Fetch.Get<BrigadesPerCall>("/Analyst/CountBrigadesPerCall");

            textBox5.Text = brigadesPerCall.AverageBrigadesPerCall.ToString();

            var travelTime = await Fetch.Get<AverageTravelTime>("/Analyst/CalculateAverageTravelTime");

            textBox6.Text = travelTime.AverageTravelTimeInMinutes.ToString() + " минут";
        }
    }
}
