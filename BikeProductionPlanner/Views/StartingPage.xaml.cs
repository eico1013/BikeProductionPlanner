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
using BikeProductionPlanner.WPF.Views;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class StartingPage : UserControl
    {
        public StartingPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Unser Team

            MainWindowFinal.Instance.NavigateTo(Logic.UI.MenuItems.MenuItemsEnum.Impressum);
            ListView lvMenu = (ListView)MainWindowFinal.Instance.FindName("ListViewMenu");
            lvMenu.SelectedIndex = 9;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Start Planning

            MainWindowFinal.Instance.NavigateTo(Logic.UI.MenuItems.MenuItemsEnum.DataImport);
            ListView lvMenu = (ListView)MainWindowFinal.Instance.FindName("ListViewMenu");
            lvMenu.SelectedIndex = 1;
        }
    }
}
