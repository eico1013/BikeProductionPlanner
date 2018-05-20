using System;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Logic.Logic
{
    public class PlanCalculations
    {
        public static void Calculate()
        {
            createProductionList();
            createWorkingtimelist();
            createOrderList();
        }

        private static void createOrderList()
        {
            PurchasePlan pp = new PurchasePlan();
            pp.Calculate();

            foreach (BPBestellung bestellung in pp.PurchaseList)
            {
                StorageService.Instance.AddOrderItem(new OrderList(Convert.ToInt32(bestellung.menge), bestellung.artikelID, bestellung.isEilbestellung ? 4 : 5));
            }
        }

        private static void createProductionList()
        {
            ProductionPlan.Calculate();

            for (int i = 1; i < 21; i++)
            {
                StorageService.Instance.AddProductionItem(new ProductionList(i, ProductionPlan.GetDemandById(i)));
            }

            StorageService.Instance.AddProductionItem(new ProductionList(26, ProductionPlan.GetDemandById(26)));

            for (int i = 29; i < 32; i++)
            {
                StorageService.Instance.AddProductionItem(new ProductionList(i, ProductionPlan.GetDemandById(i)));
            }

            for (int i = 49; i < 52; i++)
            {
                StorageService.Instance.AddProductionItem(new ProductionList(i, ProductionPlan.GetDemandById(i)));
            }

            for (int i = 54; i < 57; i++)
            {
                StorageService.Instance.AddProductionItem(new ProductionList(i, ProductionPlan.GetDemandById(i)));
            }

        }

        private static void createWorkingtimelist()
        {
            OrderProductionList opl = new OrderProductionList();
            CapacityPlanning cp = new CapacityPlanning();
        }
    }
}
