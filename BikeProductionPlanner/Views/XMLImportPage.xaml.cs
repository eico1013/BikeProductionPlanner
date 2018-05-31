using BikeProductionPlanner;
using BikeProductionPlanner.Logic;
using BikeProductionPlanner.Views;
using Microsoft.Win32;
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

namespace BikeProductionPlanner.WPF.Views
{
    /// <summary>
    /// Interaktionslogik für XMLImportPage.xaml
    /// </summary>
    public partial class XMLImportPage : System.Windows.Controls.UserControl
    {
        public XMLImportPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();

            var path = dialog.FileName;
            if (!XmlInputParser.Instance.ParseXml(path))
            {
                //MessageBox.Show("Your selected File is invalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                DataImportFailure.Visibility = Visibility.Visible;
            }

            DataImportSuccess.Visibility = Visibility.Visible;
            ImportButtons.IsEnabled = false;
            NextButtons.Visibility = Visibility.Visible;
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new Sales();
        }

        private void Button_RemoveData(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new XMLImportPage();
        }

        private void OpenHelpButton(object sender, RoutedEventArgs e)
        {
            var helpWindow = new HelpWindow();

            helpWindow.ShowDialog();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            var webserviceImportWindow = new WebServiceImportWindow();

            webserviceImportWindow.ShowDialog();


            DataImportSuccess.Visibility = Visibility.Visible;
            ImportButtons.IsEnabled = false;
            NextButtons.Visibility = Visibility.Visible;

           // MainWindow.Instance.UpdateUI(State.Input);
        }
    }
}
