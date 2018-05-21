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
using System.Windows.Shapes;
using BikeProductionPlanner.Views;
using BikeProductionPlanner.WPF.Views;
using DynamicLocalization;

namespace BikeProductionPlanner
{
    /// <summary>
    /// Interaction logic for MainWindowFinal.xaml
    /// </summary>
    public partial class MainWindowFinal : Window
    {
        public static MainWindowFinal Instance;

        public MainWindowFinal()
        {
            InitializeComponent();



            LocUtil.SetDefaultLanguage(this);
            

            // Adjust checked language menu item
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                if (item.Tag.ToString().Equals(LocUtil.GetCurrentCultureName(this)))
                    item.IsChecked = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Adjust checked language menu item
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                if (item.Tag.ToString().Equals(LocUtil.GetCurrentCultureName(this)))
                    item.IsChecked = true;
            }

            MenuItem mi = sender as MenuItem;
            mi.IsChecked = true;
            LocUtil.SwitchLanguage(this, mi.Tag.ToString());

            
        }

        private void ListViewMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            //MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    ContentControl.Content = new XMLImportPage();
                    bike.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    ContentControl.Content = new Sales();
                    bike.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    ContentControl.Content = new SafetyStock();
                    bike.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    ContentControl.Content = new CapacityPlanningPage();
                    bike.Visibility = Visibility.Hidden;
                    break;
                case 7:
                    ContentControl.Content = new XMLExportPage();
                    bike.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClickBike(object sender, RoutedEventArgs e)
        {
            bike.Visibility = Visibility.Hidden;
        }
    }
}
