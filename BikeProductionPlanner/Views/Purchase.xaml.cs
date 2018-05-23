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
            BikeProductionPlanner.Logic.Logic.Purchase.calculateCoverage();

            // Hole Kaufteilliste aus StorageService
            List<WarehouseStock> purchasePartsList = StorageService.Instance.GetPurchaseParts();
            
            // Iteriere Kaufteilliste durch
            foreach (WarehouseStock purchasePart in purchasePartsList)
            {
                // Kaufteil ID als String
                String id = Convert.ToString(purchasePart.Id);
                // Kaufteil Menge als String
                String amount = Convert.ToString(purchasePart.Amount);
                String tbCurrentStockName = "currentStockK" + id;

                // Finde entsprechende Textbox anhand ihres eindeutigen Namens
                TextBox tbCurrentStock = (TextBox)this.FindName(tbCurrentStockName);

                // Anfangsbestände befüllen
                tbCurrentStock.Text = amount;    
            }

            // Hole Bestellliste aus StorageService
            List<OrderList> orderList = StorageService.Instance.GetAllOrders();
            // String inhaltOrderList = Convert.ToString(orderList.Count());
            // MessageBox.Show(inhaltOrderList);

            // Iteriere Bestelliste durch
            foreach (OrderList orderListItem in orderList)
            {
                // Kaufteil ID als String
                String id = Convert.ToString(orderListItem.Article);
                // Kaufteil Menge als String
                String orderAmount = Convert.ToString(orderListItem.Quantity);
                String orderType = Convert.ToString(orderListItem.Type);
                String tbOrderAmountName = "purchasePartOrderAmountK" + id;
                String tbOrderTypeName = "purchasePartOrderTypeK" + id;

                // Finde entsprechende Textboxen anhand ihres eindeutigen Namens
                TextBox tbOrderAmount = (TextBox)this.FindName(tbOrderAmountName);
                TextBox tbOrderType = (TextBox)this.FindName(tbOrderTypeName);

                // Bestellmenge befüllen
                tbOrderAmount.Text = orderAmount;
                // Bestellart befüllen
                tbOrderType.Text = orderType;
            }
        }

        // Zeige/Schließe Detail-Ansicht
        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            if (btnShowDetails.Content.Equals("Details einblenden"))
            {
                btnShowDetails.Content = "Details ausblenden";
                gridDetail.Visibility = Visibility.Visible;

            }

            else
            {
                btnShowDetails.Content = "Details einblenden";
                gridDetail.Visibility = Visibility.Hidden;
            }
        }

        /*
       
        private void currentStockP0D1K21_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Amount:" + Convert.ToString(StorageService.Instance.GetFutureInwardStockMovment(21).Amount));
        }

        */
    }
}
