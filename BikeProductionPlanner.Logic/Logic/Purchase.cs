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

        // Kaufteilklasse für Tooltip
        public class purchasePartTooltip
        {
            public int idPPTooltip;
            public String name;
            public String rawString;

            public purchasePartTooltip(int idPPTooltip, String name, String rawString)
            {
                this.idPPTooltip = idPPTooltip;
                this.name = name;
                this.rawString = rawString;
            }
        }

        // Liste der Kaufteil für Tooltip
        public static List<purchasePartTooltip> purchasePartsTooltip = new List<purchasePartTooltip>()
        {
            new purchasePartTooltip(21, "Kette", "1 * P1 Kinderfahrrad"),
            new purchasePartTooltip(22, "Kette", "1 * P2 Damenfahrrad"),
            new purchasePartTooltip(23, "Kette", "1 * P3 Herrenfahrrad"),
            new purchasePartTooltip(24, "Mutter 3/8", "1 * P1 Kinderfahrrad \r\n 1 * E51 Fahrrad ohne Pedal \r\n 1 * E16 Lenker cpl. \r\n" +
                                                      "2 * E50 Rahmen und Räder \r\n 2 * E49 Vorderrad cpl. \r\n \r\n 1 * P2 Damenfahrrad \r\n" +
                                                      "1 * E56 Fahrrad ohne Pedal \r\n 1 * E16 Lenker cpl. \r\n 2 * E55 Rahmen und Räder \r\n" +
                                                      "2 * E54 Vorderrad cpl. \r\n \r\n 1 * P3 Herrenfahrrad \r\n 1 * E31 Fahrrad ohne Pedal \r\n" +
                                                      "1 * E16 Lenker cpl. \r\n 2 * E30 Rahmen und Räder \r\n 2 * E29 Vorderrad montiert"),
            new purchasePartTooltip(25, "Scheibe 3/8", "Kinderfahrrad \r\n 2 * E50 Rahmen und Räder \r\n 2 * E49 Vorderrad cpl. \r\n \r\n Damenfahrrad \r\n" + 
                                                       "2 * E55 Rahmen und Räder \r\n 2 * E54 Vorderrad cpl. \r\n \r\n Herrenfahrrad \r\n" + 
                                                       "2 * E30 Rahmen und Räder \r\n 2 * E29 Vorderrad montiert"),
            new purchasePartTooltip(27, "Schraube 3/8", "1 * P1 Kinderfahrrad \r\n 1 * E51 Fahrrad ohne Pedal \r\n \r\n 1 * P2 Damenfahrrad \r\n" +
                                                        "1 * E56 Fahrrad ohne Pedal \r\n \r\n 1 * P3 Herrenfahrrad \r\n 1 * E31 Fahrrad ohne Pedal"),
            new purchasePartTooltip(28, "Rohr 3/4", "Kinderfahrrad \r\n 1 * E16 Lenker cpl. \r\n 3 * E18 Rahmen \r\n \r\n Damenfahrrad \r\n" + 
                                                    "1 * E16 Lenker cpl. \r\n 4 * E19 Rahmen \r\n \r\n Herrenfahrrad \r\n 1 * E16 Lenker cpl. \r\n 5 * E20 Rahmen"),
            new purchasePartTooltip(32, "Farbe", "Kinderfahrrad \r\n 1 * E10 Schutzblech hinten \r\n 1 * E13 Schutzblech vorn \r\n 1 * E18 Rahmen \r\n \r\n" +
                                                 "Damenfahrrad \r\n 1 * E11 Schutzblech hinten \r\n 1 * E14 Schutzblech vorn \r\n 1 * E19 Rahmen \r\n \r\n" +
                                                 "Herrenfahrrad \r\n 1 * E12 Schutzblech hinten \r\n 1 * E15 Schutzblech vorn \r\n 1 * E20 Rahmen"),
            new purchasePartTooltip(33, "Felge cpl.", "Herrenfahrrad \r\n 1 * E6 Hinterradgruppe \r\n 1 * E9 Vorderradgruppe"),
            new purchasePartTooltip(34, "Speiche", "Herrenfahrrad \r\n 36 * E6 Hinterradgruppe \r\n 36 * E9 Vorderradgruppe"),
            new purchasePartTooltip(35, "Nabe", "Kinderfahrrad \r\n 2 * E4 Hinterradgruppe \r\n 2 * E7 Vorderradgruppe \r\n \r\n Damenfahrrad \r\n" + 
                                                "2 * E5 Hinterradgruppe \r\n 2 * E8 Vorderradgruppe \r\n \r\n Herrenfahrrad \r\n 2 * E6 Hinterradgruppe \r\n" +
                                                "2 * E9 Vorderradgruppe"),
            new purchasePartTooltip(36, "Freilauf", "Kinderfahrrad \r\n 1 * E4 Hinterradgruppe \r\n \r\n Damenfahrrad \r\n 1 * E5 Hinterradgruppe \r\n \r\n" +
                                                    "Herrenfahrrad \r\n 1 * E6 Hinterradgruppe"),
            new purchasePartTooltip(37, "Gabel", "Kinderfahrrad \r\n 1 * E7 Vorderradgruppe \r\n \r\n Damenfahrrad \r\n 1 * E8 Vorderradgruppe \r\n \r\n" +
                                                 "Herrenfahrrad \r\n 1 * E9 Vorderradgruppe"),
            new purchasePartTooltip(38, "Welle", "Kinderfahrrad \r\n 1 * E7 Vorderradgruppe \r\n \r\n Damenfahrrad \r\n 1 * E8 Vorderradgruppe \r\n \r\n" +
                                                 "Herrenfahrrad \r\n 1 * E9 Vorderradgruppe"),
            new purchasePartTooltip(39, "Blech", "Kinderfahrrad \r\n 1 * E10 Schutzblech hinten \r\n 1 * E13 Schutzblech vorn \r\n \r\n" +
                                                 "Damenfahrrad \r\n 1 * E11 Schutzblech hinten \r\n 1 * E14 Schutzblech vorn \r\n \r\n" +
                                                 "Herrenfahrrad \r\n 1 * E12 Schutzblech hinten \r\n 1 * E15 Schutzblech vorn"),
            new purchasePartTooltip(40, "Lenker", "Kinderfahrrad \r\n 1 * E16 Lenker cpl. \r\n \r\n Damenfahrrad \r\n 1 * E16 Lenker cpl. \r\n \r\n" +
                                                  "Herrenfahrrad \r\n 1 * E16 Lenker cpl."),
            new purchasePartTooltip(41, "Mutter 3/4", "Kinderfahrrad \r\n 1 * E16 Lenker cpl. \r\n \r\n Damenfahrrad \r\n 1 * E16 Lenker cpl. \r\n \r\n" +
                                                      "Herrenfahrrad \r\n 1 * E16 Lenker cpl."),
            new purchasePartTooltip(42, "Griff", "Kinderfahrrad \r\n 2 * E16 Lenker cpl. \r\n \r\n Damenfahrrad \r\n 2 * E16 Lenker cpl. \r\n \r\n" +
                                                 "Herrenfahrrad \r\n 2 * E16 Lenker cpl."),
            new purchasePartTooltip(43, "Sattel", "Kinderfahrrad \r\n 1 * E17 Sattel cpl. \r\n \r\n Damenfahrrad \r\n 1 * E17 Sattel cpl. \r\n \r\n" +
                                                  "Herrenfahrrad \r\n 1 * E17 Sattel cpl."),
            new purchasePartTooltip(44, "Stange 1/2", "Kinderfahrrad \r\n 2 * E26 Pedal cpl. \r\n 1 * E17 Sattel cpl. \r\n \r\n" +
                                                      "Damenfahrrad \r\n 2 * E26 Pedal cpl. \r\n 1 * E17 Sattel cpl. \r\n \r\n" +
                                                      "Herrenfahrrad \r\n 2 * E26 Pedal cpl. \r\n 1 * E17 Sattel cpl."),
            new purchasePartTooltip(45, "Mutter 1/4", "Kinderfahrrad \r\n 1 * E17 Sattel cpl. \r\n \r\n Damenfahrrad \r\n 1 * E17 Sattel cpl. \r\n \r\n" +
                                                      "Herrenfahrrad \r\n 1 * E17 Sattel cpl."),
            new purchasePartTooltip(46, "Schraube 1/4", "Kinderfahrrad \r\n 1 * E17 Sattel cpl. \r\n \r\n Damenfahrrad \r\n 1 * E17 Sattel cpl. \r\n \r\n" +
                                                        "Herrenfahrrad \r\n 1 * E17 Sattel cpl."),
            new purchasePartTooltip(47, "Zahnkranz", "Kinderfahrrad \r\n 1 * E26 Pedal cpl. \r\n \r\n Damenfahrrad \r\n 1 * E26 Pedal cpl. \r\n \r\n" +
                                                     "Herrenfahrrad \r\n 1 * E26 Pedal cpl."),
            new purchasePartTooltip(48, "Pedal", "Kinderfahrrad \r\n 2 * E26 Pedal cpl. \r\n \r\n Damenfahrrad \r\n 2 * E26 Pedal cpl. \r\n \r\n" +
                                                 "Herrenfahrrad \r\n 2 * E26 Pedal cpl."),
            new purchasePartTooltip(52, "Felge cpl.", "Kinderfahrrad \r\n 1 * E4 Hinterradgruppe \r\n 1 * E7 Vorderradgruppe"),
            new purchasePartTooltip(53, "Speiche", "Kinderfahrrad \r\n 36 * E4 Hinterradgruppe \r\n 36 * E7 Vorderradgruppe"),
            new purchasePartTooltip(57, "Felge cpl.", "Damenfahrrad \r\n 1 * E5 Hinterradgruppe \r\n 1 * E8 Vorderradgruppe"),
            new purchasePartTooltip(58, "Speiche", "Damenfahrrad \r\n 36 * E5 Hinterradgruppe \r\n 36 * E8 Vorderradgruppe"),
            new purchasePartTooltip(59, "Schweißdraht", "Kinderfahrrad \r\n 2 * E18 Rahmen \r\n \r\n Damenfahrrad \r\n 2 * E19 Rahmen \r\n \r\n" +
                                                        "Herrenfahrrad \r\n 2 * E20 Rahmen"),

        };

        public static List<purchasePartTooltip> GetPurchasePartsTooltip()
        {
            return purchasePartsTooltip;
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

        // Bedarfsklasse für P0
        public class DemandP0
        {
            public int idDemandP0;
            public int demandInP0Only;

            public DemandP0(int idDemandP0, int demandInP0Only)
            {
                this.idDemandP0 = idDemandP0;
                this.demandInP0Only = demandInP0Only;
            }
        }

        // Hole Kaufteilliste aus StorageService
        static List<WarehouseStock> purchasePartsFromXML = StorageService.Instance.GetPurchaseParts();
        static List<purchasePart> purchasePartsFromPurchase = GetPurchasePartsFromPurchase();


        // Generiere Bedarfsliste für Periode 0
        public static List<DemandP0> purchasePartsInP0 = new List<DemandP0>()
        {
                new DemandP0(21, ProductionPlan.k21),
                new DemandP0(22, ProductionPlan.k22),
                new DemandP0(23, ProductionPlan.k23),
                new DemandP0(24, ProductionPlan.k24),
                new DemandP0(25, ProductionPlan.k25),
                new DemandP0(27, ProductionPlan.k27),
                new DemandP0(28, ProductionPlan.k28),
                new DemandP0(32, ProductionPlan.k32),
                new DemandP0(33, ProductionPlan.k33),
                new DemandP0(34, ProductionPlan.k34),
                new DemandP0(35, ProductionPlan.k35),
                new DemandP0(36, ProductionPlan.k36),
                new DemandP0(37, ProductionPlan.k37),
                new DemandP0(38, ProductionPlan.k38),
                new DemandP0(39, ProductionPlan.k39),
                new DemandP0(40, ProductionPlan.k40),
                new DemandP0(41, ProductionPlan.k41),
                new DemandP0(42, ProductionPlan.k42),
                new DemandP0(43, ProductionPlan.k43),
                new DemandP0(44, ProductionPlan.k44),
                new DemandP0(45, ProductionPlan.k45),
                new DemandP0(46, ProductionPlan.k46),
                new DemandP0(47, ProductionPlan.k47),
                new DemandP0(48, ProductionPlan.k48),
                new DemandP0(52, ProductionPlan.k52),
                new DemandP0(53, ProductionPlan.k53),
                new DemandP0(57, ProductionPlan.k57),
                new DemandP0(58, ProductionPlan.k58),
                new DemandP0(59, ProductionPlan.k59)
        };

        public static List<DemandP0> GetPurchasePartsInP0()
        {
            return purchasePartsInP0;
        }

        // Hole Kaufteil anhand seiner ID
        public static DemandP0 GetGetPurchasePartsInP0ByID(int id)
        {
            return GetPurchasePartsInP0().Find(x => x.idDemandP0 == id);
        }

        // Hole Prognosen aus StorageService
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


        // Bedarf für jedes Kaufteil berechnen und zurückgeben       
        public static List<Demand> GetDemandOfParts()
        {
            List<Demand> demandOfParts = new List<Demand>();

            foreach (purchasePart pb in purchasePartsFromPurchase)
            {
                int calculatedDemandP0 = GetGetPurchasePartsInP0ByID(pb.id).demandInP0Only;

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

        // Reichweite berechnen
        public static void calculateCoverage()
        { 
            double startAmountP0 = 0.0;
            double startAmountP1 = 0.0;
            double startAmountP2 = 0.0;
            double startAmountP3 = 0.0;
            int coverageInP0 = 0;
            int coverageInP1 = 0;
            int coverageInP2 = 0;
            int coverageInP3 = 0;
            int coverageSum = 0;
            int checkForDelay = 0;
            double coverageSumAsDouble = 0.0;
            int deliveryTimeInclDepartureTime = 0;
            int deliveryTimePriority = 0;
            int currentPeriod = StorageService.Instance.GetPeriodFromXml() + 1;
            double demandP0 = 0.0;
            double demandP0PerDay = 0.0;
            double demandP1 = 0.0;
            double demandP1PerDay = 0.0;
            double demandP2 = 0.0;
            double demandP2PerDay = 0.0;
            double demandP3 = 0.0;
            double demandP3PerDay = 0.0;

            // Hole Bedarf jedes Kaufteils für jedes Fahrrad und lege es in Liste ab
            List<Demand> demandOfParts = GetDemandOfParts();

            // Hole eingehende Bestellungen aus StorageService
            List<FutureInwardStockMovment> futureInwardStockMovments = StorageService.Instance.GetFutureInwardStockMovment();

            foreach (WarehouseStock wh in purchasePartsFromXML)
            {
                // Alle Werte auf 0 setzen, nach jedem Schleifendurchlauf
                startAmountP0 = 0.0;
                startAmountP1 = 0.0;
                startAmountP2 = 0.0;
                startAmountP3 = 0.0;
                coverageInP0 = 0;
                coverageInP1 = 0;
                coverageInP2 = 0;
                coverageInP3 = 0;
                coverageSum = 0;
                checkForDelay = 0;
                coverageSumAsDouble = 0.0;
                deliveryTimeInclDepartureTime = 0;
                deliveryTimePriority = 0;
                List<FutureInwardStockMovment> incomingOrders;

                // Setze Lieferzeit mit Abweichung und Eillieferzeit für den Artikel
                deliveryTimeInclDepartureTime = GetPurchasePartFromPurchaseByID(wh.Id).deliveryTime + GetPurchasePartFromPurchaseByID(wh.Id).departureTime;
                deliveryTimePriority = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(GetPurchasePartFromPurchaseByID(wh.Id).deliveryTime) / 2.0));

                // Extrahiere alle Bestellungen des Artikels
                incomingOrders = futureInwardStockMovments.FindAll(item => item.Article.Equals(wh.Id));

                // Lege Bedarf des Kaufteils in Variablen ab
                void calculateDemand()
                {
                    Demand demandOfPart = demandOfParts.Find(x => x.idDemand == wh.Id);
                    demandP0 = demandOfPart.demandInP0;
                    demandP0PerDay = demandOfPart.demandInP0 / 5.0;
                    demandP1 = demandOfPart.demandInP1;
                    demandP1PerDay = demandOfPart.demandInP1 / 5.0;
                    demandP2 = demandOfPart.demandInP2;
                    demandP2PerDay = demandOfPart.demandInP2 / 5.0;
                    demandP3 = demandOfPart.demandInP3;
                    demandP3PerDay = demandOfPart.demandInP3 / 5.0;
                }

                calculateDemand();

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

                    if (incomingOrderDay >= 0 && incomingOrderDay < 5)
                    {
                        startAmountP0 = startAmountP0 + incomingOrderAmount;
                    }

                    if (incomingOrderDay >= 5 && incomingOrderDay < 10)
                    {
                        startAmountP1 = startAmountP1 + incomingOrderAmount;
                    }

                    if (incomingOrderDay >= 10 && incomingOrderDay < 15)
                    {
                        startAmountP2 = startAmountP2 + incomingOrderAmount;
                    }

                    if (incomingOrderDay >= 15 && incomingOrderDay < 20)
                    {
                        startAmountP3 = startAmountP3 + incomingOrderAmount;
                    }
                }

                // Reichweitenberechnung für den Artikel
                // Periode 0
                startAmountP0 = startAmountP0 + Convert.ToDouble(wh.Amount);

                if (demandP0 > 0)
                {
                    // nicht aufgerundet
                    double test0 = startAmountP0 / demandP0PerDay;
                    // aufgerundet
                    coverageInP0 = Convert.ToInt32(Math.Floor(startAmountP0 / demandP0PerDay));
                    if (test0 > 5.0 && test0 < 6.0)
                    {
                        coverageInP0 = coverageInP0 + 1;
                    }
                    coverageSum = coverageInP0;
                    coverageSumAsDouble = test0;
                }                

                // Periode 1
                if (coverageInP0 > 5 || demandP0 == 0)
                {
                    startAmountP1 = startAmountP1 + startAmountP0 - demandP0;
                    // nicht aufgerundet
                    double test1 = startAmountP1 / demandP1PerDay;
                    // aufgerundet
                    coverageInP1 = Convert.ToInt32(Math.Floor(startAmountP1 / demandP1PerDay));
                    if (test1 > 5.0 && test1 < 6.0)
                    {
                        coverageInP1 = coverageInP1 + 1;
                    }
                    coverageSum = 5 + coverageInP1;
                    coverageSumAsDouble = 5 + test1;
                    // Periode 2
                    if (coverageInP1 > 5)
                    {
                        startAmountP2 = startAmountP2 + startAmountP1 - demandP1;
                        // nicht aufgerundet
                        double test2 = startAmountP2 / demandP2PerDay;
                        // aufgerundet
                        coverageInP2 = Convert.ToInt32(Math.Floor(startAmountP2 / demandP2PerDay));
                        if (test2 > 5.0 && test2 < 6.0)
                        {
                            coverageInP2 = coverageInP2 + 1;
                        }
                        coverageSum = 10 + coverageInP2;
                        coverageSumAsDouble = 10 + test2;
                        checkForDelay = 10;
                        // Periode 3
                        if (coverageInP2 > 5)
                        {
                            startAmountP3 = startAmountP3 + startAmountP2 - demandP2;
                            // nicht aufgerundet
                            double test3 = startAmountP3 / demandP3PerDay;
                            // aufgerundet
                            coverageInP3 = Convert.ToInt32(Math.Floor(startAmountP3 / demandP3PerDay));

                            coverageSum = 15 + coverageInP3;
                            coverageSumAsDouble = 15 + test3;
                            checkForDelay = 15;
                        }
                    }
                }

                // Anhand Reichweite Bestellungen bestimmen
                if ((coverageSum < 20) && ((coverageSum - deliveryTimeInclDepartureTime) >= 0))
                {
                    if ((checkForDelay - deliveryTimeInclDepartureTime) >= 5)
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
                        double daysOfPeriodLeftAsDouble = 20 - coverageSumAsDouble;
                        double orderAmount = 0.0;
                        //double amountDifference = 0.0;

                        // Periode 3
                        if (daysOfPeriodLeft >= 0 && daysOfPeriodLeft <= 5)
                        {
                            orderAmount = demandP3PerDay * daysOfPeriodLeftAsDouble;

                            //daysOfPeriodGone = daysOfPeriodGone - 15;
                            //amountDifference = startAmountP3 - demandP3PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 2
                        if (daysOfPeriodLeft > 5 && daysOfPeriodLeft <= 10)
                        {
                            daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 5;
                            orderAmount = demandP2PerDay * daysOfPeriodLeftAsDouble + demandP3;

                            //daysOfPeriodGone = daysOfPeriodGone - 10;
                            //amountDifference = startAmountP2 - demandP2PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 1
                        if (daysOfPeriodLeft > 10 && daysOfPeriodLeft <= 15)
                        {
                            daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 10;
                            orderAmount = demandP1PerDay * daysOfPeriodLeftAsDouble + demandP2 + demandP3;

                            //daysOfPeriodGone = daysOfPeriodGone - 5;
                            //amountDifference = startAmountP1 - demandP1PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 0
                        if (daysOfPeriodLeft > 15 && daysOfPeriodLeft <= 20)
                        {
                            daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 15;
                            orderAmount = demandP0PerDay * daysOfPeriodLeftAsDouble + demandP1 + demandP2 + demandP3;

                            //amountDifference = startAmountP0 - demandP0PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        int convertedOrderAmount = Convert.ToInt32(orderAmount);
                        // Füge Artikel der Bestellliste hinzu
                        OrderList orderListItem = new OrderList(convertedOrderAmount, wh.Id, orderType);
                        StorageService.Instance.AddOrderItem(orderListItem);
                    }

                }

                if ((coverageSum < 20) && ((coverageSum - deliveryTimeInclDepartureTime) < 0))
                {
                    if ((checkForDelay - deliveryTimePriority) >= 5)
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
                        double daysOfPeriodLeftAsDouble = 20 - coverageSumAsDouble;
                        double orderAmount = 0.0;
                        //double amountDifference = 0.0;

                        // Periode 3
                        if (daysOfPeriodLeft >= 0 && daysOfPeriodLeft <= 5)
                        {
                            orderAmount = demandP3PerDay * daysOfPeriodLeftAsDouble;

                            //daysOfPeriodGone = daysOfPeriodGone - 15;
                            //amountDifference = startAmountP3 - demandP3PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 2
                        if (daysOfPeriodLeft > 5 && daysOfPeriodLeft <= 10)
                        {
                            daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 5;
                            orderAmount = demandP2PerDay * daysOfPeriodLeftAsDouble + demandP3;

                            //daysOfPeriodGone = daysOfPeriodGone - 10;
                            //amountDifference = startAmountP2 - demandP2PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 1
                        if (daysOfPeriodLeft > 10 && daysOfPeriodLeft <= 15)
                        {
                            daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 10;
                            orderAmount = demandP1PerDay * daysOfPeriodLeftAsDouble + demandP2 + demandP3;

                            //daysOfPeriodGone = daysOfPeriodGone - 5;
                            //amountDifference = startAmountP1 - demandP1PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        // Periode 0
                        if (daysOfPeriodLeft > 15 && daysOfPeriodLeft <= 20)
                        {
                            daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 15;
                            orderAmount = demandP0PerDay * daysOfPeriodLeftAsDouble + demandP1 + demandP2 + demandP3;

                            //amountDifference = startAmountP0 - demandP0PerDay * daysOfPeriodGone;
                            //orderAmount = orderAmount - amountDifference;
                        }

                        int convertedOrderAmount = Convert.ToInt32(orderAmount);
                        // Füge Artikel der Bestellliste hinzu
                        OrderList orderListItem = new OrderList(convertedOrderAmount, wh.Id, orderType);
                        StorageService.Instance.AddOrderItem(orderListItem);

                        //if ((coverageSum - deliveryTimePriority) < 0)
                        //{
                        //    // Eilbestellung
                        //    // Frontend aktualisieren: Menge und Eil und 
                        //    // Hinweis: Auch Eilbestellung kommt nicht rechtzeitig!
                        //    // Eilbestellung der Bestellliste hinzufügen

                        //    // Typ 4 bedeutet Eilbestellung
                        //    orderType = 4;
                        //    daysOfPeriodGone = coverageSum;
                        //    daysOfPeriodLeft = 20 - coverageSum;
                        //    daysOfPeriodLeftAsDouble = 20 - coverageSumAsDouble;
                        //    orderAmount = 0.0;
                        //    //double amountDifference = 0.0;

                        //    // Periode 3
                        //    if (daysOfPeriodLeft >= 0 && daysOfPeriodLeft <= 5)
                        //    {
                        //        orderAmount = demandP3PerDay * daysOfPeriodLeftAsDouble;

                        //        //daysOfPeriodGone = daysOfPeriodGone - 15;
                        //        //amountDifference = startAmountP3 - demandP3PerDay * daysOfPeriodGone;
                        //        //orderAmount = orderAmount - amountDifference;
                        //    }

                        //    // Periode 2
                        //    if (daysOfPeriodLeft > 5 && daysOfPeriodLeft <= 10)
                        //    {
                        //        daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 5;
                        //        orderAmount = demandP2PerDay * daysOfPeriodLeftAsDouble + demandP3;

                        //        //daysOfPeriodGone = daysOfPeriodGone - 10;
                        //        //amountDifference = startAmountP2 - demandP2PerDay * daysOfPeriodGone;
                        //        //orderAmount = orderAmount - amountDifference;
                        //    }

                        //    // Periode 1
                        //    if (daysOfPeriodLeft > 10 && daysOfPeriodLeft <= 15)
                        //    {
                        //        daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 10;
                        //        orderAmount = demandP1PerDay * daysOfPeriodLeftAsDouble + demandP2 + demandP3;

                        //        //daysOfPeriodGone = daysOfPeriodGone - 5;
                        //        //amountDifference = startAmountP1 - demandP1PerDay * daysOfPeriodGone;
                        //        //orderAmount = orderAmount - amountDifference;
                        //    }

                        //    // Periode 0
                        //    if (daysOfPeriodLeft > 15 && daysOfPeriodLeft <= 20)
                        //    {
                        //        daysOfPeriodLeftAsDouble = daysOfPeriodLeftAsDouble - 15;
                        //        orderAmount = demandP0PerDay * daysOfPeriodLeftAsDouble + demandP1 + demandP2 + demandP3;

                        //        //amountDifference = startAmountP0 - demandP0PerDay * daysOfPeriodGone;
                        //        //orderAmount = orderAmount - amountDifference;
                        //    }

                        //    convertedOrderAmount = Convert.ToInt32(orderAmount);
                        //    // Füge Artikel der Bestellliste hinzu
                        //    orderListItem = new OrderList(convertedOrderAmount, wh.Id, orderType);
                        //    StorageService.Instance.AddOrderItem(orderListItem);
                        //}
                    }
                }

            }

        }

    }
}
