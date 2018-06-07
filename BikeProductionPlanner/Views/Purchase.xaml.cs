using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using BikeProductionPlanner.Logic.Database;
using BikeProductionPlanner.Logic.Database.Model;
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

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.purchaseGrid.ItemsSource = new ObservableCollection<PurchaseElement>();

            purchaseGrid.Loaded += purchaseGrid_Loaded;
        }

        // Methode die die ToolTip Methode ruft, sobald der DataGrid geladen wurde
        private void purchaseGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => SetPurchasePartsToolTips()));
        }

        // Methode die die ToolTips für jedes Kaufteil setzt
        private void SetPurchasePartsToolTips()
        {
            // ToolTip für Teileverwendung
            List<purchasePartTooltip> purchasePartsTooltip = new List<purchasePartTooltip>();
            purchasePartsTooltip = GetPurchasePartsTooltip();

            // ToolTip für Diskontmenge und Preis
            List<purchasePart> purchaseParts = new List<purchasePart>();
            purchaseParts = GetPurchasePartsFromPurchase();

            foreach (PurchaseElement item in purchaseGrid.Items)
            {
                DataGridRow dataGridRow = (DataGridRow)purchaseGrid.ItemContainerGenerator.ContainerFromItem(item);
                TextBlock purchasePart = purchaseGrid.Columns[0].GetCellContent(dataGridRow) as TextBlock;
                TextBlock orderAmount = purchaseGrid.Columns[1].GetCellContent(dataGridRow) as TextBlock;

                int kaufteilID = Convert.ToInt32(item.Kaufteil);
                purchasePartTooltip purchasePartTooltip = purchasePartsTooltip.Find(x => x.idPPTooltip == kaufteilID);
                purchasePart orderAmountTooltip = purchaseParts.Find(y => y.id == kaufteilID);

                purchasePart.ToolTip = "Teileverwendung für \r\n" + "Kaufteil " + purchasePartTooltip.idPPTooltip + " - " +
                                                purchasePartTooltip.name + ": \r\n \r\n" + purchasePartTooltip.rawString;

                orderAmount.ToolTip = ("Kaufteil " + orderAmountTooltip.id + " - " + purchasePartTooltip.name + ": \r\n \r\n" +
                                        "Diskontmenge: " + orderAmountTooltip.discountAmount + "\r\n" +
                                        "Preis: " + orderAmountTooltip.price);

                ToolTipService.SetShowDuration(purchasePart, 60000);
                ToolTipService.SetShowDuration(orderAmount, 60000);
            }

        }

        // Befülle DataGrid mit Werten
        public void UpdatePurchaseFields()
        {
            StorageService.Instance.ClearOrderItemList();
            BikeProductionPlanner.Logic.Logic.Purchase.calculateCoverage();

            var fields = (ObservableCollection<PurchaseElement>)purchaseGrid.ItemsSource;
            fields.Clear();

            // Setze aktuelle Periode
            int currentPeriod = StorageService.Instance.GetPeriodFromXml() + 1;

            // Hole Bestellliste aus Storage Service
            List<OrderList> orderList = new List<OrderList>();
            orderList = StorageService.Instance.GetAllOrders();

            // Hole Kaufteilliste aus StorageService
            List<WarehouseStock> purchasePartsList = new List<WarehouseStock>();
            purchasePartsList = StorageService.Instance.GetPurchaseParts();

            int deliveryTimeInclDepartureTime = 0;
            int deliveryTimePriority = 0;

            // Hole eingehende Bestellungen aus StorageService
            List<FutureInwardStockMovment> futureInwardStockMovments = StorageService.Instance.GetFutureInwardStockMovment();

            // Hole Bedarfsliste aus Purchase Klasse
            List<Demand> demandOfPartsList = new List<Demand>();
            demandOfPartsList = GetDemandOfParts();

            foreach (WarehouseStock purchasePart in purchasePartsList)
            {

                OrderList orderListItem = orderList.Find(x => x.Article == purchasePart.Id);

                String id = Convert.ToString(purchasePart.Id);
                String orderAmount = "0";
                String orderType = "Keine";
                String startAmount = Convert.ToString(purchasePart.Amount);
                String[] purchaseEndAmounts = new String[20];

                if (!(orderListItem == null))
                {
                    orderAmount = Convert.ToString(orderListItem.Quantity);

                    if (orderListItem.Modus == 4)
                    {
                        orderType = "Eil";
                    }
                    else
                    {
                        orderType = "Normal";
                    }
                }

                deliveryTimeInclDepartureTime = 0;
                deliveryTimePriority = 0;

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
                    purchaseEndAmounts[incomingOrderDay] = Convert.ToString(incomingOrderAmount);

                }

                String amountInLoopAsString = "";
                int amountInLoop = 0;
                int demandInLoop = 0;
                // Initiale Mengenberechnung
                amountInLoop = purchasePart.Amount;

                for (int i = 0; i < 20; ++i)
                {
                    if (i >= 0 && i < 5)
                    {
                        demandInLoop = demandP0PerDay;
                    }

                    if (i >= 5 && i < 10)
                    {
                        demandInLoop = demandP1PerDay;
                    }

                    if (i >= 10 && i < 15)
                    {
                        demandInLoop = demandP2PerDay;
                    }

                    if (i >= 15 && i < 20)
                    {
                        demandInLoop = demandP3PerDay;
                    }

                    // Mengenberechnung
                    amountInLoop = amountInLoop - demandInLoop;
                    int tbOldAmount = Convert.ToInt32(purchaseEndAmounts[i]);
                    amountInLoop = amountInLoop + tbOldAmount;
                    amountInLoopAsString = Convert.ToString(amountInLoop);
                    purchaseEndAmounts[i] = amountInLoopAsString;

                }


                fields.Add(new PurchaseElement(id, orderAmount, orderType, startAmount, purchaseEndAmounts[0],
                                                purchaseEndAmounts[1], purchaseEndAmounts[2], purchaseEndAmounts[3],
                                                purchaseEndAmounts[4], purchaseEndAmounts[5], purchaseEndAmounts[6],
                                                purchaseEndAmounts[7], purchaseEndAmounts[8], purchaseEndAmounts[9],
                                                purchaseEndAmounts[10], purchaseEndAmounts[11], purchaseEndAmounts[12],
                                                purchaseEndAmounts[13], purchaseEndAmounts[14], purchaseEndAmounts[15],
                                                purchaseEndAmounts[16], purchaseEndAmounts[17], purchaseEndAmounts[18],
                                                purchaseEndAmounts[19]));

            }


        }

        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {

            if (btnShowDetails.Content.Equals("Details einblenden"))
            {
                btnShowDetails.Content = "Details ausblenden";

                //Create a new column to add to the DataGrid
                DataGridTextColumn textcol = new DataGridTextColumn();
                //Create a Binding object to define the path to the DataGrid.ItemsSource property
                //The column inherits its DataContext from the DataGrid, so you don't set the source
                Binding b = new Binding("Anfangsbestand");
                //Set the properties on the new column
                textcol.Binding = b;
                textcol.Header = "Anfangsbestand";
                textcol.IsReadOnly = true;
                //Add the column to the DataGrid
                purchaseGrid.Columns.Add(textcol);

                String EndbestandName = "";

                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 1; j < 6; ++j)
                    {
                        EndbestandName = "EndbestandP" + i + "D" + j;
                        textcol = new DataGridTextColumn();
                        b = new Binding(EndbestandName);
                        textcol.Binding = b;
                        textcol.Header = EndbestandName;
                        textcol.IsReadOnly = true;
                        purchaseGrid.Columns.Add(textcol);

                    }
                }

                int deliveryTimeInclDepartureTime = 0;
                int deliveryTimePriority = 0;
                int kaufteilID = 0;

                // Hole eingehende Bestellungen aus StorageService
                List<FutureInwardStockMovment> futureInwardStockMovments = StorageService.Instance.GetFutureInwardStockMovment();

                // Setze aktuelle Periode
                int currentPeriod = 0;
                currentPeriod = StorageService.Instance.GetPeriodFromXml() + 1;

                purchaseGrid.UpdateLayout();
                for (int i = 4; i < 24; ++i)
                {
                    foreach (PurchaseElement item in purchaseGrid.Items)
                    {
                        deliveryTimeInclDepartureTime = 0;
                        deliveryTimePriority = 0;
                        kaufteilID = 0;
                        kaufteilID = Convert.ToInt32(item.Kaufteil);

                        List<FutureInwardStockMovment> incomingOrders;
                        // Extrahiere alle Bestellungen des Artikels
                        incomingOrders = futureInwardStockMovments.FindAll(x => x.Article.Equals(kaufteilID));

                        DataGridRow dataGridRow = (DataGridRow)purchaseGrid.ItemContainerGenerator.ContainerFromItem(item);
                        TextBlock tb = purchaseGrid.Columns[i].GetCellContent(dataGridRow) as TextBlock;

                        DataGridCell dataGridCell = (DataGridCell)tb.Parent;

                        int tbAmount = Convert.ToInt32(tb.Text);

                        // Bestände Hintergrundfarben setzen
                        if (tbAmount < 0)
                        {
                            dataGridCell.Background = Brushes.Tomato;
                        }
                        else if (tbAmount > 0)
                        {
                            dataGridCell.Background = Brushes.LightGreen;
                        }
                        else
                        {
                            dataGridCell.Background = Brushes.WhiteSmoke;
                        }

                        // Bestelleingänge Hintergrundfarben setzen
                        // Setze Lieferzeit mit Abweichung und Eillieferzeit für den Artikel
                        deliveryTimeInclDepartureTime = GetPurchasePartFromPurchaseByID(kaufteilID).deliveryTime + GetPurchasePartFromPurchaseByID(kaufteilID).departureTime;
                        deliveryTimePriority = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(GetPurchasePartFromPurchaseByID(kaufteilID).deliveryTime) / 2.0));

                        if (deliveryTimeInclDepartureTime + 4 == i)
                        {
                            dataGridCell.Background = Brushes.LightBlue;
                        }

                        if (deliveryTimePriority + 4 == i)
                        {
                            dataGridCell.Background = Brushes.MistyRose;
                        }

                        // Eingehende Lieferungen dick schreiben
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

                            if (incomingOrderDay + 4 == i)
                            {
                                tb.FontWeight = FontWeights.Bold;
                                tb.ToolTip = "Eingehende Lieferung: " + Convert.ToString(incomingOrderAmount);
                            }
                        }

                    }
                }

            }

            else
            {
                btnShowDetails.Content = "Details einblenden";

                for (int i = 1; i < 22; ++i)
                {
                    purchaseGrid.Columns.RemoveAt(3);
                }
                
            }

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (StorageService.Instance.GetPeriodFromXml() > -1)
            {
                UpdatePurchaseFields();
            }
            
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            // Hole Bestellliste aus StorageService
            List<OrderList> orderList = new List<OrderList>();
            orderList = StorageService.Instance.GetAllOrders();

            // Iteriere Kaufteilliste durch
            foreach (PurchaseElement item in purchaseGrid.Items)
            {
                int kaufteilID = Convert.ToInt32(item.Kaufteil);
                int convertedOrderAmount = Convert.ToInt32(item.Bestellmenge);
                String orderType = item.Bestellart;

                if (convertedOrderAmount > 0 && (orderType == "Eil" || orderType == "Normal"))
                {
                    int convertedOrderType = 0;
                    if (orderType == "Eil")
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
                    if (orderList.Exists(x => x.Article == kaufteilID))
                    {
                        OrderList orderListItem = orderList.Find(x => x.Article == kaufteilID);
                        if (!(orderListItem.Quantity.Equals(convertedOrderAmount)) || !(orderListItem.Modus.Equals(convertedOrderType)))
                        {
                            int index = orderList.IndexOf(orderListItem);
                            orderList[index].Quantity = convertedOrderAmount;
                            orderList[index].Modus = convertedOrderType;
                        }
                    }

                    // Falls nein, dann füge das neue Kaufteil der Bestellliste hinzu
                    else
                    {
                        OrderList newOrderListItem = new OrderList(convertedOrderAmount, kaufteilID, convertedOrderType);
                        StorageService.Instance.AddOrderItem(newOrderListItem);
                    }

                }

                // Kaufteil von Bestellliste entfernen, wenn keine Bestellung gewünscht wird
                if (convertedOrderAmount == 0 || orderType == "Keine")
                {
                    if (orderList.Exists(x => x.Article == kaufteilID))
                    {
                        OrderList orderListItem = orderList.Find(x => x.Article == kaufteilID);
                        StorageService.Instance.RemoveOrderItem(orderListItem);
                    }
                }

            }

            // Wechsle auf nächste Seite
            MainWindowFinal.Instance.NavigateTo(Logic.UI.MenuItems.MenuItemsEnum.CustomizePage);
            MainWindowFinal.Instance.ListViewMenu.SelectedIndex = 7;

        }

    }
}
