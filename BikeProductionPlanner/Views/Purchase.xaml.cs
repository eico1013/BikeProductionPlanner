using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaktionslogik für Purchasing.xaml
    /// </summary>
    public partial class Purchase : UserControl
    {
        public Purchase()
        {
            InitializeComponent();


            List<WarehouseStock> articleList = StorageService.Instance.GetWarehouseArticles();
            foreach (WarehouseStock article in articleList)
            {
                
            }
        }


       

        private void currentStockK21_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK21.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(21).Amount);
        }

        private void currentStockK22_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK22.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(22).Amount);
        }

        private void currentStockK23_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK23.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(23).Amount);
        }

        private void currentStockK24_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK24.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(24).Amount);
        }

        private void currentStockK25_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK25.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(25).Amount);
        }

        private void currentStockK27_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK27.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(27).Amount);
        }

        private void currentStockK28_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK28.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(28).Amount);
        }

        private void currentStockK32_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK32.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(32).Amount);
        }

        private void currentStockK33_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK33.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(33).Amount);
        }

        private void currentStockK34_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK34.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(34).Amount);
        }

        private void currentStockK35_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK35.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(35).Amount);
        }

        private void currentStockK36_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK36.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(36).Amount);
        }

        private void currentStockK37_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK37.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(37).Amount);
        }

        private void currentStockK38_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK38.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(38).Amount);
        }

        private void currentStockK39_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK39.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(39).Amount);
        }

        private void currentStockK40_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK40.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(40).Amount);
        }

        private void currentStockK41_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK41.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(41).Amount);
        }

        private void currentStockK42_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK42.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(42).Amount);
        }

        private void currentStockK43_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK43.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(43).Amount);
        }

        private void currentStockK44_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK44.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(44).Amount);
        }

        private void currentStockK45_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK45.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(45).Amount);
        }

        private void currentStockK46_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK46.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(46).Amount);
        }

        private void currentStockK47_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK47.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(47).Amount);
        }

        private void currentStockK48_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK48.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(48).Amount);
        }

        private void currentStockK52_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK52.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(52).Amount);
        }

        private void currentStockK53_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK53.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(53).Amount);
        }

        private void currentStockK57_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK57.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(57).Amount);
        }

        private void currentStockK58_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK58.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(58).Amount);
        }

        private void currentStockK59_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentStockK59.Text = Convert.ToString(StorageService.Instance.GetWarehouseArticleById(59).Amount);
        }

        private void currentStockP0D1K21_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Amount:" + Convert.ToString(StorageService.Instance.GetFutureInwardStockMovment(21).Amount));
        }
    }
}
