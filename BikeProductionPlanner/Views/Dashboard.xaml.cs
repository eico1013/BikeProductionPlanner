using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BikeProductionPlanner.Logic;
using BikeProductionPlanner.Logic.Database;
using LiveCharts;
using LiveCharts.Defaults;
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
        public double Totalstackvalue1;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            //Value = StorageService.Instance.CheckTotalstockvalue1(Totalstackvalue1);
            //DataContext = this;

            //Value1 = StorageService.Instance.GetAmountFromWareHouseStockId(1);
            //Value2 = StorageService.Instance.GetAmountFromWareHouseStockId(2);
            //Value3 = StorageService.Instance.GetAmountFromWareHouseStockId(3);

            //SeriesCollection = new SeriesCollection
            //{
            //    new ColumnSeries
            //    {
            //        Values = new ChartValues<int> { Value1, Value2, Value3}
            //    }
            //};

            //Labels = new[] { "P1", "P2", "P3" };
            //Formatter = value => value.ToString("N");

            //DataContext = this;
        }

        //public void UpdateDashboardFields()
        //{
        //    Value1 = StorageService.Instance.GetAmountFromWareHouseStockId(1);
        //    Value2 = StorageService.Instance.GetAmountFromWareHouseStockId(2);
        //    Value3 = StorageService.Instance.GetAmountFromWareHouseStockId(3);
        //    Dash1.Value = StorageService.Instance.CheckTotalstockvalue1(Totalstackvalue1);
        //    Dash2.Series = new SeriesCollection { new ColumnSeries { Values = new ChartValues<int> { Value1, Value2, Value3 } } };
        //}
    }
}
