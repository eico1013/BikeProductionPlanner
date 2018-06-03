using BikeProductionPlanner.Logic;
using BikeProductionPlanner.Logic.Database;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace BikeProductionPlanner.WPF.Views
{
    /// <summary>
    /// Interaction logic for XMLExportPage.xaml
    /// </summary>
    public partial class XMLExportPage : UserControl
    {
        public XMLExportPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlOutputParser.Instance.SellWish = StorageService.Instance.GetAllSellWishes();
            XmlOutputParser.Instance.SellDirect = StorageService.Instance.GetAllSellDirect();
            XmlOutputParser.Instance.OrderList = StorageService.Instance.GetAllOrders();
            XmlOutputParser.Instance.ProductionList = StorageService.Instance.GetAllProductionItems();
            XmlOutputParser.Instance.WorkingItemList = StorageService.Instance.GetAllWorkingItems();

            var dialog = new SaveFileDialog();//..
            dialog.FileName = "result.xml";
            dialog.AddExtension = true;
            dialog.DefaultExt = "xml";
            //dialog.Filter = "SCM Files (*.xml)|All files (*.*)|*.*";
            dialog.ShowDialog();

            var path = dialog.FileName;

            if (!XmlOutputParser.Instance.createOutputXml(path))
            {
                MessageBox.Show("Output File was not saved", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                //DataImportFailure.Visibility = Visibility.Visible;
            }
        }
    }
}
