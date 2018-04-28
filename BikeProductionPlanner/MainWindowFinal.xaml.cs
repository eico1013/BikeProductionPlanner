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

namespace BikeProductionPlanner
{
    /// <summary>
    /// Interaction logic for MainWindowFinal.xaml
    /// </summary>
    public partial class MainWindowFinal : Window
    {
        public MainWindowFinal()
        {
            InitializeComponent();
        }

        private void ListViewMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            //MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    ContentControl.Content = new Blue();
                    break;
                case 1:
                    ContentControl.Content = new Red();
                    break;
                case 2:
                    ContentControl.Content = new SafetyStock();
                    break;
                default:
                    break;
            }
        }
    }
}
