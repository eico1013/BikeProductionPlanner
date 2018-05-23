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
            StorageService.Instance.ClearOrderItemList();
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
            List<OrderList> orderList = new List<OrderList>();
            orderList = StorageService.Instance.GetAllOrders();
            String inhaltOrderList = Convert.ToString(orderList.Count());
            MessageBox.Show(inhaltOrderList);

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

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            // Hole Kaufteilliste aus StorageService
            List<WarehouseStock> purchasePartsList = StorageService.Instance.GetPurchaseParts();

            // Hole Bestellliste aus StorageService
            List<OrderList> orderList = new List<OrderList>();
            orderList = StorageService.Instance.GetAllOrders();

            // Iteriere Kaufteilliste durch
            foreach (WarehouseStock purchasePart in purchasePartsList)
            {
                // Kaufteil ID als String
                String id = Convert.ToString(purchasePart.Id);
                String tbOrderAmountName = "purchasePartOrderAmountK" + id;
                String tbOrderTypeName = "purchasePartOrderTypeK" + id;

                // Finde entsprechende Textboxen anhand ihres eindeutigen Namens
                TextBox tbOrderAmount = (TextBox)this.FindName(tbOrderAmountName);
                TextBox tbOrderType = (TextBox)this.FindName(tbOrderTypeName);

                // Konvertiere Text aus Textboxen in Integer
                int convertedOrderAmount = Convert.ToInt32(tbOrderAmount.Text);

                if (convertedOrderAmount > 0 && (tbOrderType.Text == "Eil" || tbOrderType.Text == "Normal"))
                {
                    int convertedOrderType = 0;
                    if (tbOrderType.Text == "Eil")
                    {
                        convertedOrderType = 4;
                    }

                    else
                    {
                        convertedOrderType = 5;
                    }

                    // Prüfe, ob das Kaufteil bereits in der Bestellliste enthalten ist.
                    // Falls ja, dann suche nach dem Kaufteil und vergleiche die Werte für
                    // die Bestellmenge und die Bestellart. Unterscheidet sich mind. einer, 
                    // dann passe die Bestellliste mit den neuen Werten an.
                    if (orderList.Exists(x => x.Article == purchasePart.Id))
                    {
                        OrderList item = orderList.Find(x => x.Article == purchasePart.Id);
                        if (!(item.Quantity.Equals(convertedOrderAmount)) || !(item.Modus.Equals(convertedOrderType)))
                        {
                            int index = orderList.IndexOf(item);
                            orderList[index].Quantity = convertedOrderAmount;
                            orderList[index].Modus = convertedOrderType;
                        }
                    }

                    // Falls nein, dann füge das neue Kaufteil der Bestellliste hinzu
                    else
                    {
                        OrderList orderListItem = new OrderList(convertedOrderAmount, purchasePart.Id, convertedOrderType);
                        StorageService.Instance.AddOrderItem(orderListItem);
                    }

                }

                // Kaufteil von Bestellliste entfernen, wenn keine Bestellung gewünscht wird
                if (convertedOrderAmount == 0 || tbOrderType.Text == "Keine")
                {
                    if (orderList.Exists(x => x.Article == purchasePart.Id))
                    {
                        OrderList item = orderList.Find(x => x.Article == purchasePart.Id);
                        StorageService.Instance.RemoveOrderItem(item);
                    }
                }

            }

            String inhaltOrderList = Convert.ToString(orderList.Count());
            MessageBox.Show(inhaltOrderList);
        }

    }
}
