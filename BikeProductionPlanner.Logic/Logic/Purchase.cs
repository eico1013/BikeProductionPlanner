using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Logic.Logic
{
    public class Purchase
    {

        // Kauteil definieren mit Konstruktor
        public class purchasePart
        {
            public int id;
            public int discountAmount;
            public int deliveryTime;
            public int departureTime;
            public double price;
            public int useInBike1;
            public int useInBike2;
            public int useInBike3;

            public purchasePart(int id, int discountAmount, int deliveryTime, int departureTime, double price, int useInBike1, int useInBike2, int useInBike3)
            {
                this.id = id;
                this.discountAmount = discountAmount;
                this.deliveryTime = deliveryTime;
                this.departureTime = departureTime;
                this.price = price;
                this.useInBike1 = useInBike1;
                this.useInBike2 = useInBike2;
                this.useInBike3 = useInBike3;
            }
        }

        // Kaufteile befüllen und in Liste ablegen
        public static List<purchasePart> purchaseParts = new List<purchasePart>()
        {
            new purchasePart(21, 300, 9, 2, 5.77, 1, 0, 0),
            new purchasePart(22, 300, 9, 2, 6.14, 0, 1, 0),
            new purchasePart(23, 300, 6, 1, 6.5, 0, 0, 1),
            new purchasePart(24, 6100, 16, 2, 0.19, 7, 7, 7),
            new purchasePart(25, 3600, 5, 1, 0.06, 4, 4, 4),
            new purchasePart(27, 1800, 5, 1, 0.12, 2, 2, 2),
            new purchasePart(28, 4500, 9, 2, 1.21, 4, 5, 6),
            new purchasePart(32, 2700, 11, 3, 0.71, 3, 3, 3),
            new purchasePart(33, 900, 10, 3, 22.0, 0, 0, 2),
            new purchasePart(34, 22000, 8, 2, 0.09, 0, 0, 72),
            new purchasePart(35, 3600, 11, 2, 1.05, 4, 4, 4),
            new purchasePart(36, 900, 6, 1, 7.54, 1, 1, 1),
            new purchasePart(37, 900, 8, 2, 1.42, 1, 1, 1),
            new purchasePart(38, 300, 9, 2, 1.78, 1, 1, 1),
            new purchasePart(39, 1800, 8, 2, 1.53, 2, 2, 2),
            new purchasePart(40, 900, 9, 1, 2.34, 1, 1, 1),
            new purchasePart(41, 900, 5, 1, 0.09, 1, 1, 1),
            new purchasePart(42, 1800, 6, 2, 0.11, 2, 2, 2),
            new purchasePart(43, 2700, 10, 3, 5.0, 1, 1, 1),
            new purchasePart(44, 900, 5, 1, 0.5, 3, 3, 3),
            new purchasePart(45, 900, 9, 2, 0.33, 1, 1, 1),
            new purchasePart(46, 900, 5, 2, 0.13, 1, 1, 1),
            new purchasePart(47, 900, 5, 1, 3.31, 1, 1, 1),
            new purchasePart(48, 1800, 5, 1, 1.43, 2, 2, 2),
            new purchasePart(52, 600, 8, 2, 21.36, 2, 0, 0),
            new purchasePart(53, 22000, 8, 1, 0.09, 72, 0, 0),
            new purchasePart(57, 600, 9, 2, 21.65, 0, 2, 0),
            new purchasePart(58, 22000, 8, 3, 0.11, 0, 72, 0),
            new purchasePart(59, 1800, 4, 1, 0.16, 2, 2, 2)
        };

        public static List<purchasePart> GetPurchasePartsFromPurchase()
        {
            return purchaseParts;
        }

        // Hole Kaufteil anhand seiner ID
        public static purchasePart GetPurchasePartFromPurchaseByID(int id)
        {
            return GetPurchasePartsFromPurchase().Find(x => x.id == id);
        }

        // Bedarfsklasse
        public class Demand
        {
            public int idDemand;
            public int demandInP0;
            public int demandInP1;
            public int demandInP2;
            public int demandInP3;

            public Demand(int idDemand, int demandInP0, int demandInP1, int demandInP2, int demandInP3)
            {
                this.idDemand = idDemand;
                this.demandInP0 = demandInP0;
                this.demandInP1 = demandInP1;
                this.demandInP2 = demandInP2;
                this.demandInP3 = demandInP3;
            }
        }
            
        // Hole Kaufteilliste aus StorageService
        static List<WarehouseStock> purchasePartsFromXML = StorageService.Instance.GetPurchaseParts();
        static List<purchasePart> purchasePartsFromPurchase = GetPurchasePartsFromPurchase();
            

        // Hole Vertriebswunsch und Prognosen aus StorageService
        // Periode 0
        public static int salesOfBike1InP0 = StorageService.Instance.vertriebswunschP1;
        public static int salesOfBike2InP0 = StorageService.Instance.vertriebswunschP2;
        public static int salesOfBike3InP0 = StorageService.Instance.vertriebswunschP3;
        //Periode 1
        public static int salesOfBike1InP1 = StorageService.Instance.prognose1P1;
        public static int salesOfBike2InP1 = StorageService.Instance.prognose1P2;
        public static int salesOfBike3InP1 = StorageService.Instance.prognose1P3;
        //Periode 2
        public static int salesOfBike1InP2 = StorageService.Instance.prognose2P1;
        public static int salesOfBike2InP2 = StorageService.Instance.prognose2P2;
        public static int salesOfBike3InP2 = StorageService.Instance.prognose2P3;
        //Periode 3
        public static int salesOfBike1InP3 = StorageService.Instance.prognose3P1;
        public static int salesOfBike2InP3 = StorageService.Instance.prognose3P2;
        public static int salesOfBike3InP3 = StorageService.Instance.prognose3P3;

        // Bedarf für jedes Kaufteil berechnen und in Liste ablegen        
        public static List<Demand> GetDemandOfParts()
        {
            List<Demand> demandOfParts = new List<Demand>();

            foreach (purchasePart pb in purchasePartsFromPurchase)
            {
                int calculatedDemandP0 = pb.useInBike1 * salesOfBike1InP0 +
                                            pb.useInBike2 * salesOfBike2InP0 +
                                            pb.useInBike3 * salesOfBike3InP0;

                int calculatedDemandP1 = pb.useInBike1 * salesOfBike1InP1 +
                                            pb.useInBike2 * salesOfBike2InP1 +
                                            pb.useInBike3 * salesOfBike3InP1;

                int calculatedDemandP2 = pb.useInBike1 * salesOfBike1InP2 +
                                            pb.useInBike2 * salesOfBike2InP2 +
                                            pb.useInBike3 * salesOfBike3InP2;

                int calculatedDemandP3 = pb.useInBike1 * salesOfBike1InP3 +
                                            pb.useInBike2 * salesOfBike2InP3 +
                                            pb.useInBike3 * salesOfBike3InP3;

                demandOfParts.Add(new Demand(pb.id, calculatedDemandP0, calculatedDemandP1,
                                                    calculatedDemandP2, calculatedDemandP3));
            }
                
            return demandOfParts;

        }

        // Hole Bedarf eines Kaufteils
        public static Demand GetDemandByID(int id)
        {
            return GetDemandOfParts().Find(x => x.idDemand == id);
        }

        // Hole eingehende Bestellungen aus StorageService
        static List<FutureInwardStockMovment> futureInwardStockMovments = StorageService.Instance.GetFutureInwardStockMovment();

        // Reichweite berechnen
        public static void calculateCoverage()
        { 
            int startAmountInP0 = 0;
            int startAmountInP1 = 0;
            int startAmountInP2 = 0;
            int startAmountInP3 = 0;
            int coverageInP0 = 0;
            int coverageInP1 = 0;
            int coverageInP2 = 0;
            int coverageInP3 = 0;
            int coverageSum = 0;
            int deliveryTimeInclDepartureTime = 0;
            int deliveryTimePriority = 0;
            int currentPeriod = StorageService.Instance.GetPeriodFromXml() + 1;

            foreach (WarehouseStock wh in purchasePartsFromXML)
            {
                // Alle Werte auf 0 setzen, nach jedem Schleifendurchlauf
                startAmountInP0 = 0;
                startAmountInP1 = 0;
                startAmountInP2 = 0;
                startAmountInP3 = 0;
                coverageInP0 = 0;
                coverageInP1 = 0;
                coverageInP2 = 0;
                coverageInP3 = 0;
                coverageSum = 0;
                deliveryTimeInclDepartureTime = 0;
                deliveryTimePriority = 0;
                List<FutureInwardStockMovment> incomingOrders;

                // Setze Lieferzeit mit Abweichung und Eillieferzeit für den Artikel
                deliveryTimeInclDepartureTime = GetPurchasePartFromPurchaseByID(wh.Id).deliveryTime + GetPurchasePartFromPurchaseByID(wh.Id).departureTime;
                deliveryTimePriority = GetPurchasePartFromPurchaseByID(wh.Id).deliveryTime / 2;

                // Extrahiere alle Bestellungen des Artikels
                incomingOrders = futureInwardStockMovments.FindAll(item => item.Article.Equals(wh.Id));

                // Befülle Startmengen mit Lieferzugängen aus der Liste
                foreach (FutureInwardStockMovment incomingPart in incomingOrders)
                {
                    int incomingOrderDate = 0;
                    int incomingOrderDay = 0;
                    int incomingOrderAmount = 0;

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
                    incomingOrderAmount = incomingPart.Amount;

                    if (incomingOrderDay >= 0 && incomingOrderDay < 5)
                    {
                        startAmountInP0 = startAmountInP0 + incomingOrderAmount;
                    }

                    if (incomingOrderDay >= 5 && incomingOrderDay < 10)
                    {
                        startAmountInP1 = startAmountInP1 + incomingOrderAmount;
                    }

                    if (incomingOrderDay >= 10 && incomingOrderDay < 15)
                    {
                        startAmountInP2 = startAmountInP2 + incomingOrderAmount;
                    }

                    if (incomingOrderDay >= 15 && incomingOrderDay < 20)
                    {
                        startAmountInP3 = startAmountInP3 + incomingOrderAmount;
                    }
                }

                // Reichweitenberechnung für den Artikel
                // Periode 0
                startAmountInP0 = startAmountInP0 + wh.Amount;
                // nicht aufgerundet
                double test1 = Convert.ToDouble(Convert.ToDouble(startAmountInP0) / Convert.ToDouble((GetDemandByID(wh.Id).demandInP0) / 5.0));
                // aufgerundet
                coverageInP0 = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(startAmountInP0 / (GetDemandByID(wh.Id).demandInP0 / 5)))));

                coverageSum = coverageInP0;

                // Periode 1
                if (coverageInP0 > 5)
                {
                    startAmountInP1 = startAmountInP1 + startAmountInP0 - GetDemandByID(wh.Id).demandInP0;
                    // nicht aufgerundet
                    double test2 = Convert.ToDouble(Convert.ToDouble(startAmountInP1) / Convert.ToDouble((GetDemandByID(wh.Id).demandInP1) / 5.0));
                    // aufgerundet
                    coverageInP1 = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(startAmountInP1 / (GetDemandByID(wh.Id).demandInP1 / 5)))));

                    coverageSum = 5 + coverageInP1;
                    // Periode 2
                    if (coverageInP1 > 5)
                    {
                        startAmountInP2 = startAmountInP2 + startAmountInP1 - GetDemandByID(wh.Id).demandInP1;
                        // nicht aufgerundet
                        double test3 = Convert.ToDouble(Convert.ToDouble(startAmountInP2) / Convert.ToDouble((GetDemandByID(wh.Id).demandInP2) / 5.0));
                        // aufgerundet
                        coverageInP2 = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(startAmountInP2 / (GetDemandByID(wh.Id).demandInP2 / 5)))));

                        coverageSum = 10 + coverageInP2;
                        // Periode 3
                        if (coverageInP2 > 5)
                        {
                            startAmountInP3 = startAmountInP3 + startAmountInP2 - GetDemandByID(wh.Id).demandInP2;
                            // nicht aufgerundet
                            double test4 = Convert.ToDouble(Convert.ToDouble(startAmountInP3) / Convert.ToDouble((GetDemandByID(wh.Id).demandInP3) / 5.0));
                            // aufgerundet
                            coverageInP3 = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(startAmountInP3 / (GetDemandByID(wh.Id).demandInP3 / 5)))));

                            coverageSum = 15 + coverageInP3;
                        }
                    }
                }

                // Anhand Reichweite Bestellungen bestimmen
                if ((coverageSum < 20) && (coverageSum.CompareTo(deliveryTimeInclDepartureTime) >= 0))
                {
                    if (coverageSum.CompareTo(deliveryTimeInclDepartureTime) >= 5)
                    {
                        // Keine Bestellung
                        // Kein Todo: weder Frontend noch Backend
                    }

                    else
                    {
                        // Normalbestellung
                        // Frontend aktualisieren: Menge und Normal
                        // Normalbestellung der Bestellliste hinzufügen

                        // Typ 5 bedeutet Normalbestellung
                        int orderType = 5;
                        int daysOfPeriodGone = coverageSum;
                        int daysOfPeriodLeft = 20 - coverageSum;
                        int orderAmount = 0;
                        int amountDifference = 0;

                        // Periode 3
                        if (daysOfPeriodLeft >= 0 && daysOfPeriodLeft <= 5)
                        {
                            orderAmount = (GetDemandByID(wh.Id).demandInP3 / 5) * daysOfPeriodLeft;

                            daysOfPeriodGone = daysOfPeriodGone - 15;
                            amountDifference = startAmountInP3 - ((GetDemandByID(wh.Id).demandInP3 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 2
                        if (daysOfPeriodLeft > 5 && daysOfPeriodLeft <= 10)
                        {
                            daysOfPeriodLeft = daysOfPeriodLeft - 5;
                            orderAmount = (GetDemandByID(wh.Id).demandInP2 / 5) * daysOfPeriodLeft + GetDemandByID(wh.Id).demandInP3;

                            daysOfPeriodGone = daysOfPeriodGone - 10;
                            amountDifference = startAmountInP2 - ((GetDemandByID(wh.Id).demandInP2 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 1
                        if (daysOfPeriodLeft > 10 && daysOfPeriodLeft <= 15)
                        {
                            daysOfPeriodLeft = daysOfPeriodLeft - 10;
                            orderAmount = (GetDemandByID(wh.Id).demandInP1 / 5) * daysOfPeriodLeft + GetDemandByID(wh.Id).demandInP2 +
                                        GetDemandByID(wh.Id).demandInP3;

                            daysOfPeriodGone = daysOfPeriodGone - 5;
                            amountDifference = startAmountInP1 - ((GetDemandByID(wh.Id).demandInP1 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 0
                        if (daysOfPeriodLeft > 15 && daysOfPeriodLeft <= 20)
                        {
                            daysOfPeriodLeft = daysOfPeriodLeft - 15;
                            orderAmount = (GetDemandByID(wh.Id).demandInP0 / 5) * daysOfPeriodLeft + GetDemandByID(wh.Id).demandInP1 +
                                        GetDemandByID(wh.Id).demandInP2 + GetDemandByID(wh.Id).demandInP3;

                            amountDifference = startAmountInP0 - ((GetDemandByID(wh.Id).demandInP0 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Füge Artikel der Bestellliste hinzu
                        OrderList orderListItem = new OrderList(orderAmount, wh.Id, orderType);
                        StorageService.Instance.AddOrderItem(orderListItem);
                    }

                }

                if ((coverageSum < 20) && (coverageSum.CompareTo(deliveryTimeInclDepartureTime) < 0))
                {
                    if (coverageSum.CompareTo(deliveryTimePriority) >= 5)
                    {
                        // Keine Bestellung
                        // Kein Todo: weder Frontend noch Backend
                    }

                    else
                    {
                        // Eilbestellung
                        // Frontend aktualisieren: Menge und Eil
                        // Eilbestellung der Bestellliste hinzufügen

                        // Typ 4 bedeutet Eilbestellung
                        int orderType = 4;
                        int daysOfPeriodGone = coverageSum;
                        int daysOfPeriodLeft = 20 - coverageSum;
                        int orderAmount = 0;
                        int amountDifference = 0;

                        // Periode 3
                        if (daysOfPeriodLeft >= 0 && daysOfPeriodLeft <= 5)
                        {
                            orderAmount = (GetDemandByID(wh.Id).demandInP3 / 5) * daysOfPeriodLeft;

                            daysOfPeriodGone = daysOfPeriodGone - 15;
                            amountDifference = startAmountInP3 - ((GetDemandByID(wh.Id).demandInP3 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 2
                        if (daysOfPeriodLeft > 5 && daysOfPeriodLeft <= 10)
                        {
                            daysOfPeriodLeft = daysOfPeriodLeft - 5;
                            orderAmount = (GetDemandByID(wh.Id).demandInP2 / 5) * daysOfPeriodLeft + GetDemandByID(wh.Id).demandInP3;

                            daysOfPeriodGone = daysOfPeriodGone - 10;
                            amountDifference = startAmountInP2 - ((GetDemandByID(wh.Id).demandInP2 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 1
                        if (daysOfPeriodLeft > 10 && daysOfPeriodLeft <= 15)
                        {
                            daysOfPeriodLeft = daysOfPeriodLeft - 10;
                            orderAmount = (GetDemandByID(wh.Id).demandInP1 / 5) * daysOfPeriodLeft + GetDemandByID(wh.Id).demandInP2 +
                                        GetDemandByID(wh.Id).demandInP3;

                            daysOfPeriodGone = daysOfPeriodGone - 5;
                            amountDifference = startAmountInP1 - ((GetDemandByID(wh.Id).demandInP1 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 0
                        if (daysOfPeriodLeft > 15 && daysOfPeriodLeft <= 20)
                        {
                            daysOfPeriodLeft = daysOfPeriodLeft - 15;
                            orderAmount = (GetDemandByID(wh.Id).demandInP0 / 5) * daysOfPeriodLeft + GetDemandByID(wh.Id).demandInP1 +
                                        GetDemandByID(wh.Id).demandInP2 + GetDemandByID(wh.Id).demandInP3;

                            amountDifference = startAmountInP0 - ((GetDemandByID(wh.Id).demandInP0 / 5) * daysOfPeriodGone);
                            orderAmount = orderAmount - amountDifference;
                        }

                        // Füge Artikel der Bestellliste hinzu
                        OrderList orderListItem = new OrderList(orderAmount, wh.Id, orderType);
                        StorageService.Instance.AddOrderItem(orderListItem);

                        if (coverageSum.CompareTo(deliveryTimePriority) < 0)
                        {
                            // Eilbestellung
                            // Frontend aktualisieren: Menge und Eil und 
                            // Hinweis: Auch Eilbestellung kommt nicht rechtzeitig!
                            // Eilbestellung der Bestellliste hinzufügen
                        }
                    }
                }

            }

        }

    }
}
