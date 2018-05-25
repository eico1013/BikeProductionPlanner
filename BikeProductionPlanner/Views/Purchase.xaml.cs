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
using static BikeProductionPlanner.Logic.Logic.Purchase;

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
        }

        public void UpdatePurchaseFields()
        {
            StorageService.Instance.ClearOrderItemList();
            BikeProductionPlanner.Logic.Logic.Purchase.calculateCoverage();

            // Hole Bestellliste aus StorageService
            List<OrderList> orderList = new List<OrderList>();
            orderList = StorageService.Instance.GetAllOrders();
            // String inhaltOrderList = Convert.ToString(orderList.Count());
            // MessageBox.Show(inhaltOrderList);

            // Iteriere Bestellliste durch
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

            // Funktionalität

            // Periodenüberschriften mit tatsächlichen Perioden befüllen
            // Finde entsprechender TextBlock anhand seines eindeutigen Namens
            TextBlock tblcaptionPeriod0 = (TextBlock)this.FindName("captionPeriod0");
            TextBlock tblcaptionPeriod1 = (TextBlock)this.FindName("captionPeriod1");
            TextBlock tblcaptionPeriod2 = (TextBlock)this.FindName("captionPeriod2");
            TextBlock tblcaptionPeriod3 = (TextBlock)this.FindName("captionPeriod3");

            int currentPeriod = 0;
            currentPeriod = StorageService.Instance.GetPeriodFromXml() + 1;
            int period1 = currentPeriod + 1;
            int period2 = period1 + 1;
            int period3 = period2 + 1;

            String currentPeriodAsString = Convert.ToString(currentPeriod);
            String period1AsString = Convert.ToString(period1);
            String period2AsString = Convert.ToString(period2);
            String period3AsString = Convert.ToString(period3);

            String captionPeriod0 = "Endbestände Periode " + currentPeriodAsString;
            String captionPeriod1 = "Endbestände Periode " + period1AsString;
            String captionPeriod2 = "Endbestände Periode " + period2AsString;
            String captionPeriod3 = "Endbestände Periode " + period3AsString;

            tblcaptionPeriod0.Text = captionPeriod0;
            tblcaptionPeriod1.Text = captionPeriod1;
            tblcaptionPeriod2.Text = captionPeriod2;
            tblcaptionPeriod3.Text = captionPeriod3;

            // Hole Kaufteilliste aus StorageService
            List <WarehouseStock> purchasePartsList = new List<WarehouseStock>();
            purchasePartsList = StorageService.Instance.GetPurchaseParts();
            // Hole Bedarfsliste aus Purchase Klasse
            List<Demand> demandOfPartsList = new List<Demand>();
            demandOfPartsList = GetDemandOfParts();

            // Iteriere Kaufteilliste durch
            foreach (WarehouseStock purchasePart in purchasePartsList)
            {
                // Bedarfsberechnungen
                Demand demandOfPart = demandOfPartsList.Find(x => x.idDemand == purchasePart.Id);
                int demandP0PerDay = demandOfPart.demandInP0 / 5;
                int demandP1PerDay = demandOfPart.demandInP1 / 5;
                int demandP2PerDay = demandOfPart.demandInP2 / 5;
                int demandP3PerDay = demandOfPart.demandInP3 / 5;

                // Mengenberechnungen
                int amountP0D1 = purchasePart.Amount - demandP0PerDay;
                int amountP0D2 = amountP0D1 - demandP0PerDay;
                int amountP0D3 = amountP0D2 - demandP0PerDay;
                int amountP0D4 = amountP0D3 - demandP0PerDay;
                int amountP0D5 = amountP0D4 - demandP0PerDay;

                int amountP1D1 = amountP0D5 - demandP1PerDay;
                int amountP1D2 = amountP1D1 - demandP1PerDay;
                int amountP1D3 = amountP1D2 - demandP1PerDay;
                int amountP1D4 = amountP1D3 - demandP1PerDay;
                int amountP1D5 = amountP1D4 - demandP1PerDay;

                int amountP2D1 = amountP1D5 - demandP2PerDay;
                int amountP2D2 = amountP2D1 - demandP2PerDay;
                int amountP2D3 = amountP2D2 - demandP2PerDay;
                int amountP2D4 = amountP2D3 - demandP2PerDay;
                int amountP2D5 = amountP2D4 - demandP2PerDay;

                int amountP3D1 = amountP2D5 - demandP3PerDay;
                int amountP3D2 = amountP3D1 - demandP3PerDay;
                int amountP3D3 = amountP3D2 - demandP3PerDay;
                int amountP3D4 = amountP3D3 - demandP3PerDay;
                int amountP3D5 = amountP3D4 - demandP3PerDay;

                // Kaufteil Menge als String
                String amount = Convert.ToString(purchasePart.Amount);
                String amountP0D1AsString = Convert.ToString(amountP0D1);
                String amountP0D2AsString = Convert.ToString(amountP0D2);
                String amountP0D3AsString = Convert.ToString(amountP0D3);
                String amountP0D4AsString = Convert.ToString(amountP0D4);
                String amountP0D5AsString = Convert.ToString(amountP0D5);

                String amountP1D1AsString = Convert.ToString(amountP1D1);
                String amountP1D2AsString = Convert.ToString(amountP1D2);
                String amountP1D3AsString = Convert.ToString(amountP1D3);
                String amountP1D4AsString = Convert.ToString(amountP1D4);
                String amountP1D5AsString = Convert.ToString(amountP1D5);

                String amountP2D1AsString = Convert.ToString(amountP2D1);
                String amountP2D2AsString = Convert.ToString(amountP2D2);
                String amountP2D3AsString = Convert.ToString(amountP2D3);
                String amountP2D4AsString = Convert.ToString(amountP2D4);
                String amountP2D5AsString = Convert.ToString(amountP2D5);

                String amountP3D1AsString = Convert.ToString(amountP3D1);
                String amountP3D2AsString = Convert.ToString(amountP3D2);
                String amountP3D3AsString = Convert.ToString(amountP3D3);
                String amountP3D4AsString = Convert.ToString(amountP3D4);
                String amountP3D5AsString = Convert.ToString(amountP3D5);

                // Kaufteil ID als String
                String id = Convert.ToString(purchasePart.Id);
                // Textbox Name
                String tbCurrentStockName = "currentStockK" + id;
                String tbCurrentStockP0D1Name = "currentStockP0D1K" + id;
                String tbCurrentStockP0D2Name = "currentStockP0D2K" + id;
                String tbCurrentStockP0D3Name = "currentStockP0D3K" + id;
                String tbCurrentStockP0D4Name = "currentStockP0D4K" + id;
                String tbCurrentStockP0D5Name = "currentStockP0D5K" + id;

                String tbCurrentStockP1D1Name = "currentStockP1D1K" + id;
                String tbCurrentStockP1D2Name = "currentStockP1D2K" + id;
                String tbCurrentStockP1D3Name = "currentStockP1D3K" + id;
                String tbCurrentStockP1D4Name = "currentStockP1D4K" + id;
                String tbCurrentStockP1D5Name = "currentStockP1D5K" + id;

                String tbCurrentStockP2D1Name = "currentStockP2D1K" + id;
                String tbCurrentStockP2D2Name = "currentStockP2D2K" + id;
                String tbCurrentStockP2D3Name = "currentStockP2D3K" + id;
                String tbCurrentStockP2D4Name = "currentStockP2D4K" + id;
                String tbCurrentStockP2D5Name = "currentStockP2D5K" + id;

                String tbCurrentStockP3D1Name = "currentStockP3D1K" + id;
                String tbCurrentStockP3D2Name = "currentStockP3D2K" + id;
                String tbCurrentStockP3D3Name = "currentStockP3D3K" + id;
                String tbCurrentStockP3D4Name = "currentStockP3D4K" + id;
                String tbCurrentStockP3D5Name = "currentStockP3D5K" + id;

                // Finde entsprechende Textbox anhand ihres eindeutigen Namens
                TextBox tbCurrentStock = (TextBox)this.FindName(tbCurrentStockName);
                TextBox tbCurrentStockP0D1 = (TextBox)this.FindName(tbCurrentStockP0D1Name);
                TextBox tbCurrentStockP0D2 = (TextBox)this.FindName(tbCurrentStockP0D2Name);
                TextBox tbCurrentStockP0D3 = (TextBox)this.FindName(tbCurrentStockP0D3Name);
                TextBox tbCurrentStockP0D4 = (TextBox)this.FindName(tbCurrentStockP0D4Name);
                TextBox tbCurrentStockP0D5 = (TextBox)this.FindName(tbCurrentStockP0D5Name);

                TextBox tbCurrentStockP1D1 = (TextBox)this.FindName(tbCurrentStockP1D1Name);
                TextBox tbCurrentStockP1D2 = (TextBox)this.FindName(tbCurrentStockP1D2Name);
                TextBox tbCurrentStockP1D3 = (TextBox)this.FindName(tbCurrentStockP1D3Name);
                TextBox tbCurrentStockP1D4 = (TextBox)this.FindName(tbCurrentStockP1D4Name);
                TextBox tbCurrentStockP1D5 = (TextBox)this.FindName(tbCurrentStockP1D5Name);

                TextBox tbCurrentStockP2D1 = (TextBox)this.FindName(tbCurrentStockP2D1Name);
                TextBox tbCurrentStockP2D2 = (TextBox)this.FindName(tbCurrentStockP2D2Name);
                TextBox tbCurrentStockP2D3 = (TextBox)this.FindName(tbCurrentStockP2D3Name);
                TextBox tbCurrentStockP2D4 = (TextBox)this.FindName(tbCurrentStockP2D4Name);
                TextBox tbCurrentStockP2D5 = (TextBox)this.FindName(tbCurrentStockP2D5Name);

                TextBox tbCurrentStockP3D1 = (TextBox)this.FindName(tbCurrentStockP3D1Name);
                TextBox tbCurrentStockP3D2 = (TextBox)this.FindName(tbCurrentStockP3D2Name);
                TextBox tbCurrentStockP3D3 = (TextBox)this.FindName(tbCurrentStockP3D3Name);
                TextBox tbCurrentStockP3D4 = (TextBox)this.FindName(tbCurrentStockP3D4Name);
                TextBox tbCurrentStockP3D5 = (TextBox)this.FindName(tbCurrentStockP3D5Name);

                // Bestände befüllen
                tbCurrentStock.Text = amount;
                tbCurrentStockP0D1.Text = amountP0D1AsString;
                tbCurrentStockP0D2.Text = amountP0D2AsString;
                tbCurrentStockP0D3.Text = amountP0D3AsString;
                tbCurrentStockP0D4.Text = amountP0D4AsString;
                tbCurrentStockP0D5.Text = amountP0D5AsString;

                tbCurrentStockP1D1.Text = amountP1D1AsString;
                tbCurrentStockP1D2.Text = amountP1D2AsString;
                tbCurrentStockP1D3.Text = amountP1D3AsString;
                tbCurrentStockP1D4.Text = amountP1D4AsString;
                tbCurrentStockP1D5.Text = amountP1D5AsString;

                tbCurrentStockP2D1.Text = amountP2D1AsString;
                tbCurrentStockP2D2.Text = amountP2D2AsString;
                tbCurrentStockP2D3.Text = amountP2D3AsString;
                tbCurrentStockP2D4.Text = amountP2D4AsString;
                tbCurrentStockP2D5.Text = amountP2D5AsString;

                tbCurrentStockP3D1.Text = amountP3D1AsString;
                tbCurrentStockP3D2.Text = amountP3D2AsString;
                tbCurrentStockP3D3.Text = amountP3D3AsString;
                tbCurrentStockP3D4.Text = amountP3D4AsString;
                tbCurrentStockP3D5.Text = amountP3D5AsString;
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

            // String inhaltOrderList = Convert.ToString(orderList.Count());
            // MessageBox.Show(inhaltOrderList);
        }

    }
}
