using System;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Logic.Logic
{
    public class CapacityPlanning
    {
        // Reihenfolge: Station, Time Worksation, Time Waitinglist Workstaiton,
        //             Time Waitlinglist List Stock, Shift, WorkingOvertime
        private int[,] CapacityWorkplaces { get; set; }
        const int iStation = 0;  // index Station
        const int iWorkstation = 1;  // index time worksation
        const int iWaitingListWorkStation = 2; // index time waitlinglist workstation
        const int iTimeWaitingListStock = 3; // index time waitlinglist stock
        const int iShift = 4; // index shift
        const int iWorkingOverTime = 5; // index working overtime
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

            CapacityWorkplaces = new int[15, 6];
            initCapacityWorkplaces();

            calculateCapacityNeedsFormWorkplaces();
            calculateCapacityNeesdfromPreviousPeriodWaitlingListWorkstation();
            calculateCapacityNeesdfromPreviousPeriodWaitlingListStock();
            calculateShiftAndWordkingOvertime();

            //Werte in Output Parser setzen
            for (int i = 0; i < CapacityWorkplaces.GetLength(0); i++)
            {
                StorageService.Instance.AddWorkingTimeItem(new WorkingItemList(CapacityWorkplaces[i, iShift], CapacityWorkplaces[i, iStation], CapacityWorkplaces[i, iWorkingOverTime]));
            }

        }

        // Abreitsplatz Id setzen
        private void initCapacityWorkplaces()
        {
            for (int i = 0; i < CapacityWorkplaces.GetLength(0); i++)
            {
                CapacityWorkplaces[i, iStation] = i + 1;
                for (int j = 1; j < CapacityWorkplaces.GetLength(1); j++)
                {
                    CapacityWorkplaces[i, j] = 0;
                }
            }
        }

        private void calculateShiftAndWordkingOvertime()
        {
            int sumCapacity = 0;
            for (int i = 0; i < CapacityWorkplaces.GetLength(0); i++)
            {
                sumCapacity = CapacityWorkplaces[i, iWorkstation] + CapacityWorkplaces[i, iWaitingListWorkStation]
                            + CapacityWorkplaces[i, iTimeWaitingListStock];
                CapacityWorkplaces[i, iWorkingOverTime] = (sumCapacity % maxShiftTime) / 5;
                CapacityWorkplaces[i, iShift] = sumCapacity / maxShiftTime;

                if (CapacityWorkplaces[i, iWorkingOverTime] > 0 && CapacityWorkplaces[i, iShift] == 0)
                {
                    CapacityWorkplaces[i, iShift] = 1;
                    CapacityWorkplaces[i, iWorkingOverTime] = 0;
                }

                if (CapacityWorkplaces[i, iWorkingOverTime] > (maxShiftTime / 5))
                {
                    CapacityWorkplaces[i, iWorkingOverTime] = 0;
                    CapacityWorkplaces[i, iShift] += 1;
                }

                if (CapacityWorkplaces[i, iShift] >= (maxShifts))
                {
                    CapacityWorkplaces[i, iShift] = 3;
                    CapacityWorkplaces[i, iWorkingOverTime] = 0;
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
                            CapacityWorkplaces[1 - 1, iWaitingListWorkStation] += 6 * item.Amount;
                            CapacityWorkplaces[1 - 1, iWaitingListWorkStation] += 20;
                            break;
                        case 2:
                            CapacityWorkplaces[2 - 1, iWaitingListWorkStation] += 5 * item.Amount;
                            CapacityWorkplaces[2 - 1, iWaitingListWorkStation] += 30;
                            break;
                        case 3:
                            CapacityWorkplaces[3 - 1, iWaitingListWorkStation] += 6 * item.Amount;
                            CapacityWorkplaces[3 - 1, iWaitingListWorkStation] += 30;
                            break;
                        case 4:
                            CapacityWorkplaces[4 - 1, iWaitingListWorkStation] += 7 * item.Amount;
                            CapacityWorkplaces[4 - 1, iWaitingListWorkStation] += 30;
                             break;
                        case 5:
                            break;
                        case 6:
                            CapacityWorkplaces[6 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[6 - 1, iWaitingListWorkStation] += 15;

                            if (item.Item == 28)
                            {
                                CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                                CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 25;

                                CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                                CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 20;

                                CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                                CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 20;
                                CapacityWorkplaces[14 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            }
                            break;
                        case 7:
                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 30;
                            if (item.Item != 44 && item.Item != 48)
                            {
                                CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                                CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 15;
                            }
                            else
                            {
                                CapacityWorkplaces[15 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                                CapacityWorkplaces[15 - 1, iWaitingListWorkStation] += 15;
                            }
                            break;
                        case 8:
                            CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 25;

                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 30;

                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 15;
                            break;
                        case 9:
                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 15;
                            break;
                        case 10:
                            CapacityWorkplaces[10 - 1, iWaitingListWorkStation] += 4 * item.Amount;
                            CapacityWorkplaces[10 - 1, iWaitingListWorkStation] += 20;

                            CapacityWorkplaces[11 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[11 - 1, iWaitingListWorkStation] += 20;
                        break;
                        case 11:
                            CapacityWorkplaces[11 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[11 - 1, iWaitingListWorkStation] += 20;
                            break;
                        case 12:
                            CapacityWorkplaces[12 - 1, iWaitingListWorkStation] += 3 * item.Amount;

                            CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                            CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 15;

                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 20;

                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 15;
                            break;
                        case 13:
                            CapacityWorkplaces[13 - 1, iWaitingListWorkStation] += 2 * item.Amount;

                            CapacityWorkplaces[12 - 1, iWaitingListWorkStation] += 3 * item.Amount;

                            CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                            CapacityWorkplaces[8 - 1, iWaitingListWorkStation] += 15;

                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 2 * item.Amount;
                            CapacityWorkplaces[7 - 1, iWaitingListWorkStation] += 20;

                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[9 - 1, iWaitingListWorkStation] += 15;
                            break;
                        case 14:
                            CapacityWorkplaces[14 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            break;
                        case 15:
                            CapacityWorkplaces[15 - 1, iWaitingListWorkStation] += 3 * item.Amount;
                            CapacityWorkplaces[15 - 1, iWaitingListWorkStation] += 15;
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
                            CapacityWorkplaces[1 - 1, iTimeWaitingListStock] += 6 * item.Amount;
                            CapacityWorkplaces[1 - 1, iTimeWaitingListStock] += 20;
                            break;
                        case 30:
                        case 55:
                        case 50:
                            CapacityWorkplaces[2 - 1, iTimeWaitingListStock] += 5 * item.Amount;
                            CapacityWorkplaces[2 - 1, iTimeWaitingListStock] += 30;
                            break;
                        case 51:
                        case 56:
                        case 31:
                            CapacityWorkplaces[3 - 1, iTimeWaitingListStock] += 6 * item.Amount;
                            CapacityWorkplaces[3 - 1, iTimeWaitingListStock] += 30;
                            break;
                        case 1:
                        case 2:
                        case 3:
                            CapacityWorkplaces[4 - 1, iTimeWaitingListStock] += 7 * item.Amount;
                            CapacityWorkplaces[4 - 1, iTimeWaitingListStock] += 30;
                            break;
                        case 18:
                        case 19:
                        case 20:
                            if (wS.Id != 32)
                            {
                                if (wS.Id != 59)
                                {
                                    CapacityWorkplaces[6 - 1, iTimeWaitingListStock] += 3 * item.Amount;
                                    CapacityWorkplaces[6 - 1, iTimeWaitingListStock] += 15;

                                    CapacityWorkplaces[8 - 1, iTimeWaitingListStock] += 3 * item.Amount;
                                    CapacityWorkplaces[8 - 1, iTimeWaitingListStock] += 20;
                                }

                                CapacityWorkplaces[7 - 1, iTimeWaitingListStock] += 2 * item.Amount;
                                CapacityWorkplaces[7 - 1, iTimeWaitingListStock] += 20;
                            }
                            CapacityWorkplaces[9 - 1, iTimeWaitingListStock] += 2 * item.Amount;
                            CapacityWorkplaces[9 - 1, iTimeWaitingListStock] += 20;
                            break;
                        case 16:
                            if(wS.Id == 28)
                            {
                                CapacityWorkplaces[6 - 1, iTimeWaitingListStock] += 2 * item.Amount;
                                CapacityWorkplaces[6 - 1, iTimeWaitingListStock] += 15;
                            }

                            CapacityWorkplaces[14 - 1, iTimeWaitingListStock] += 3 * item.Amount;
                            break;
                        case 26:
                            CapacityWorkplaces[7 - 1, iTimeWaitingListStock] += 2 * item.Amount;
                            CapacityWorkplaces[7 - 1, iTimeWaitingListStock] += 30;

                            CapacityWorkplaces[15 - 1, iTimeWaitingListStock] += 3 * item.Amount;
                            CapacityWorkplaces[15 - 1, iTimeWaitingListStock] += 15;
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
                                CapacityWorkplaces[10 - 1, iTimeWaitingListStock] += 4 * item.Amount;
                                CapacityWorkplaces[10 - 1, iTimeWaitingListStock] += 20;
                            }

                            CapacityWorkplaces[11 - 1, iTimeWaitingListStock] += 3 * item.Amount;
                            CapacityWorkplaces[11 - 1, iTimeWaitingListStock] += 20;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            if (wS.Id != 32)
                            {
                                CapacityWorkplaces[13 - 1, iTimeWaitingListStock] += 2 * item.Amount;

                                CapacityWorkplaces[12 - 1, iTimeWaitingListStock] += 3 * item.Amount;

                                CapacityWorkplaces[8 - 1, iTimeWaitingListStock] += 2 * item.Amount;
                                CapacityWorkplaces[8 - 1, iTimeWaitingListStock] += 15;

                                CapacityWorkplaces[7 - 1, iTimeWaitingListStock] += 2 * item.Amount;
                                CapacityWorkplaces[7 - 1, iTimeWaitingListStock] += 20;
                            }
                            CapacityWorkplaces[9 - 1, iTimeWaitingListStock] += 3 * item.Amount;
                            CapacityWorkplaces[9 - 1, iTimeWaitingListStock] += 15;
                            break;
                        case 17:
                            CapacityWorkplaces[15 - 1, iTimeWaitingListStock] += 3 * item.Amount;
                            CapacityWorkplaces[15 - 1, iTimeWaitingListStock] += 15;
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
                        CapacityWorkplaces[10 - 1, iWorkstation] += 4 * item.Quantity;
                        CapacityWorkplaces[11 - 1, iWorkstation] += 3 * item.Quantity;
                        //Rüstzeit
                        CapacityWorkplaces[10 - 1, iWorkstation] += 20;
                        CapacityWorkplaces[11 - 1, iWorkstation] += 20;
                        break;
                    case 10:
                    case 13:
                        CapacityWorkplaces[7 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 1 * item.Quantity;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[12 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[13 - 1, iWorkstation] += 2 * item.Quantity;
                        //Rüstzeit 12,13 haben keine!
                        CapacityWorkplaces[7 - 1, iWorkstation] += 20;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 15;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 15;
                        break;
                    case 11:
					case 12:
                    case 14:
                    case 15:
                        CapacityWorkplaces[7 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[12 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[13 - 1, iWorkstation] += 2 * item.Quantity;
                        //Rüstzeit 12,13 haben keine!
                        CapacityWorkplaces[7 - 1, iWorkstation] += 20;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 15;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 15;
                        break;
                    case 16:
                        CapacityWorkplaces[6 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[7 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[12 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[13 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[14 - 1, iWorkstation] += 3 * item.Quantity;
                        //Rüstzeit 12,13,14 haben keine!
                        CapacityWorkplaces[6 - 1, iWorkstation] += 15;
                        CapacityWorkplaces[7 - 1, iWorkstation] += 20;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 15;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 15;
                        break;
                    case 17:
                        CapacityWorkplaces[7 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[12 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[13 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[15 - 1, iWorkstation] += 3 * item.Quantity;
                        //Rüstzeit 12,13,15 haben keine!
                        CapacityWorkplaces[7 - 1, iWorkstation] += 20;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 15;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 15;
                        break;
                    case 18:
                    case 19:
                    case 20:
                        CapacityWorkplaces[6 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[7 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 3 * item.Quantity;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 2 * item.Quantity;
                        //Rüstzeit 
                        CapacityWorkplaces[6 - 1, iWorkstation] += 15;
                        CapacityWorkplaces[7 - 1, iWorkstation] += 20;
                        CapacityWorkplaces[8 - 1, iWorkstation] += 15;
                        CapacityWorkplaces[9 - 1, iWorkstation] += 15;
                        break;
                    case 26:
                        CapacityWorkplaces[7 - 1, iWorkstation] += 2 * item.Quantity;
                        CapacityWorkplaces[15 - 1, iWorkstation] += 3 * item.Quantity;
                        //Rüstzeit 15 hat keine!
                        CapacityWorkplaces[7 - 1, iWorkstation] += 20;
                        break;
                    case 49:
                    case 54:
                    case 29:
                        CapacityWorkplaces[1 - 1, iWorkstation] += 6 * item.Quantity;
                        //Rüstzeit
                        CapacityWorkplaces[1 - 1, iWorkstation] += 20;
                        break;
                    case 50:
                    case 55:
                    case 30:
                        CapacityWorkplaces[2 - 1, iWorkstation] += 5 * item.Quantity;
                        //Rüstzeit
                        CapacityWorkplaces[2 - 1, iWorkstation] += 20;
                        break;
                    case 51:
                        CapacityWorkplaces[3 - 1, iWorkstation] += 5 * item.Quantity;
                        //Rüstzeit
                        CapacityWorkplaces[3 - 1, iWorkstation] += 20;
                        break;
                    case 56:
                    case 31:
                        CapacityWorkplaces[3 - 1, iWorkstation] += 6 * item.Quantity;
                        //Rüstzeit
                        CapacityWorkplaces[3 - 1, iWorkstation] += 20;
                        break;
                    case 1:
                        CapacityWorkplaces[4 - 1, iWorkstation] += 6 * item.Quantity;
                        //Rüstzeit
                        CapacityWorkplaces[4 - 1, iWorkstation] += 30;
                        break;
                    case 2:
                    case 3:
                        CapacityWorkplaces[4 - 1, iWorkstation] += 7 * item.Quantity;
                        //Rüstzeit
                        CapacityWorkplaces[4 - 1, iWorkstation] += 30;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
