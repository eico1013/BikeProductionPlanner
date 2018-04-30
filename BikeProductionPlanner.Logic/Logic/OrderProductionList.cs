using System;
using System.Collections.Generic;
using System.Linq;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Logic.Logic
{
    public class OrderProductionList
    {
        private int Index { get; set; }
        private List<ProductionListCalculateOrder> pLSorted { get; set; }  //<article, index>

        public OrderProductionList()
        {
            if (StorageService.Instance.GetAllProductionItems() == null || StorageService.Instance.GetAllProductionItems().Count == 0)
            {
                throw new Exception("ProductionList has no values");
            }

            Index = 0;
            pLSorted = new List<ProductionListCalculateOrder>();

            foreach (var item in StorageService.Instance.GetAllProductionItems())
            {
                if (!checkPLSortedListForArticle(item.Article))
                {
                    calculateOrder(item, 2);
                }
            }

            this.pLSorted = this.pLSorted.OrderBy(list => list.StationGroup)
                                .ThenBy(list => list.Prefers)
                                .ThenBy(list => list.Index).ToList();

            StorageService.Instance.GetAllProductionItems().Clear();
            foreach (var item in this.pLSorted)
            {
                StorageService.Instance.AddProductionItem(item);
            }

            StorageService.Instance.ProductionListSorted = true;
        }

        private void addItem(ProductionList item, int prefers)
        {
            this.pLSorted.Add(new ProductionListCalculateOrder(item.Quantity, item.Article, this.Index, getStationGroupByArticle(item.Article), prefers));
            this.Index++;
        }

        private Boolean checkPLSortedListForArticle(int article)
        {
            Boolean check = false;
            foreach (var item in StorageService.Instance.GetAllProductionItems())
            {
                if (item.Article == article)
                {
                    check = true;
                }

            }

            if (!check)
            {
                return true;
            }

            foreach (var item in this.pLSorted)
            {
                if (item.Article == article)
                {
                    return true;
                }
            }
            return false;
        }

        private int getStationGroupByArticle(int article)
        {
            switch (article)
            {
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return 1;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 26:
                    return 2;
                case 49:
                case 54:
                case 29:
                    return 3;
                case 50:
                case 55:
                case 30:
                    return 4;
                case 51:
                case 56:
                case 31:
                    return 5;
                case 1:
                case 2:
                case 3:
                    return 6;

            }
            return 0;
        }

        private void calculateOrder(ProductionList item, int prefers)
        {
            Boolean check = false;
            switch (item.Article)
            {
                case 7:
                case 13:
                case 18:
                case 4:
                case 10:
                case 16:
                case 17:
                case 26:
                case 8:
                case 14:
                case 19:
                case 5:
                case 11:
                case 9:
                case 15:
                case 20:
                case 6:
                case 12:
                    addItem(item, prefers);
                    break;
                case 49:
                    if (!checkPLSortedListForArticle(7) && StorageService.Instance.GetAmountFromWareHouseStockId(7) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(7), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(13) && StorageService.Instance.GetAmountFromWareHouseStockId(13) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(13), 1);
                        check = true;

                    }
                    if (!checkPLSortedListForArticle(18) && StorageService.Instance.GetAmountFromWareHouseStockId(18) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(18), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 50:
                    if (!checkPLSortedListForArticle(4) && StorageService.Instance.GetAmountFromWareHouseStockId(4) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(4), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(10) && StorageService.Instance.GetAmountFromWareHouseStockId(10) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(10), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(49) && StorageService.Instance.GetAmountFromWareHouseStockId(49) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(49), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 51:
                    if (!checkPLSortedListForArticle(16) && StorageService.Instance.GetAmountFromWareHouseStockId(16) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(16), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(17) && StorageService.Instance.GetAmountFromWareHouseStockId(17) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(17), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(50) && StorageService.Instance.GetAmountFromWareHouseStockId(50) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(50), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 1:
                    if (!checkPLSortedListForArticle(26) && StorageService.Instance.GetAmountFromWareHouseStockId(26) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(26), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(51) && StorageService.Instance.GetAmountFromWareHouseStockId(51) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(51), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 54:
                    if (!checkPLSortedListForArticle(8) && StorageService.Instance.GetAmountFromWareHouseStockId(8) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(8), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(14) && StorageService.Instance.GetAmountFromWareHouseStockId(14) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(14), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(19) && StorageService.Instance.GetAmountFromWareHouseStockId(19) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(19), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 55:
                    if (!checkPLSortedListForArticle(5) && StorageService.Instance.GetAmountFromWareHouseStockId(5) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(5), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(11) && StorageService.Instance.GetAmountFromWareHouseStockId(11) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(11), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(54) && StorageService.Instance.GetAmountFromWareHouseStockId(54) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(54), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 56:
                    if (!checkPLSortedListForArticle(16) && StorageService.Instance.GetAmountFromWareHouseStockId(16) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(16), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(17) && StorageService.Instance.GetAmountFromWareHouseStockId(17) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(17), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(55) && StorageService.Instance.GetAmountFromWareHouseStockId(55) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(55), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 2:
                    if (!checkPLSortedListForArticle(26) && StorageService.Instance.GetAmountFromWareHouseStockId(26) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(26), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(56) && StorageService.Instance.GetAmountFromWareHouseStockId(56) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(56), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 29:
                    if (!checkPLSortedListForArticle(9) && StorageService.Instance.GetAmountFromWareHouseStockId(9) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(9), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(15) && StorageService.Instance.GetAmountFromWareHouseStockId(15) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(15), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(20) && StorageService.Instance.GetAmountFromWareHouseStockId(20) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(20), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 30:
                    if (!checkPLSortedListForArticle(6) && StorageService.Instance.GetAmountFromWareHouseStockId(6) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(6), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(12) && StorageService.Instance.GetAmountFromWareHouseStockId(12) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(12), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(29) && StorageService.Instance.GetAmountFromWareHouseStockId(29) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(29), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 31:
                    if (!checkPLSortedListForArticle(16) && StorageService.Instance.GetAmountFromWareHouseStockId(16) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(16), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(17) && StorageService.Instance.GetAmountFromWareHouseStockId(17) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(17), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(30) && StorageService.Instance.GetAmountFromWareHouseStockId(30) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(30), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
                case 3:
                    if (!checkPLSortedListForArticle(26) && StorageService.Instance.GetAmountFromWareHouseStockId(26) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(26), 1);
                        check = true;
                    }
                    if (!checkPLSortedListForArticle(31) && StorageService.Instance.GetAmountFromWareHouseStockId(31) < item.Quantity * 1)
                    {
                        calculateOrder(StorageService.Instance.GetProductionItem(31), 1);
                        check = true;
                    }
                    if (check && prefers != 1)
                    {
                        addItem(item, 3);
                    }
                    else
                    {
                        addItem(item, prefers);
                    }
                    break;
            }
        }
    }
}
