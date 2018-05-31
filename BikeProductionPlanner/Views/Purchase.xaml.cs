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

                int deliveryTimeInclDepartureTime = 0;
                int deliveryTimePriority = 0;

                // Hole eingehende Bestellungen aus StorageService
                List<FutureInwardStockMovment> futureInwardStockMovments = StorageService.Instance.GetFutureInwardStockMovment();
                // Hole Kaufteilliste aus StorageService
                List<WarehouseStock> purchasePartsList = new List<WarehouseStock>();
                purchasePartsList = StorageService.Instance.GetPurchaseParts();
                // Hole Bedarfsliste aus Purchase Klasse
                List<Demand> demandOfPartsList = new List<Demand>();
                demandOfPartsList = GetDemandOfParts();

                // Iteriere Kaufteilliste durch
                foreach (WarehouseStock purchasePart in purchasePartsList)
                {
                    deliveryTimeInclDepartureTime = 0;
                    deliveryTimePriority = 0;
                    // Kaufteil ID als String
                    String id = Convert.ToString(purchasePart.Id);
                    List<FutureInwardStockMovment> incomingOrders;
                    // Extrahiere alle Bestellungen des Artikels
                    incomingOrders = futureInwardStockMovments.FindAll(item => item.Article.Equals(purchasePart.Id));

                    // Setze Lieferzeit mit Abweichung und Eillieferzeit für den Artikel
                    deliveryTimeInclDepartureTime = GetPurchasePartFromPurchaseByID(purchasePart.Id).deliveryTime + GetPurchasePartFromPurchaseByID(purchasePart.Id).departureTime;
                    deliveryTimePriority = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(GetPurchasePartFromPurchaseByID(purchasePart.Id).deliveryTime) / 2.0));

                    // Bedarfsberechnungen
                    Demand demandOfPart = demandOfPartsList.Find(x => x.idDemand == purchasePart.Id);
                    int demandP0PerDay = 0;
                    demandP0PerDay = demandOfPart.demandInP0 / 5;
                    int demandP1PerDay = 0;
                    demandP1PerDay = demandOfPart.demandInP1 / 5;
                    int demandP2PerDay = 0;
                    demandP2PerDay = demandOfPart.demandInP2 / 5;
                    int demandP3PerDay = 0;
                    demandP3PerDay = demandOfPart.demandInP3 / 5;

                    // Befülle Startmengen mit Lieferzugängen aus der Liste
                    foreach (FutureInwardStockMovment incomingPart in incomingOrders)
                    {
                        int incomingOrderDate = 0;
                        int incomingOrderDay = 0;
                        double incomingOrderAmount = 0.0;

                        // Berechne wann der Artikel eintrifft
                        if (incomingPart.Mode.Equals(5))
                        {
                            incomingOrderDate = incomingPart.OrderPeriod * 5 + deliveryTimeInclDepartureTime;
                        }

                        else
                        {
                            incomingOrderDate = incomingPart.OrderPeriod * 5 + deliveryTimePriority;
                        }

                        incomingOrderDay = incomingOrderDate - currentPeriod * 5;
                        incomingOrderAmount = Convert.ToDouble(incomingPart.Amount);
                        TextBox tbCurrentStockPD;
                        String tbCurrentStockPDName = "";

                        if (incomingOrderDay >= 0 && incomingOrderDay < 5)
                        {
                            incomingOrderDay = incomingOrderDay + 1;
                            tbCurrentStockPDName = "currentStockP0D" + incomingOrderDay + "K" + id;
                        }

                        if (incomingOrderDay >= 5 && incomingOrderDay < 10)
                        {
                            incomingOrderDay = incomingOrderDay + 1 - 5;
                            tbCurrentStockPDName = "currentStockP1D" + incomingOrderDay + "K" + id;
                        }

                        if (incomingOrderDay >= 10 && incomingOrderDay < 15)
                        {
                            incomingOrderDay = incomingOrderDay + 1 - 10;
                            tbCurrentStockPDName = "currentStockP2D" + incomingOrderDay + "K" + id;
                        }

                        if (incomingOrderDay >= 15 && incomingOrderDay < 20)
                        {
                            incomingOrderDay = incomingOrderDay + 1 - 15;
                            tbCurrentStockPDName = "currentStockP3D" + incomingOrderDay + "K" + id;
                        }

                        tbCurrentStockPD = (TextBox)this.FindName(tbCurrentStockPDName);
                        tbCurrentStockPD.Text = Convert.ToString(incomingOrderAmount);
                        tbCurrentStockPD.FontWeight = FontWeights.Bold;
                    }

                    String amountInLoopAsString = "";
                    String tbCurrentStockInLoopName = "";
                    int amountInLoop = 0;
                    int demandInLoop = 0;
                    TextBox tbCurrentStockInLoop;
                    // Initiale Mengenberechnung
                    amountInLoop = purchasePart.Amount;

                    for (int i = 0; i < 4; ++i)
                    {
                        if (i == 0)
                        {
                            demandInLoop = demandP0PerDay;
                        }

                        if (i == 1)
                        {
                            demandInLoop = demandP1PerDay;
                        }

                        if (i == 2)
                        {
                            demandInLoop = demandP2PerDay;
                        }

                        if (i == 3)
                        {
                            demandInLoop = demandP3PerDay;
                        }

                        for (int j = 1; j < 6; ++j)
                        {
                            // Mengenberechnung
                            amountInLoop = amountInLoop - demandInLoop;

                            tbCurrentStockInLoopName = "currentStockP" + i + "D" + j + "K" + id;
                            tbCurrentStockInLoop = (TextBox)this.FindName(tbCurrentStockInLoopName);
                            int tbOldAmount = Convert.ToInt32(tbCurrentStockInLoop.Text);
                            amountInLoop = amountInLoop + tbOldAmount;
                            amountInLoopAsString = Convert.ToString(amountInLoop);
                            tbCurrentStockInLoop.Text = amountInLoopAsString;

                            // Hintergrundfarben setzen
                            if (amountInLoop < 0)
                            {
                                tbCurrentStockInLoop.Background = Brushes.Tomato;
                            }
                            else if (amountInLoop > 0)
                            {
                                tbCurrentStockInLoop.Background = Brushes.LightGreen;
                            }
                            else
                            {
                                tbCurrentStockInLoop.Background = Brushes.WhiteSmoke;
                            }

                        }
                    }

                    // Farbliche Hervorhebung der Eillieferung
                    TextBox tbCurrentStockPrioDelivery;
                    String tbCurrentStockPrioDeliveryName = "";

                    if (deliveryTimePriority >= 0 && deliveryTimePriority < 5)
                    {
                        deliveryTimePriority = deliveryTimePriority + 1;
                        tbCurrentStockPrioDeliveryName = "currentStockP0D" + deliveryTimePriority + "K" + id;
                    }

                    if (deliveryTimePriority >= 5 && deliveryTimePriority < 10)
                    {
                        deliveryTimePriority = deliveryTimePriority + 1 - 5;
                        tbCurrentStockPrioDeliveryName = "currentStockP1D" + deliveryTimePriority + "K" + id;
                    }

                    if (deliveryTimePriority >= 10 && deliveryTimePriority < 15)
                    {
                        deliveryTimePriority = deliveryTimePriority + 1 - 10;
                        tbCurrentStockPrioDeliveryName = "currentStockP2D" + deliveryTimePriority + "K" + id;
                    }

                    if (deliveryTimePriority >= 15 && deliveryTimePriority < 20)
                    {
                        deliveryTimePriority = deliveryTimePriority + 1 - 15;
                        tbCurrentStockPrioDeliveryName = "currentStockP3D" + deliveryTimePriority + "K" + id;
                    }

                    tbCurrentStockPrioDelivery = (TextBox)this.FindName(tbCurrentStockPrioDeliveryName);
                    tbCurrentStockPrioDelivery.Background = Brushes.MistyRose;

                    // Farbliche Hervorhebung der Normallieferung
                    TextBox tbCurrentStockDelivery;
                    String tbCurrentStockDeliveryName = "";

                    if (deliveryTimeInclDepartureTime >= 0 && deliveryTimeInclDepartureTime < 5)
                    {
                        deliveryTimeInclDepartureTime = deliveryTimeInclDepartureTime + 1;
                        tbCurrentStockDeliveryName = "currentStockP0D" + deliveryTimeInclDepartureTime + "K" + id;
                    }

                    if (deliveryTimeInclDepartureTime >= 5 && deliveryTimeInclDepartureTime < 10)
                    {
                        deliveryTimeInclDepartureTime = deliveryTimeInclDepartureTime + 1 - 5;
                        tbCurrentStockDeliveryName = "currentStockP1D" + deliveryTimeInclDepartureTime + "K" + id;
                    }

                    if (deliveryTimeInclDepartureTime >= 10 && deliveryTimeInclDepartureTime < 15)
                    {
                        deliveryTimeInclDepartureTime = deliveryTimeInclDepartureTime + 1 - 10;
                        tbCurrentStockDeliveryName = "currentStockP2D" + deliveryTimeInclDepartureTime + "K" + id;
                    }

                    if (deliveryTimeInclDepartureTime >= 15 && deliveryTimeInclDepartureTime < 20)
                    {
                        deliveryTimeInclDepartureTime = deliveryTimeInclDepartureTime + 1 - 15;
                        tbCurrentStockDeliveryName = "currentStockP3D" + deliveryTimeInclDepartureTime + "K" + id;
                    }

                    tbCurrentStockDelivery = (TextBox)this.FindName(tbCurrentStockDeliveryName);
                    tbCurrentStockDelivery.Background = Brushes.LightBlue;


                    // Kaufteil Menge als String
                    String amount = Convert.ToString(purchasePart.Amount);

                    // Textbox Name
                    String tbCurrentStockName = "currentStockK" + id;

                    // Finde entsprechende Textbox anhand ihres eindeutigen Namens
                    TextBox tbCurrentStock = (TextBox)this.FindName(tbCurrentStockName);

                    // Bestände befüllen
                    tbCurrentStock.Text = amount;

                }
            }

            else
            {
                btnShowDetails.Content = "Details einblenden";
                gridDetail.Visibility = Visibility.Hidden;

                // Hole Kaufteilliste aus StorageService
                List<WarehouseStock> purchasePartsList = new List<WarehouseStock>();
                purchasePartsList = StorageService.Instance.GetPurchaseParts();

                // Iteriere Kaufteilliste durch
                foreach (WarehouseStock purchasePart in purchasePartsList)
                {

                    // Kaufteil ID als String
                    String id = Convert.ToString(purchasePart.Id);
                    String tbCurrentStockInLoopName = "";
                    TextBox tbCurrentStockInLoop;

                    for (int i = 0; i < 4; ++i)
                    {

                        for (int j = 1; j < 6; ++j)
                        {
                            tbCurrentStockInLoopName = "currentStockP" + i + "D" + j + "K" + id;
                            tbCurrentStockInLoop = (TextBox)this.FindName(tbCurrentStockInLoopName);

                            tbCurrentStockInLoop.Text = Convert.ToString(0);
                            tbCurrentStockInLoop.Background = Brushes.Transparent;
                        }
                    }

                }

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
