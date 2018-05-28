using System.Collections.Generic;
using BikeProductionPlanner.Logic.Database;
using BikeProductionPlanner.Logic.Database.Model;

namespace BikeProductionPlanner.Logic.Logic
{
    public class CapacityPlan
    {
        public Workplace a1 = new Workplace(1, new List<WorkplaceTask>
        {
            new WorkplaceTask(49, 6, 20),
            new WorkplaceTask(54, 6, 20),
            new WorkplaceTask(29, 6, 20)
        });
        public Workplace a2 = new Workplace(2, new List<WorkplaceTask>
        {
            new WorkplaceTask(50, 5, 30),
            new WorkplaceTask(55, 5, 30),
            new WorkplaceTask(30, 5, 20)
        });
        public Workplace a3 = new Workplace(3, new List<WorkplaceTask>
        {
            new WorkplaceTask(51, 5, 20),
            new WorkplaceTask(56, 6, 20),
            new WorkplaceTask(31, 6, 20)
        });
        public Workplace a4 = new Workplace(4, new List<WorkplaceTask>
        {
            new WorkplaceTask(1, 6, 30),
            new WorkplaceTask(2, 7, 20),
            new WorkplaceTask(3, 7, 30)
        });
        public Workplace a6 = new Workplace(6, new List<WorkplaceTask>
        {
            new WorkplaceTask(16, 2, 15),
            new WorkplaceTask(18, 3, 15),
            new WorkplaceTask(19, 3, 15),
            new WorkplaceTask(20, 3, 15)
        });
        public Workplace a7 = new Workplace(7, new List<WorkplaceTask>
        {
            new WorkplaceTask(10, 2, 20),
            new WorkplaceTask(11, 2, 20),
            new WorkplaceTask(12, 2, 20),
            new WorkplaceTask(13, 2, 20),
            new WorkplaceTask(14, 2, 20),
            new WorkplaceTask(15, 2, 20),
            new WorkplaceTask(18, 2, 20),
            new WorkplaceTask(19, 2, 20),
            new WorkplaceTask(20, 2, 20),
            new WorkplaceTask(26, 2, 30)
        });
        public Workplace a8 = new Workplace(8, new List<WorkplaceTask>
        {
            new WorkplaceTask(10, 1, 15),
            new WorkplaceTask(11, 2, 15),
            new WorkplaceTask(12, 2, 15),
            new WorkplaceTask(13, 1, 15),
            new WorkplaceTask(14, 2, 15),
            new WorkplaceTask(15, 2, 15),
            new WorkplaceTask(18, 3, 20),
            new WorkplaceTask(19, 3, 25),
            new WorkplaceTask(20, 3, 20)
        });
        public Workplace a9 = new Workplace(9, new List<WorkplaceTask>
        {
            new WorkplaceTask(10, 3, 15),
            new WorkplaceTask(11, 3, 15),
            new WorkplaceTask(12, 3, 15),
            new WorkplaceTask(13, 3, 15),
            new WorkplaceTask(14, 3, 15),
            new WorkplaceTask(15, 3, 15),
            new WorkplaceTask(18, 2, 15),
            new WorkplaceTask(19, 2, 15),
            new WorkplaceTask(20, 2, 15)
        });
        public Workplace a10 = new Workplace(10, new List<WorkplaceTask>
        {
            new WorkplaceTask(4, 4, 20),
            new WorkplaceTask(5, 4, 20),
            new WorkplaceTask(6, 4, 20),
            new WorkplaceTask(7, 4, 20),
            new WorkplaceTask(8, 4, 20),
            new WorkplaceTask(9, 4, 20)
        });
        public Workplace a11 = new Workplace(11, new List<WorkplaceTask>
        {
            new WorkplaceTask(4, 3, 10),
            new WorkplaceTask(5, 3, 10),
            new WorkplaceTask(6, 3, 20),
            new WorkplaceTask(7, 3, 20),
            new WorkplaceTask(8, 3, 20),
            new WorkplaceTask(9, 3, 20)
        });
        public Workplace a12 = new Workplace(12, new List<WorkplaceTask>
        {
            new WorkplaceTask(10, 3, 0),
            new WorkplaceTask(11, 3, 0),
            new WorkplaceTask(12, 3, 0),
            new WorkplaceTask(13, 3, 0),
            new WorkplaceTask(14, 3, 0),
            new WorkplaceTask(15, 3, 0)
        });
        public Workplace a13 = new Workplace(13, new List<WorkplaceTask>
        {
            new WorkplaceTask(10, 2, 0),
            new WorkplaceTask(11, 2, 0),
            new WorkplaceTask(12, 2, 0),
            new WorkplaceTask(13, 2, 0),
            new WorkplaceTask(14, 2, 0),
            new WorkplaceTask(15, 2, 0)
        });
        public Workplace a14 = new Workplace(14, new List<WorkplaceTask>
        {
            new WorkplaceTask(16, 3, 0)
        });
        public Workplace a15 = new Workplace(15, new List<WorkplaceTask>
        {
            new WorkplaceTask(17, 3, 15),
            new WorkplaceTask(26, 3, 15)
        });

        public List<Workplace> WorkplaceList;

        private static CapacityPlan instance;

        public static CapacityPlan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CapacityPlan();
                }

                return instance;
            }

            set
            {
                instance = value;
            }
        }

        private CapacityPlan()
        {
            WorkplaceList = new List<Workplace>
            {
                a1,a2,a3,a4,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15
            };
        }

        public Workplace getWorkplaceById(int Id)
        {
            switch (Id)
            {

                case 1: return a1;
                case 2: return a2;
                case 3: return a3;
                case 4: return a4;
                case 6: return a6;
                case 7: return a7;
                case 8: return a8;
                case 9: return a9;
                case 10: return a10;
                case 11: return a11;
                case 12: return a12;
                case 13: return a13;
                case 14: return a14;
                case 15: return a15;
                default: return a1;
            }
        }

        public void Calculate()
        {
            List<WaitingListWorkstation> workplaces = StorageService.Instance.getAllWorkplaces();

            foreach (WaitingListWorkstation w in workplaces)
            {
                foreach (WaitingList wl in w.WaitingList)
                {
                    // E13-15
                    if (wl.Item == 13)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 14)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 15)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }



                    //E18-20
                    else if (wl.Item == 18)
                    {
                        if (w.Id == 6)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 3;
                            a8.SetupTimePrevious += 20;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 19)
                    {
                        if (w.Id == 6)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 3;
                            a8.SetupTimePrevious += 25;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 20;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 20;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 20;
                        }
                    }
                    else if (wl.Item == 20)
                    {
                        if (w.Id == 6)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 3;
                            a8.SetupTimePrevious += 20;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                    }


                    //E7-9
                    else if (wl.Item == 7)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }
                    else if (wl.Item == 8)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }
                    else if (wl.Item == 9)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }


                    //E4-6
                    else if (wl.Item == 4)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 10;
                        }

                    }
                    else if (wl.Item == 5)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 10;
                        }

                    }
                    else if (wl.Item == 6)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }


                    //E10-12
                    if (wl.Item == 10)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 11)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 12)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }

                    //E16
                    else if (wl.Item == 16)
                    {
                        if (w.Id == 6)
                        {
                            a14.KapaDemandPrevious += wl.Amount * 3;
                        }

                    }


                    //E26
                    else if (wl.Item == 26)
                    {
                        if (w.Id == 7)
                        {
                            a15.KapaDemandPrevious += wl.Amount * 3;
                            a15.SetupTimePrevious += 15;
                        }

                    }
                }
            }

            List<WaitingListWorkstation> oWorkplaces = StorageService.Instance.getAllWorkplaces();
            foreach (WaitingListWorkstation w in oWorkplaces)
            {
                foreach (WaitingList wl in w.WaitingList)
                {
                    // E13-15
                    if (wl.Item == 13)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 14)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 15)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }



                    //E18-20
                    else if (wl.Item == 18)
                    {
                        if (w.Id == 6)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 3;
                            a8.SetupTimePrevious += 20;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 19)
                    {
                        if (w.Id == 6)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 3;
                            a8.SetupTimePrevious += 25;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 20;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 20;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 20;
                        }
                    }
                    else if (wl.Item == 20)
                    {
                        if (w.Id == 6)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 3;
                            a8.SetupTimePrevious += 20;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 2;
                            a9.SetupTimePrevious += 15;
                        }
                    }


                    //E7-9
                    else if (wl.Item == 7)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }
                    else if (wl.Item == 8)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }
                    else if (wl.Item == 9)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }


                    //E4-6
                    else if (wl.Item == 4)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 10;
                        }

                    }
                    else if (wl.Item == 5)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 10;
                        }

                    }
                    else if (wl.Item == 6)
                    {
                        if (w.Id == 10)
                        {
                            a11.KapaDemandPrevious += wl.Amount * 3;
                            a11.SetupTimePrevious += 20;
                        }

                    }


                    //E10-12
                    if (wl.Item == 10)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 1;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 11)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }
                    else if (wl.Item == 12)
                    {
                        if (w.Id == 13)
                        {
                            a12.KapaDemandPrevious += wl.Amount * 3;
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 12)
                        {
                            a8.KapaDemandPrevious += wl.Amount * 2;
                            a8.SetupTimePrevious += 15;
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 8)
                        {
                            a7.KapaDemandPrevious += wl.Amount * 2;
                            a7.SetupTimePrevious += 20;
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                        else if (w.Id == 7)
                        {
                            a9.KapaDemandPrevious += wl.Amount * 3;
                            a9.SetupTimePrevious += 15;
                        }
                    }

                    //E16
                    else if (wl.Item == 16)
                    {
                        if (w.Id == 6)
                        {
                            a14.KapaDemandPrevious += wl.Amount * 3;
                        }

                    }


                    //E26
                    else if (wl.Item == 26)
                    {
                        if (w.Id == 7)
                        {
                            a15.KapaDemandPrevious += wl.Amount * 3;
                            a15.SetupTimePrevious += 15;
                        }

                    }
                }
            }

        }
    }
}
