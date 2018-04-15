using System;
using System.Collections.Generic;

namespace BikeProductionPlanner.Logic.Database.Model
{
    public class Workplace
    {
        public int Id;

        public List<WorkplaceTask> TaskList;

        public int KapaDemand;
        public double SetupTime;
        public int KapaDemandPrevious;
        public double SetupTimePrevious;
        public double TotalKapaDemand;
        public int Shifts;
        public double OvertimeMinutes;

        public int GetFieldsById(int Id)
        {
            switch (Id)
            {
                case 0: return this.KapaDemand;
                case 1: return Convert.ToInt32(this.SetupTime);
                case 2: return this.KapaDemandPrevious;
                case 3: return Convert.ToInt32(this.SetupTimePrevious);
                case 4: return Convert.ToInt32(TotalKapaDemand);
                case 5: return this.Shifts;
                case 6: return this.OvertimeInMinutesPerDay;
                default: return -1;
            }
        }

        public int OvertimeInMinutesPerDay
        {
            get { return Convert.ToInt32(Math.Ceiling(this.OvertimeMinutes / 50) * 10); }
        }

        public Workplace(int workplaceId, List<WorkplaceTask> taskList)
        {
            this.Id = workplaceId;
            this.TaskList = taskList;

            foreach (WorkplaceTask apa in this.TaskList)
            {
                this.KapaDemand += apa.kapaDemandPerUnit;
            }

            foreach (WorkplaceTask apa in this.TaskList)
            {
                this.SetupTime += apa.setupTime;
            }

            this.SetupTime = this.SetupTime * 1.5;

            var item = StorageService.Instance.GetWorkplaceById(workplaceId);

            if (item == null)
            {
                this.KapaDemandPrevious = 0;
            }
            else
            {
                this.KapaDemandPrevious = item.TimeNeed;
            }

            //this.ruestzeitrueckstand = 
            var WorkplaceWithId = StorageService.Instance.GetWorkplaceById(workplaceId);

            if (WorkplaceWithId != null && WorkplaceWithId.WaitingList != null)
            {
                foreach (WaitingList wl in StorageService.Instance.GetWorkplaceById(workplaceId).WaitingList)
                {
                    foreach (WorkplaceTask apa in this.TaskList)
                    {
                        if (wl.Item == apa.articleId) this.SetupTimePrevious += apa.setupTime;
                    }
                }
            }

            if (workplaceId == 7 || workplaceId == 8 || workplaceId == 9 || workplaceId == 15)
            {
                this.SetupTimePrevious = this.SetupTimePrevious * 3.0;
            }

            this.SetupTimePrevious = this.SetupTimePrevious * 1.5;

            this.TotalKapaDemand = this.KapaDemand + this.SetupTime + this.KapaDemandPrevious + this.SetupTimePrevious;

            double zeitBedarfProPeriode = this.TotalKapaDemand;

            if (zeitBedarfProPeriode <= 3600)
            {
                this.Shifts = 1;
                this.OvertimeMinutes = Math.Ceiling((zeitBedarfProPeriode - 2400) / 10) * 10;
            }
            else if (zeitBedarfProPeriode <= 6000)
            {
                this.Shifts = 2;
                this.OvertimeMinutes = Math.Ceiling((zeitBedarfProPeriode - 4800) / 10) * 10;

            }
            else if (zeitBedarfProPeriode <= 7200)
            {
                this.Shifts = 3;
                this.OvertimeMinutes = 0;
            }
            else
            {
                this.Shifts = 3;
                this.TotalKapaDemand = 7200;
                this.OvertimeMinutes = 0;
            }

            if (OvertimeMinutes < 0)
            {
                this.OvertimeMinutes = 0;
            }
        }
    }
}
