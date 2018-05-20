using System;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Logic.Logic
{
    public class CapacityPlanning
    {
        // Reihenfolge: Station, Time Worksation, Time Waitinglist Workstaiton,
        //             Time Waitlinglist List Stock, Shift, WorkingOvertime
        private int[,] CapacityWorkplaces { get; set; }
        const int iS = 0;  // index Station
        const int iW = 1;  // index time worksation
        const int iWW = 2; // index time waitlinglist workstation
        const int iWS = 3; // index time waitlinglist stock
        const int iST = 4; // index shift
        const int iWO = 5; // index working overtime
		const int maxShiftTime = 2400;
        const int maxShifts = 3;

        public CapacityPlanning()
        {
            if (StorageService.Instance.GetAllProductionItems() == null || StorageService.Instance.GetAllProductionItems().Count == 0)
            {
                throw new Exception("ProductionList has no values");
            }
            if (!StorageService.Instance.ProductionListSorted)
            {
                throw new Exception("ProductionList is not sorted");
            }

            this.CapacityWorkplaces = new int[15, 6];
            initCapacityWorkplaces();

            calculateCapacityNeedsFormWorkplaces();
            calculateCapacityNeesdfromPreviousPeriodWaitlingListWorkstation();
            calculateCapacityNeesdfromPreviousPeriodWaitlingListStock();
            calculateShiftAndWordkingOvertime();

            //Werte in Output Parser setzen
            for (int i = 0; i < CapacityWorkplaces.GetLength(0); i++)
            {
                StorageService.Instance.AddWorkingTimeItem(new WorkingItemList(CapacityWorkplaces[i, iST], CapacityWorkplaces[i, iS], CapacityWorkplaces[i, iWO]));
            }

        }

        // Abreitsplatz Id setzen
        private void initCapacityWorkplaces()
        {
            for (int i = 0; i < this.CapacityWorkplaces.GetLength(0); i++)
            {
                this.CapacityWorkplaces[i, iS] = i + 1;
                for (int j = 1; j < this.CapacityWorkplaces.GetLength(1); j++)
                {
                    this.CapacityWorkplaces[i, j] = 0;
                }
            }
        }

        private void calculateShiftAndWordkingOvertime()
        {
            int sumCapacity = 0;
            for (int i = 0; i < this.CapacityWorkplaces.GetLength(0); i++)
            {
                sumCapacity = this.CapacityWorkplaces[i, iW] + this.CapacityWorkplaces[i, iWW]
                            + this.CapacityWorkplaces[i, iWS];
                this.CapacityWorkplaces[i, iWO] = (sumCapacity % maxShiftTime) / 5;
                this.CapacityWorkplaces[i, iST] = sumCapacity / maxShiftTime;

                if (this.CapacityWorkplaces[i, iWO] > 0 && this.CapacityWorkplaces[i, iST] == 0)
                {
                    this.CapacityWorkplaces[i, iST] = 1;
                    this.CapacityWorkplaces[i, iWO] = 0;
                }

                if (this.CapacityWorkplaces[i, iWO] > (maxShiftTime / 5))
                {
                    this.CapacityWorkplaces[i, iWO] = 0;
                    this.CapacityWorkplaces[i, iST] += 1;
                }

                if (this.CapacityWorkplaces[i, iST] >= (maxShifts))
                {
                    this.CapacityWorkplaces[i, iST] = 3;
                    this.CapacityWorkplaces[i, iWO] = 0;
                }
            }
        }


        private void calculateCapacityNeesdfromPreviousPeriodWaitlingListWorkstation()
        {
            foreach (var wW in StorageService.Instance.getAllWorkplaces())
            {
                foreach (var item in wW.WaitingList)
                {
                    switch (wW.Id)
                    {
                        case 1:
                            this.CapacityWorkplaces[1 - 1, iWW] += 6 * item.Amount;
                            this.CapacityWorkplaces[1 - 1, iWW] += 20;
                            break;
                        case 2:
                            this.CapacityWorkplaces[2 - 1, iWW] += 5 * item.Amount;
                            this.CapacityWorkplaces[2 - 1, iWW] += 30;
                            break;
                        case 3:
                            this.CapacityWorkplaces[3 - 1, iWW] += 6 * item.Amount;
                            this.CapacityWorkplaces[3 - 1, iWW] += 30;
                            break;
                        case 4:
                            this.CapacityWorkplaces[4 - 1, iWW] += 7 * item.Amount;
                            this.CapacityWorkplaces[4 - 1, iWW] += 30;
                             break;
                        case 5:
                            break;
                        case 6:
                            this.CapacityWorkplaces[6 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[6 - 1, iWW] += 15;

                            if (item.Item == 28)
                            {
                                this.CapacityWorkplaces[8 - 1, iWW] += 3 * item.Amount;
                                this.CapacityWorkplaces[8 - 1, iWW] += 25;

                                this.CapacityWorkplaces[7 - 1, iWW] += 2 * item.Amount;
                                this.CapacityWorkplaces[7 - 1, iWW] += 20;

                                this.CapacityWorkplaces[9 - 1, iWW] += 2 * item.Amount;
                                this.CapacityWorkplaces[9 - 1, iWW] += 20;
                                this.CapacityWorkplaces[14 - 1, iWW] += 3 * item.Amount;
                            }
                            break;
                        case 7:
                            this.CapacityWorkplaces[7 - 1, iWW] += 2 * item.Amount;
                            this.CapacityWorkplaces[7 - 1, iWW] += 30;
                            if (item.Item != 44 && item.Item != 48)
                            {
                                this.CapacityWorkplaces[9 - 1, iWW] += 3 * item.Amount;
                                this.CapacityWorkplaces[9 - 1, iWW] += 15;
                            }
                            else
                            {
                                this.CapacityWorkplaces[15 - 1, iWW] += 3 * item.Amount;
                                this.CapacityWorkplaces[15 - 1, iWW] += 15;
                            }
                            break;
                        case 8:
                            this.CapacityWorkplaces[8 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[8 - 1, iWW] += 25;

                            this.CapacityWorkplaces[7 - 1, iWW] += 2 * item.Amount;
                            this.CapacityWorkplaces[7 - 1, iWW] += 30;

                            this.CapacityWorkplaces[9 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[9 - 1, iWW] += 15;
                            break;
                        case 9:
                            this.CapacityWorkplaces[9 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[9 - 1, iWW] += 15;
                            break;
                        case 10:
                            this.CapacityWorkplaces[10 - 1, iWW] += 4 * item.Amount;
                            this.CapacityWorkplaces[10 - 1, iWW] += 20;

                            this.CapacityWorkplaces[11 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[11 - 1, iWW] += 20;
                        break;
                        case 11:
                            this.CapacityWorkplaces[11 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[11 - 1, iWW] += 20;
                            break;
                        case 12:
                            this.CapacityWorkplaces[12 - 1, iWW] += 3 * item.Amount;

                            this.CapacityWorkplaces[8 - 1, iWW] += 2 * item.Amount;
                            this.CapacityWorkplaces[8 - 1, iWW] += 15;

                            this.CapacityWorkplaces[7 - 1, iWW] += 2 * item.Amount;
                            this.CapacityWorkplaces[7 - 1, iWW] += 20;

                            this.CapacityWorkplaces[9 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[9 - 1, iWW] += 15;
                            break;
                        case 13:
                            this.CapacityWorkplaces[13 - 1, iWW] += 2 * item.Amount;

                            this.CapacityWorkplaces[12 - 1, iWW] += 3 * item.Amount;

                            this.CapacityWorkplaces[8 - 1, iWW] += 2 * item.Amount;
                            this.CapacityWorkplaces[8 - 1, iWW] += 15;

                            this.CapacityWorkplaces[7 - 1, iWW] += 2 * item.Amount;
                            this.CapacityWorkplaces[7 - 1, iWW] += 20;

                            this.CapacityWorkplaces[9 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[9 - 1, iWW] += 15;
                            break;
                        case 14:
                            this.CapacityWorkplaces[14 - 1, iWW] += 3 * item.Amount;
                            break;
                        case 15:
                            this.CapacityWorkplaces[15 - 1, iWW] += 3 * item.Amount;
                            this.CapacityWorkplaces[15 - 1, iWW] += 15;
                            break;
                    }
                }

            }
        }

        private void calculateCapacityNeesdfromPreviousPeriodWaitlingListStock()
        {
            foreach (var wS in StorageService.Instance.GetAllWaitingListStocks())
            {
                foreach (var item in wS.WaitingList)
                {
                    switch (item.Item)
                    { 
                        case 49:
                        case 54:
                        case 29:
                            this.CapacityWorkplaces[1 - 1, iWS] += 6 * item.Amount;
                            this.CapacityWorkplaces[1 - 1, iWS] += 20;
                            break;
                        case 30:
                        case 55:
                        case 50:
                            this.CapacityWorkplaces[2 - 1, iWS] += 5 * item.Amount;
                            this.CapacityWorkplaces[2 - 1, iWS] += 30;
                            break;
                        case 51:
                        case 56:
                        case 31:
                            this.CapacityWorkplaces[3 - 1, iWS] += 6 * item.Amount;
                            this.CapacityWorkplaces[3 - 1, iWS] += 30;
                            break;
                        case 1:
                        case 2:
                        case 3:
                            this.CapacityWorkplaces[4 - 1, iWS] += 7 * item.Amount;
                            this.CapacityWorkplaces[4 - 1, iWS] += 30;
                            break;
                        case 18:
                        case 19:
                        case 20:
                            if (wS.Id != 32)
                            {
                                if (wS.Id != 59)
                                {
                                    this.CapacityWorkplaces[6 - 1, iWS] += 3 * item.Amount;
                                    this.CapacityWorkplaces[6 - 1, iWS] += 15;

                                    this.CapacityWorkplaces[8 - 1, iWS] += 3 * item.Amount;
                                    this.CapacityWorkplaces[8 - 1, iWS] += 20;
                                }

                                this.CapacityWorkplaces[7 - 1, iWS] += 2 * item.Amount;
                                this.CapacityWorkplaces[7 - 1, iWS] += 20;
                            }
                            this.CapacityWorkplaces[9 - 1, iWS] += 2 * item.Amount;
                            this.CapacityWorkplaces[9 - 1, iWS] += 20;
                            break;
                        case 16:
                            if(wS.Id == 28)
                            {
                                this.CapacityWorkplaces[6 - 1, iWS] += 2 * item.Amount;
                                this.CapacityWorkplaces[6 - 1, iWS] += 15;
                            }

                            this.CapacityWorkplaces[14 - 1, iWS] += 3 * item.Amount;
                            break;
                        case 26:
                            this.CapacityWorkplaces[7 - 1, iWS] += 2 * item.Amount;
                            this.CapacityWorkplaces[7 - 1, iWS] += 30;

                            this.CapacityWorkplaces[15 - 1, iWS] += 3 * item.Amount;
                            this.CapacityWorkplaces[15 - 1, iWS] += 15;
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            if (wS.Id == 33 || wS.Id == 34 ||
                               wS.Id == 57 || wS.Id == 58 ||
                               wS.Id == 52 || wS.Id == 53)
                            {
                                this.CapacityWorkplaces[10 - 1, iWS] += 4 * item.Amount;
                                this.CapacityWorkplaces[10 - 1, iWS] += 20;
                            }

                            this.CapacityWorkplaces[11 - 1, iWS] += 3 * item.Amount;
                            this.CapacityWorkplaces[11 - 1, iWS] += 20;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            if (wS.Id != 32)
                            {
                                this.CapacityWorkplaces[13 - 1, iWS] += 2 * item.Amount;

                                this.CapacityWorkplaces[12 - 1, iWS] += 3 * item.Amount;

                                this.CapacityWorkplaces[8 - 1, iWS] += 2 * item.Amount;
                                this.CapacityWorkplaces[8 - 1, iWS] += 15;

                                this.CapacityWorkplaces[7 - 1, iWS] += 2 * item.Amount;
                                this.CapacityWorkplaces[7 - 1, iWS] += 20;
                            }
                            this.CapacityWorkplaces[9 - 1, iWS] += 3 * item.Amount;
                            this.CapacityWorkplaces[9 - 1, iWS] += 15;
                            break;
                        case 17:
                            this.CapacityWorkplaces[15 - 1, iWS] += 3 * item.Amount;
                            this.CapacityWorkplaces[15 - 1, iWS] += 15;
                            break;
                    }

                }
            }


        }

        // Arbeitzeiten berechnen
        private void calculateCapacityNeedsFormWorkplaces()
        {
            foreach (var item in StorageService.Instance.GetAllProductionItems())
            {
                switch (item.Article)
                {
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        this.CapacityWorkplaces[10 - 1, iW] += 4 * item.Quantity;
                        this.CapacityWorkplaces[11 - 1, iW] += 3 * item.Quantity;
                        //Rüstzeit
                        this.CapacityWorkplaces[10 - 1, iW] += 20;
                        this.CapacityWorkplaces[11 - 1, iW] += 20;
                        break;
                    case 10:
                    case 13:
                        this.CapacityWorkplaces[7 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[8 - 1, iW] += 1 * item.Quantity;
                        this.CapacityWorkplaces[9 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[12 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[13 - 1, iW] += 2 * item.Quantity;
                        //Rüstzeit 12,13 haben keine!
                        this.CapacityWorkplaces[7 - 1, iW] += 20;
                        this.CapacityWorkplaces[8 - 1, iW] += 15;
                        this.CapacityWorkplaces[9 - 1, iW] += 15;
                        break;
                    case 11:
					case 12:
                    case 14:
                    case 15:
                        this.CapacityWorkplaces[7 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[8 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[9 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[12 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[13 - 1, iW] += 2 * item.Quantity;
                        //Rüstzeit 12,13 haben keine!
                        this.CapacityWorkplaces[7 - 1, iW] += 20;
                        this.CapacityWorkplaces[8 - 1, iW] += 15;
                        this.CapacityWorkplaces[9 - 1, iW] += 15;
                        break;
                    case 16:
                        this.CapacityWorkplaces[6 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[7 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[8 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[9 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[12 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[13 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[14 - 1, iW] += 3 * item.Quantity;
                        //Rüstzeit 12,13,14 haben keine!
                        this.CapacityWorkplaces[6 - 1, iW] += 15;
                        this.CapacityWorkplaces[7 - 1, iW] += 20;
                        this.CapacityWorkplaces[8 - 1, iW] += 15;
                        this.CapacityWorkplaces[9 - 1, iW] += 15;
                        break;
                    case 17:
                        this.CapacityWorkplaces[7 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[8 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[9 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[12 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[13 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[15 - 1, iW] += 3 * item.Quantity;
                        //Rüstzeit 12,13,15 haben keine!
                        this.CapacityWorkplaces[7 - 1, iW] += 20;
                        this.CapacityWorkplaces[8 - 1, iW] += 15;
                        this.CapacityWorkplaces[9 - 1, iW] += 15;
                        break;
                    case 18:
                    case 19:
                    case 20:
                        this.CapacityWorkplaces[6 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[7 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[8 - 1, iW] += 3 * item.Quantity;
                        this.CapacityWorkplaces[9 - 1, iW] += 2 * item.Quantity;
                        //Rüstzeit 
                        this.CapacityWorkplaces[6 - 1, iW] += 15;
                        this.CapacityWorkplaces[7 - 1, iW] += 20;
                        this.CapacityWorkplaces[8 - 1, iW] += 15;
                        this.CapacityWorkplaces[9 - 1, iW] += 15;
                        break;
                    case 26:
                        this.CapacityWorkplaces[7 - 1, iW] += 2 * item.Quantity;
                        this.CapacityWorkplaces[15 - 1, iW] += 3 * item.Quantity;
                        //Rüstzeit 15 hat keine!
                        this.CapacityWorkplaces[7 - 1, iW] += 20;
                        break;
                    case 49:
                    case 54:
                    case 29:
                        this.CapacityWorkplaces[1 - 1, iW] += 6 * item.Quantity;
                        //Rüstzeit
                        this.CapacityWorkplaces[1 - 1, iW] += 20;
                        break;
                    case 50:
                    case 55:
                    case 30:
                        this.CapacityWorkplaces[2 - 1, iW] += 5 * item.Quantity;
                        //Rüstzeit
                        this.CapacityWorkplaces[2 - 1, iW] += 20;
                        break;
                    case 51:
                        this.CapacityWorkplaces[3 - 1, iW] += 5 * item.Quantity;
                        //Rüstzeit
                        this.CapacityWorkplaces[3 - 1, iW] += 20;
                        break;
                    case 56:
                    case 31:
                        this.CapacityWorkplaces[3 - 1, iW] += 6 * item.Quantity;
                        //Rüstzeit
                        this.CapacityWorkplaces[3 - 1, iW] += 20;
                        break;
                    case 1:
                        this.CapacityWorkplaces[4 - 1, iW] += 6 * item.Quantity;
                        //Rüstzeit
                        this.CapacityWorkplaces[4 - 1, iW] += 30;
                        break;
                    case 2:
                    case 3:
                        this.CapacityWorkplaces[4 - 1, iW] += 7 * item.Quantity;
                        //Rüstzeit
                        this.CapacityWorkplaces[4 - 1, iW] += 30;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
