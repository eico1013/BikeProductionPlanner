using System;
using System.Collections.Generic;
using BikeProductionPlanner.Logic.Database.Model;

namespace BikeProductionPlanner.Logic.Database
{
    public class StorageService : IStorageService
    {
        private static StorageService instance;

        // Input
        private List<WarehouseStock> articleList;
        private List<WaitingListWorkstation> waitingListWorkstationList;
        private List<OrderInWork> ordersInWorkList;
        private List<WaitingListStock> waitingListStocks;
        private List<FutureInwardStockMovment> futureInwardStockMovments;

        // Temp
        private Dictionary<int, ForecastPeriod> forecastList;

        // Output
        private List<OrderList> orderList; // purchase
        private List<ProductionList> productionList;
        private List<WorkingItemList> workingItemList;
        private List<SellWish> sellWishList;
        private List<SellDirect> selldirectList;

        public Boolean ProductionListSorted { get; set; } = false;

        private StorageService()
        {
            articleList = XmlInputParser.Instance.WarehouseStocks;
            waitingListWorkstationList = XmlInputParser.Instance.WaitingListWorkstations;
            ordersInWorkList = XmlInputParser.Instance.OrdersInWork;
            waitingListStocks = XmlInputParser.Instance.WaitingListStocks;
            futureInwardStockMovments = XmlInputParser.Instance.FutureInwardStockMovments;

            forecastList = new Dictionary<int, ForecastPeriod>();

            orderList = new List<OrderList>();
            productionList = new List<ProductionList>();
            workingItemList = new List<WorkingItemList>();
            sellWishList = new List<SellWish>();
            selldirectList = new List<SellDirect>();
        }

        public static StorageService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StorageService();
                }

                return instance;
            }
        }

        #region FutureInwardStockMovment

        public FutureInwardStockMovment GetFutureInwardStockMovment(int id)
        {
            return futureInwardStockMovments.Find(x => x.Article == id);
        }

        #endregion

        #region WarehouseStock

        public double Totalstockvalue
        {
            get
            {
                double totalstockvalue = 0.0;
                foreach (WarehouseStock a in articleList)
                    totalstockvalue += a.StockValue;
                return totalstockvalue;
            }
        }

        public void AddArticle(WarehouseStock a)
        {
            if (a == null)
                throw new ArgumentNullException();
            articleList.RemoveAll(x => x.Id == a.Id);
            articleList.Add(a);
        }

        public WarehouseStock GetWarehouseArticleById(int Id)
        {
            return articleList.Find(x => x.Id == Id);
        }

        public List<WarehouseStock> GetWarehouseArticles()
        {
            return articleList;
        }

        public int GetAmountFromWareHouseStockId(int Id)
        {
            foreach (var item in articleList)
            {
                if (item.Id == Id)
                {
                    return item.Amount;
                }
            }

            return 0;
        }

        public List<WarehouseStock> GetWarehouseStock()
        {
            return articleList;
        }

        public bool CheckTotalstockvalue(double Totalstockvalue)
        {
            double test = 0.0;
            foreach (WarehouseStock a in articleList)
                test += a.StockValue;
            return Totalstockvalue == test;
        }

        #endregion

        public List<WaitingListStock> GetAllWaitingListStocks()
        {
            return waitingListStocks;
        }

        #region WaitingListWorkstation

        public void AddWorkplace(WaitingListWorkstation w)
        {
            if (w == null)
                throw new ArgumentNullException();
            waitingListWorkstationList.RemoveAll(x => x.Id == w.Id);
            waitingListWorkstationList.Add(w);
        }

        public List<WaitingListWorkstation> getAllWorkplaces()
        {
            return waitingListWorkstationList;
        }

        public WaitingListWorkstation GetWorkplaceById(int Id)
        {
            return waitingListWorkstationList.Find(x => x.Id == Id);
        }

        public int GetWorkplaceArticleAmountById(int Id)
        {
            int res = 0;

            foreach (WaitingListWorkstation wp in waitingListWorkstationList)
            {
                foreach (WaitingList wl in wp.WaitingList)
                {
                    if (wl.Item == Id) res += wl.Amount;
                }
            }

            return res;
        }

        #endregion

        #region OrdersInWork

        public void AddOrderInWork(OrderInWork w)
        {
            if (w == null)
                throw new ArgumentNullException();
            ordersInWorkList.RemoveAll(x => x.Id == w.Id);
            ordersInWorkList.Add(w);
        }

        public OrderInWork GetOrderInWorkById(int Id)
        {
            return ordersInWorkList.Find(x => x.Id == Id);
        }

        public int GetOrderInWorkArticleAmountById(int Id)
        {
            int res = 0;

            foreach (OrderInWork w in ordersInWorkList)
            {
                if (w.Item == Id) res += w.Amount;
            }

            return res;
        }

        public List<OrderInWork> getAllOrdersInWork()
        {
            return ordersInWorkList;
        }

        public List<OrderInWork> GetWorkplaceByOrder(int order)
        {
            return ordersInWorkList.FindAll(x => x.Order == order);
        }

        //public List<OrderInWork> GetWorkplaceByBatch(int batch)
        //{
        //    return ordersInWorkList.FindAll(x => x.Batch == batch);
        //}

        public List<OrderInWork> GetWorkplaceByitem(int item)
        {
            return ordersInWorkList.FindAll(x => x.Item == item);
        }

        #endregion

        #region Forecast

        public void AddForecast(int period, ForecastPeriod data)
        {
            if (period < 0 || data == null)
                throw new ArgumentException();
            if (forecastList.ContainsKey(period))
                forecastList.Remove(period);
            forecastList.Add(period, data);
            if (period == 0)
            {
                //Output.Sellwish.Class.AnzahlArtikel1 = forecastList[0].Product1;
                //Output.Sellwish.Class.AnzahlArtikel2 = forecastList[0].Product2;
                //Output.Sellwish.Class.AnzahlArtikel3 = forecastList[0].Product3;
            }
        }

        public ForecastPeriod GetForecastForPeriod(int period)
        {
            return forecastList[period];
        }

        #endregion

        #region Orders

        public void AddOrderItem(OrderList item)
        {
            if (item == null)
            {
                throw new Exception();
            }

            orderList.Add(item);
        }

        public List<OrderList> GetOrdersByArticle(int article)
        {
            return orderList.FindAll(x => x.Article == article);
        }

        public List<OrderList> GetAllOrders()
        {
            return orderList;
        }

        public void RemoveOrderItem(OrderList o)
        {
            if (o == null)
            {
                throw new ArgumentNullException();
            }

            orderList.RemoveAll(x => x == o);
        }

        #endregion

        #region Production

        public void AddProductionItem(ProductionList item)
        {
            if (item == null)
            {
                throw new Exception();
            }
            if (item.Quantity <= 0)
            {
                return;
            }

            productionList.Add(item);
        }

        public List<ProductionList> GetAllProductionItems()
        {
            return productionList;
        }

        public List<ProductionList> GetProductionQuantitysForArticle(int article)
        {
            return productionList.FindAll(x => x.Article == article);
        }

        public ProductionList GetProductionItem(int article)
        {
            foreach (var item in productionList)
            {
                if (item.Article == article)
                {
                    return item;
                }
            }

            throw new Exception("ProductionList has no article " + article);
        }

        public void MoveProductionItemToSpecialIndex(int newIndex, int oldIndex)
        {
            var item = new ProductionList(productionList[oldIndex].Article, productionList[oldIndex].Quantity);
            productionList[oldIndex] = null;
            productionList.Insert(newIndex, item);
            productionList.RemoveAll(x => x == null);
        }

        #endregion

        #region WorkingTimeItems

        public void AddWorkingTimeItem(WorkingItemList item)
        {
            if (item == null)
            {
                throw new Exception();
            }

            workingItemList.RemoveAll(x => x.Station == item.Station);
            workingItemList.Add(item);
        }

        public WorkingItemList GetWorkingTimeOrderForStation(int station)
        {
            return workingItemList.Find(x => x.Station == station);
        }

        public List<WorkingItemList> GetAllWorkingItems()
        {
            return workingItemList;
        }

        #endregion

        #region Sales

        public void AddSellWish(SellWish item)
        {
            sellWishList.Add(item);
        }

        public void AddSellDirect(SellDirect item)
        {
            selldirectList.Add(item);
        }

        public List<SellWish> GetAllSellWishes()
        {
            return sellWishList;
        }

        public List<SellDirect> GetAllSellDirect()
        {
            return selldirectList;
        }

        #endregion

        //Periode 0
        public int vertriebswunschP1;
        public int vertriebswunschP2;
        public int vertriebswunschP3;

        public int sicherheitsbestandP1;
        public int sicherheitsbestandP2;
        public int sicherheitsbestandP3;

        //Periode 1
        public int prognose1P1;
        public int prognose1P2;
        public int prognose1P3;

        public int sb_Prognose1P1;
        public int sb_Prognose1P2;
        public int sb_Prognose1P3;

        //Periode 2
        public int prognose2P1;
        public int prognose2P2;
        public int prognose2P3;

        public int sb_Prognose2P1;
        public int sb_Prognose2P2;
        public int sb_Prognose2P3;

        //Periode 3
        public int prognose3P1;
        public int prognose3P2;
        public int prognose3P3;

        public int sb_Prognose3P1;
        public int sb_Prognose3P2;
        public int sb_Prognose3P3;

        public int sicherheitsFaktor;
    }
}
