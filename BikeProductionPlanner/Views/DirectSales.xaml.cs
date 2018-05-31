using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

using BikeProductionPlanner.Logic;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class DirectSales : UserControl
    {
        public DirectSales()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Speichern & Zurück
            
            try
            {
                StorageService.Instance.AddSellWish(new SellWish(StorageService.Instance.GetForecastForPeriod(0).Product1, 1));
                StorageService.Instance.AddSellWish(new SellWish(StorageService.Instance.GetForecastForPeriod(0).Product2, 2));
                StorageService.Instance.AddSellWish(new SellWish(StorageService.Instance.GetForecastForPeriod(0).Product3, 3));

                StorageService.Instance.AddSellDirect(new SellDirect(Convert.ToInt32(directProduct1.Text), 1, Convert.ToInt32(contractPenaltyProduct1.Text), Convert.ToInt32(retailPriceProduct1.Text)));
                StorageService.Instance.AddSellDirect(new SellDirect(Convert.ToInt32(directProduct2.Text), 2, Convert.ToInt32(contractPenaltyProduct2.Text), Convert.ToInt32(retailPriceProduct2.Text)));
                StorageService.Instance.AddSellDirect(new SellDirect(Convert.ToInt32(directProduct3.Text), 3, Convert.ToInt32(contractPenaltyProduct3.Text), Convert.ToInt32(retailPriceProduct3.Text)));

                MainWindowFinal.Instance.NavigateTo(Logic.UI.MenuItems.MenuItemsEnum.SafetyStock);
                ListView lvMenu = (ListView)MainWindowFinal.Instance.FindName("ListViewMenu");
                lvMenu.SelectedIndex = 3;
            }
            catch
            {

            }
            
        }

        private void Forecast1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Int32 directsum1 = 0;

                if (directProduct1 != null)
                    directsum1 += Convert.ToInt32(directProduct1.Text);
                if (directProduct2 != null)
                    directsum1 += Convert.ToInt32(directProduct2.Text);
                if (directProduct3 != null)
                    directsum1 += Convert.ToInt32(directProduct3.Text);

                if (directSum != null)
                    directSum.Text = directsum1.ToString();
            }
            catch
            {

            }
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
