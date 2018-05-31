using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BikeProductionPlanner.Logic.Database;
using BikeProductionPlanner.Logic.UI;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaction logic for SafetyStock.xaml
    /// </summary>
    public partial class SafetyStock : UserControl
    {

        public SafetyStock()
        {
            InitializeComponent();
        }

        private void Slider_SafetyStockProduct2_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider) sender;
            slider.Value = (int) slider.Value;
        }

        private void Slider_SafetyStockProduct1_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider) sender;
            slider.Value = (int) slider.Value;
        }

        private void Slider_SafetyStockProduct3_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider) sender;
            slider.Value = (int) slider.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageService.Instance.sicherheitsbestandP1 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE26K = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE51 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE16K = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE17K = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE50 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE4 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE10 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE49 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE7 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE13 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandE18 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);

                StorageService.Instance.sicherheitsbestandP2 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE26D = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE56 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE16D = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE17D = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE55 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE5 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE11 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE54 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE8 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE14 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandE19 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);

                StorageService.Instance.sicherheitsbestandP3 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE26H = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE31 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE16H = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE17H = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE30 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE6 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE12 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE29 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE9 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE15 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
                StorageService.Instance.sicherheitsbestandE20 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);

            }
            catch (FormatException)
            {
                MessageBox.Show("Fehler: Nur ganzzahlige Werte erlaubt.");
            }

            MainWindowFinal.Instance.UpdateUI(State.Result);
            MainWindowFinal.Instance.NavigateTo(MenuItems.MenuItemsEnum.ProductionPlan);
            ListView lvMenu = (ListView)MainWindowFinal.Instance.FindName("ListViewMenu");
            lvMenu.SelectedIndex = 4;
        }
    }
}
