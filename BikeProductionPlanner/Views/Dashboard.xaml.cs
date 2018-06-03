using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using BikeProductionPlanner.Logic.Database;
using LiveCharts;
using LiveCharts.Wpf;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        private double Value;
        private int Value1;
        private int Value2;
        private int Value3;
        public double Totalstackvalue;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            //Value = StorageService.Instance.CheckTotalstockvalue(Totalstackvalue);
            //DataContext = this;

            //Value1 = StorageService.Instance.GetAmountFromWareHouseStockId(1);
            //Value2 = StorageService.Instance.GetAmountFromWareHouseStockId(2);
            //Value3 = StorageService.Instance.GetAmountFromWareHouseStockId(3);

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<int> { Value1, Value2, Value3},
                    Title = "Bestand",
                }
            };

            Formatter = value => value.ToString("N");
            

            DataContext = this;
        }

        public void UpdateDashboardFields()
        {
            List<int> stockinventar = new List<int>();
            List<int> stockvalues = new List<int>();

            List<string> labels = new List<string>();
            for (int i = 1; i <= 59; i++)
            {
                int amount = StorageService.Instance.GetAmountFromWareHouseStockId(i);
                int stockvalue = StorageService.Instance.GetStockValueFromWareHouseStockId(i);
                if (amount > 0)
                {
                    stockinventar.Add(amount);
                    stockvalues.Add(stockvalue);
                    labels.Add($"Produkt {i}");
                }
                
            }
            //Value1 = StorageService.Instance.GetAmountFromWareHouseStockId(1);
            //Value2 = StorageService.Instance.GetAmountFromWareHouseStockId(2);
            //Value3 = StorageService.Instance.GetAmountFromWareHouseStockId(3);
            Dash1.Value = StorageService.Instance.CheckTotalstockvalue(Totalstackvalue);
            Dash2.Series = new SeriesCollection
            {
                new ColumnSeries { Values = new ChartValues<int>(stockinventar),Title = "Bestand"}
            };
            Dash3.Series = new SeriesCollection
            {
                new ColumnSeries {Values = new ChartValues<int>(stockvalues),Title = "Wert"}
            };
            Labels = labels.ToArray();
        }
    }
}