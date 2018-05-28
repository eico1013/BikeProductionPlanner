using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Logic
{
    public sealed class XmlInputParser
    {
        public List<WarehouseStock> WarehouseStocks { get; private set; }
        public List<FutureInwardStockMovment> FutureInwardStockMovments { get; private set; }
        public List<WaitingListWorkstation> WaitingListWorkstations { get; private set; }
        public List<WaitingListStock> WaitingListStocks { get; private set; }
        public List<OrderInWork> OrdersInWork { get; private set; }
        public int PeriodFromXML { get; private set; }

        private static readonly XmlInputParser instance = new XmlInputParser();
        private static readonly String WAREHOUSE_STOCK = "warehousestock";
        private static readonly String FUTURE_INWARD_STOCKMOVEMENT = "futureinwardstockmovement";

        private static readonly String WAITINGLIST_WORKSATION = "waitinglistworkstations";
        private static readonly String WAITINGLIST_STOCK = "waitingliststock";
        private static readonly String ORDER_IN_WORK = "ordersinwork";

        private static readonly String RESULTS = "results";

        private XmlInputParser()
        {
            WarehouseStocks = new List<WarehouseStock>();
            FutureInwardStockMovments = new List<FutureInwardStockMovment>();
            WaitingListWorkstations = new List<WaitingListWorkstation>();
            WaitingListStocks = new List<WaitingListStock>();
            OrdersInWork = new List<OrderInWork>();
            PeriodFromXML = 0;
        }

        public static XmlInputParser Instance
        {
            get
            {
                return instance;
            }
        }

        //public int getAmountFromWareHouseStockId(int Id)
        //{
        //    foreach (var item in WarehouseStocks)
        //    {
        //        if (item.Id == Id)
        //        {
        //            return item.Amount;
        //        }
        //    }
        //    return 0;
        //}

        private void clearLists()
        {
            WarehouseStocks.Clear();
            FutureInwardStockMovments.Clear();
            WaitingListWorkstations.Clear();
            WaitingListStocks.Clear();
            OrdersInWork.Clear();
            PeriodFromXML = 0;
        }

        public bool ParseXml(String XmlFile)
        {
            clearLists();

            if (XmlFile == null || !File.Exists(XmlFile) || !Path.GetExtension(XmlFile).ToUpper().Equals(".XML"))
            {

                return false;
            }

            String tag = "";
            XmlTextReader reader = new XmlTextReader(XmlFile);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element &&
                    (reader.Name).Equals(RESULTS))
                {
                    reader = getPeriodFromXML(reader);
                }

                if (reader.NodeType == XmlNodeType.Element &&
                    ((reader.Name).Equals(WAREHOUSE_STOCK)
                        || (reader.Name).Equals(FUTURE_INWARD_STOCKMOVEMENT)
                        || (reader.Name).Equals(WAITINGLIST_WORKSATION)
                        || (reader.Name).Equals(WAITINGLIST_STOCK)
                        || (reader.Name).Equals(ORDER_IN_WORK)))
                {
                    tag = reader.Name;
                }
                else if (reader.NodeType == XmlNodeType.Element && (reader.Name).Equals("article") && tag == WAREHOUSE_STOCK)
                {
                    reader = getWarehouseStockValue(reader);
                }
                else if (reader.NodeType == XmlNodeType.Element && (reader.Name).Equals("order") && tag == FUTURE_INWARD_STOCKMOVEMENT)
                {
                    reader = getFutureInwardStockMovment(reader);
                }
                else if (reader.NodeType == XmlNodeType.Element && (reader.Name).Equals("workplace") && tag == WAITINGLIST_WORKSATION)
                {
                    reader = getWaitinglistworkstation(reader);
                }
                else if (reader.NodeType == XmlNodeType.Element && (reader.Name).Equals("waitinglist") && tag == WAITINGLIST_WORKSATION)
                {
                    reader = addWaitingListToWaitinglistWorkstation(reader);
                }
                else if (reader.NodeType == XmlNodeType.Element && (reader.Name).Equals("missingpart") && tag == WAITINGLIST_STOCK)
                {
                    reader = getWaitingListStock(reader);
                }
                else if (reader.NodeType == XmlNodeType.Element && (reader.Name).Equals("waitinglist") && tag == WAITINGLIST_STOCK)
                {
                    reader = addWaitingListToWaitingListStock(reader);
                }
                else if (reader.NodeType == XmlNodeType.Element && (reader.Name).Equals("workplace") && tag == ORDER_IN_WORK)
                {
                    reader = getOrderInWork(reader);
                }
            } 
            return true;
        }

        private XmlTextReader getPeriodFromXML(XmlTextReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "period":
                        PeriodFromXML = Int32.Parse(reader.Value);
                        break;
                }
            }
            return reader;
        }

        private XmlTextReader getWarehouseStockValue(XmlTextReader reader)
        {
            WarehouseStock newWarehousestock = new WarehouseStock();
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "id":
                        newWarehousestock.Id = Int32.Parse(reader.Value);
                        break;
                    case "amount":
                        newWarehousestock.Amount = Int32.Parse(reader.Value);
                        break;
                    case "price":
                        newWarehousestock.Price = Double.Parse(reader.Value.Replace(".", ","));
                        break;
                    case "stockvalue":
                        newWarehousestock.StockValue = Double.Parse(reader.Value.Replace(".", ","));
                        break;
                    case "startamount":
                        newWarehousestock.StartAmount = Int32.Parse(reader.Value);
                        break;
                    case "pct":
                        newWarehousestock.PCT = Double.Parse(reader.Value.Replace(".", ","));
                        break;
                }
            }

            this.WarehouseStocks.Add(newWarehousestock);
            return reader;
        }

        private XmlTextReader getFutureInwardStockMovment(XmlTextReader reader)
        {
            FutureInwardStockMovment newFutureInwardStockMovment = new FutureInwardStockMovment();
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "orderperiod":
                        newFutureInwardStockMovment.OrderPeriod = Int32.Parse(reader.Value);
                        break;
                    case "id":
                        newFutureInwardStockMovment.Id = Int32.Parse(reader.Value);
                        break;
                    case "mode":
                        newFutureInwardStockMovment.Mode = Int32.Parse(reader.Value);
                        break;
                    case "article":
                        newFutureInwardStockMovment.Article = Int32.Parse(reader.Value);
                        break;
                    case "amount":
                        newFutureInwardStockMovment.Amount = Int32.Parse(reader.Value);
                        break;

                }
            }

            this.FutureInwardStockMovments.Add(newFutureInwardStockMovment);
            return reader;
        }

        private XmlTextReader getWaitinglistworkstation(XmlTextReader reader)
        {
            WaitingListWorkstation newWaitingListWorksation = new WaitingListWorkstation();
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "id":
                        newWaitingListWorksation.Id = Int32.Parse(reader.Value);
                        break;
                    case "amount":
                        newWaitingListWorksation.TimeNeed = Int32.Parse(reader.Value);
                        break;
                }
            }

            this.WaitingListWorkstations.Add(newWaitingListWorksation);
            return reader;
        }

        private XmlTextReader addWaitingListToWaitinglistWorkstation(XmlTextReader reader)
        {
            WaitingList newWaitingList = new WaitingList();
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "order":
                        newWaitingList.Order = Int32.Parse(reader.Value);
                        break;
                    case "item":
                        newWaitingList.Item = Int32.Parse(reader.Value);
                        break;
                    case "amount":
                        newWaitingList.Amount = Int32.Parse(reader.Value);
                        break;
                    case "timeneed":
                        newWaitingList.TimeNeed = Int32.Parse(reader.Value);
                        break;
                }
            }

            this.WaitingListWorkstations[WaitingListWorkstations.Count - 1].WaitingList.Add(newWaitingList);
            return reader;
        }

        private XmlTextReader getWaitingListStock(XmlTextReader reader)
        {
            WaitingListStock newWaitingListStock = new WaitingListStock();
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "id":
                        newWaitingListStock.Id = Int32.Parse(reader.Value);
                        break;
                }
            }

            this.WaitingListStocks.Add(newWaitingListStock);
            return reader;
        }

        private XmlTextReader addWaitingListToWaitingListStock(XmlTextReader reader)
        {
            WaitingList newWaitingList = new WaitingList();
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "order":
                        newWaitingList.Order = Int32.Parse(reader.Value);
                        break;
                    case "item":
                        newWaitingList.Item = Int32.Parse(reader.Value);
                        break;
                    case "amount":
                        newWaitingList.Amount = Int32.Parse(reader.Value);
                        break;
                }
            }

            this.WaitingListStocks[WaitingListStocks.Count - 1].WaitingList.Add(newWaitingList);
            return reader;
        }

        private XmlTextReader getOrderInWork(XmlTextReader reader)
        {
            OrderInWork newOrderInWork = new OrderInWork();
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "id":
                        newOrderInWork.Id = Int32.Parse(reader.Value);
                        break;
                    case "order":
                        newOrderInWork.Order = Int32.Parse(reader.Value);
                        break;
                    case "item":
                        newOrderInWork.Item = Int32.Parse(reader.Value);
                        break;
                    case "amount":
                        newOrderInWork.Amount = Int32.Parse(reader.Value);
                        break;
                    case "timeneed":
                        newOrderInWork.TimeNeed = Int32.Parse(reader.Value);
                        break;
                }
            }

            this.OrdersInWork.Add(newOrderInWork);
            return reader;
        }
    }
}
