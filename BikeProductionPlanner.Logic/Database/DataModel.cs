using System.Collections.Generic;
using BikeProductionPlanner.Logic.Database.Model;

namespace BikeProductionPlanner.Logic.Database
{
    public class SellWish
    {

        public int Quantity { get; set; }
        public int Article { get; set; }

        public SellWish(int quantity, int article)
        {
            this.Quantity = quantity;
            this.Article = article;
        }

    }

    public class SellDirect
    {
        public int Quantity { get; set; }
        public int Article { get; set; }
        public double Penalty { get; set; }
        public double Price { get; set; }

        public SellDirect(int quantity, int article, double penalty, double price)
        {
            this.Quantity = quantity;
            this.Article = article;
            this.Penalty = penalty;
            this.Price = price;
        }

        public SellDirect()
        {
        }
    }

    public class OrderList
    {
        public int Quantity { get; set; }
        public int Article { get; set; }
        public int Modus { get; set; }

        public PurchaseType Type { get; set; }

        public OrderList(int quantity, int article, int modus)
        {
            this.Quantity = quantity;
            this.Article = article;
            this.Modus = modus;

            if (modus == 4)
            {
                Type = PurchaseType.Eil;
            }
            else if (modus == 5)
            {
                Type = PurchaseType.Normal;
            }
        }

    }

    public class ProductionList
    {
        public int Quantity { get; set; }
        public int Article { get; set; }

        public ProductionList(int article, int quantity)
        {
            this.Quantity = quantity;
            this.Article = article;
        }

    }

    class ProductionListCalculateOrder : ProductionList
    {
        public int Index { get; set; }
        public int StationGroup { get; set; }
        public int Prefers { get; set; }


        public ProductionListCalculateOrder(int quantity, int article, int index, int stationGroup, int prefers) : base(article, quantity)
        {
            this.Index = index;
            this.StationGroup = stationGroup;
            this.Prefers = prefers;
        }

        public override int GetHashCode()
        {
            return this.StationGroup.GetHashCode() ^ this.Prefers.GetHashCode() ^ this.Index.GetHashCode();
        }
    }

    public class WorkingItemList
    {
        public int Shift { get; set; }
        public int Station { get; set; }
        public int WorkingOvertime { get; set; }

        public WorkingItemList(int shift, int station, int workingOvertime)
        {
            this.Shift = shift;
            this.Station = station;
            this.WorkingOvertime = workingOvertime;
        }
    }

    public class WarehouseStock
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double StockValue { get; set; }
        public double StockValue1 { get; set; }

        public int StartAmount { get; set; }

        public double PCT { get; set; }

        public WarehouseStock(int Id, int amount, double price, double articleStockValue, int startamount, double pct)
        {
            this.Id = Id;
            this.Amount = amount;
            this.Price = price;
            this.StockValue = articleStockValue;
            this.StockValue1 = articleStockValue;

            this.StartAmount = startamount;
            this.PCT = pct;
        }

        public WarehouseStock()
        {
        }

    }

    public class FutureInwardStockMovment
    {
        public int Id { get; set; }
        public int Article { get; set; }
        public int Amount { get; set; }
        public int Mode { get; set; }
        public int OrderPeriod { get; set; }

        public FutureInwardStockMovment(int Id, int article, int orderAmount, int mode, int orderPeriod)
        {
            this.Id = Id;
            this.Article = article;
            this.Amount = orderAmount;
            this.Mode = mode;
            this.OrderPeriod = orderPeriod;
        }

        public FutureInwardStockMovment()
        {
        }

    }

    public class WaitingListWorkstation
    {
        public int Id { get; set; }
        public int TimeNeed { get; set; }
        public List<WaitingList> WaitingList { get; set; }

        public WaitingListWorkstation(int Id, int timeNeed, List<WaitingList> waitingList)
        {
            this.Id = Id;
            this.TimeNeed = timeNeed;
            this.WaitingList = waitingList;
        }

        public WaitingListWorkstation()
        {
            WaitingList = new List<WaitingList>();
        }

    }

    public class WaitingList
    {
        public int Amount { get; set; }
        public int TimeNeed { get; set; }
        public int Item { get; set; }
        public int Order { get; set; }

        public WaitingList(int Id, int amount, int timeNeed, int item, int order)
        {
            this.Amount = amount;
            this.TimeNeed = timeNeed;
            this.Item = item;
            this.Order = order;
        }

        public WaitingList()
        {
        }

    }

    public class WaitingListStock
    {
        public int Id { get; set; }
        public List<WaitingList> WaitingList { get; set; }

        public WaitingListStock(int Id, List<WaitingList> waitingList)
        {
            this.Id = Id;
        }

        public WaitingListStock()
        {
            WaitingList = new List<WaitingList>();
        }

    }

    public class OrderInWork
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int TimeNeed { get; set; }
        public int Item { get; set; }
        public int Order { get; set; }

        public OrderInWork(int Id, int amount, int timeNeed, int item, int order)
        {
            this.Id = Id;
            this.Amount = amount;
            this.TimeNeed = timeNeed;
            this.Item = item;
            this.Order = order;
        }

        public OrderInWork()
        {
        }

    }
}
