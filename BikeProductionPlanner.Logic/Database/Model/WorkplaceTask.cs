namespace BikeProductionPlanner.Logic.Database.Model
{
    public class WorkplaceTask
    {
        public int articleId;
        public int productionTime;
        public int setupTime;
        public int kapaDemandPerUnit;

        public WorkplaceTask(int articleId, int productionTime, int setupTime)
        {
            this.articleId = articleId;
            this.productionTime = productionTime;
            this.setupTime = setupTime;
            this.kapaDemandPerUnit = ProductionPlan.GetDemandById(articleId) * productionTime;
        }
    }
}
