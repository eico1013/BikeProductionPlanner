using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using BikeProductionPlanner.Logic.Database.Model;
using BikeProductionPlanner.Logic.Logic;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaction logic for CapacityPlanningPage.xaml
    /// </summary>
    public partial class CapacityPlanningPage : UserControl
    {

        private Dictionary<int, Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>> _workItems;

        public CapacityPlanningPage()
        {
            InitializeComponent();
        }

        private void KapaCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _workItems = new Dictionary<int, Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>>();

            _workItems.Add(1, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork1(), CreateWorkPlan()));
            _workItems.Add(2, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork2(), CreateWorkPlan()));
            _workItems.Add(3, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork3(), CreateWorkPlan()));
            _workItems.Add(4, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork4(), CreateWorkPlan()));

            //workItems.Add(5, CreateWork5());

            _workItems.Add(5, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork6(), CreateWorkPlan()));
            _workItems.Add(6, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork7(), CreateWorkPlan()));
            _workItems.Add(7, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork8(), CreateWorkPlan()));
            _workItems.Add(8, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork9(), CreateWorkPlan()));
            _workItems.Add(9, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork10(), CreateWorkPlan()));

            _workItems.Add(10, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork11(), CreateWorkPlan()));
            _workItems.Add(11, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork12(), CreateWorkPlan()));
            _workItems.Add(12, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork13(), CreateWorkPlan()));
            _workItems.Add(13, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork14(), CreateWorkPlan()));
            _workItems.Add(14, new Tuple<ObservableCollection<ItemNo>, ObservableCollection<KapNo>>(CreateWork15(), CreateWorkPlan()));

            this.kapaCombo.SelectedIndex = 0;
            SetValues(1);
        }

        public void SetValues(int i)
        {
            this.kapaProdList.ItemsSource = _workItems[i].Item1;
            this.kapaKpiList.ItemsSource = _workItems[i].Item2;
        }

        public void UpdateKapaFields()
        {
            for (int id = 0; id < _workItems.Values.Count; id++)
            {
                var kapaItem = _workItems[id + 1];

                foreach (ItemNo kapaProdItem in kapaItem.Item1)
                {
                    int partId = System.Convert.ToInt32(Regex.Replace(kapaProdItem.Id, "[^0-9]+", string.Empty));
                    kapaProdItem.CostSum = CapacityPlan.Instance.WorkplaceList[id].TaskList.Find(x => x.articleId == partId).kapaDemandPerUnit.ToString();
                    kapaProdItem.Amount = ProductionPlan.GetDemandById(partId).ToString();
                }

                //...

                for (int n = 0; n < kapaItem.Item2.Count; n++)
                {
                    kapaItem.Item2[n].Calculation = CapacityPlan.Instance.WorkplaceList[id].GetFieldsById(n).ToString();
                }
            }

            Kapa1.Text = CapacityPlan.Instance.WorkplaceList[0].GetFieldsById(4).ToString();
            Kapa2.Text = CapacityPlan.Instance.WorkplaceList[1].GetFieldsById(4).ToString();
            Kapa3.Text = CapacityPlan.Instance.WorkplaceList[2].GetFieldsById(4).ToString();
            Kapa4.Text = CapacityPlan.Instance.WorkplaceList[3].GetFieldsById(4).ToString();
            Kapa6.Text = CapacityPlan.Instance.WorkplaceList[4].GetFieldsById(4).ToString();
            Kapa7.Text = CapacityPlan.Instance.WorkplaceList[5].GetFieldsById(4).ToString();
            Kapa8.Text = CapacityPlan.Instance.WorkplaceList[6].GetFieldsById(4).ToString();
            Kapa9.Text = CapacityPlan.Instance.WorkplaceList[7].GetFieldsById(4).ToString();
            Kapa10.Text = CapacityPlan.Instance.WorkplaceList[8].GetFieldsById(4).ToString();
            Kapa11.Text = CapacityPlan.Instance.WorkplaceList[9].GetFieldsById(4).ToString();
            Kapa12.Text = CapacityPlan.Instance.WorkplaceList[10].GetFieldsById(4).ToString();
            Kapa13.Text = CapacityPlan.Instance.WorkplaceList[11].GetFieldsById(4).ToString();
            Kapa14.Text = CapacityPlan.Instance.WorkplaceList[12].GetFieldsById(4).ToString();
            Kapa15.Text = CapacityPlan.Instance.WorkplaceList[13].GetFieldsById(4).ToString();

            OverTime1.Text = CapacityPlan.Instance.WorkplaceList[0].GetFieldsById(6).ToString();
            OverTime2.Text = CapacityPlan.Instance.WorkplaceList[1].GetFieldsById(6).ToString();
            OverTime3.Text = CapacityPlan.Instance.WorkplaceList[2].GetFieldsById(6).ToString();
            OverTime4.Text = CapacityPlan.Instance.WorkplaceList[3].GetFieldsById(6).ToString();
            OverTime6.Text = CapacityPlan.Instance.WorkplaceList[4].GetFieldsById(6).ToString();
            OverTime7.Text = CapacityPlan.Instance.WorkplaceList[5].GetFieldsById(6).ToString();
            OverTime8.Text = CapacityPlan.Instance.WorkplaceList[6].GetFieldsById(6).ToString();
            OverTime9.Text = CapacityPlan.Instance.WorkplaceList[7].GetFieldsById(6).ToString();
            OverTime10.Text = CapacityPlan.Instance.WorkplaceList[8].GetFieldsById(6).ToString();
            OverTime11.Text = CapacityPlan.Instance.WorkplaceList[9].GetFieldsById(6).ToString();
            OverTime12.Text = CapacityPlan.Instance.WorkplaceList[10].GetFieldsById(6).ToString();
            OverTime13.Text = CapacityPlan.Instance.WorkplaceList[11].GetFieldsById(6).ToString();
            OverTime14.Text = CapacityPlan.Instance.WorkplaceList[12].GetFieldsById(6).ToString();
            OverTime15.Text = CapacityPlan.Instance.WorkplaceList[13].GetFieldsById(6).ToString();

            Schicht1.Text = CapacityPlan.Instance.WorkplaceList[0].GetFieldsById(5).ToString();
            Schicht2.Text = CapacityPlan.Instance.WorkplaceList[1].GetFieldsById(5).ToString();
            Schicht3.Text = CapacityPlan.Instance.WorkplaceList[2].GetFieldsById(5).ToString();
            Schicht4.Text = CapacityPlan.Instance.WorkplaceList[3].GetFieldsById(5).ToString();
            Schicht6.Text = CapacityPlan.Instance.WorkplaceList[4].GetFieldsById(5).ToString();
            Schicht7.Text = CapacityPlan.Instance.WorkplaceList[5].GetFieldsById(5).ToString();
            Schicht8.Text = CapacityPlan.Instance.WorkplaceList[6].GetFieldsById(5).ToString();
            Schicht9.Text = CapacityPlan.Instance.WorkplaceList[7].GetFieldsById(5).ToString();
            Schicht10.Text = CapacityPlan.Instance.WorkplaceList[8].GetFieldsById(5).ToString();
            Schicht11.Text = CapacityPlan.Instance.WorkplaceList[9].GetFieldsById(5).ToString();
            Schicht12.Text = CapacityPlan.Instance.WorkplaceList[10].GetFieldsById(5).ToString();
            Schicht13.Text = CapacityPlan.Instance.WorkplaceList[11].GetFieldsById(5).ToString();
            Schicht14.Text = CapacityPlan.Instance.WorkplaceList[12].GetFieldsById(5).ToString();
            Schicht15.Text = CapacityPlan.Instance.WorkplaceList[13].GetFieldsById(5).ToString();

            CapacityPlan.Instance = null;
        }

        private ObservableCollection<KapNo> CreateWorkPlan()
        {
            ObservableCollection<KapNo> kapno = new ObservableCollection<KapNo>();
            kapno.Add(new KapNo { Title = "Kapazitätsbedarf", Calculation = "" });
            kapno.Add(new KapNo { Title = "Rüstzeiten", Calculation = "" });
            kapno.Add(new KapNo { Title = "Kapazitätsrückstand", Calculation = "" });
            kapno.Add(new KapNo { Title = "Rüstzeitenrückstand", Calculation = "" });
            kapno.Add(new KapNo { Title = "Kapazitätsbedarf Gesamt", Calculation = "" });
            kapno.Add(new KapNo { Title = "Schichten", Calculation = "" });
            kapno.Add(new KapNo { Title = "Überstunden / Tag", Calculation = "" });
            return kapno;
        }

        private ObservableCollection<ItemNo> CreateWork1()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL_COMPLETE", Id = "E49", Type = "Kinder", Cost = "6", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL_COMPLETE", Id = "E54", Type = "Damen", Cost = "6", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL_COMPLETE", Id = "E29", Type = "Herren", Cost = "6", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork2()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "FRAME_AND_WHEELS", Id = "E50", Type = "Kinder", Cost = "5", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME_AND_WHEELS", Id = "E55", Type = "Damen", Cost = "5", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME_AND_WHEELS", Id = "E30", Type = "Herren", Cost = "5", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork3()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "BICYCLE_WITHOUT_PEDAL", Id = "E51", Type = "Kinder", Cost = "5", CostSum = "" });
            itemno.Add(new ItemNo { Title = "BICYCLE_WITHOUT_PEDAL", Id = "E56", Type = "Damen", Cost = "6", CostSum = "" });
            itemno.Add(new ItemNo { Title = "BICYCLE_WITHOUT_PEDAL", Id = "E31", Type = "Herren", Cost = "6", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork4()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "BICYCLE_COMPLETE", Id = "P1", Type = "Kinder", Cost = "6", CostSum = "" });
            itemno.Add(new ItemNo { Title = "BICYCLE_COMPLETE", Id = "P2", Type = "Damen", Cost = "7", CostSum = "" });
            itemno.Add(new ItemNo { Title = "BICYCLE_COMPLETE", Id = "P3", Type = "Herren", Cost = "7", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork6()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "HANDLE_BAR", Id = "E16", Type = "KDH", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E18", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E19", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E20", Type = "Kinder", Cost = "3", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork7()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E10", Type = "Kinder", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E11", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E12", Type = "Herren", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E13", Type = "Kinder", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E14", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E15", Type = "Herren", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E18", Type = "Kinder", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E19", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E20", Type = "Herren", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "PEDAL", Id = "E26", Type = "KDH", Cost = "2", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork8()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E10", Type = "Kinder", Cost = "1", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E11", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E12", Type = "Herren", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E13", Type = "Kinder", Cost = "1", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E14", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E15", Type = "Herren", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E18", Type = "Kinder", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E19", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E20", Type = "Herren", Cost = "2", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork9()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E10", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E11", Type = "Damen", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E12", Type = "Herren", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E13", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E14", Type = "Damen", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E15", Type = "Herren", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E18", Type = "Kinder", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E19", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRAME", Id = "E20", Type = "Herren", Cost = "2", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork10()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "REAR_WHEEL", Id = "E4", Type = "Kinder", Cost = "4", CostSum = "" });
            itemno.Add(new ItemNo { Title = "REAR_WHEEL", Id = "E5", Type = "Damen", Cost = "4", CostSum = "" });
            itemno.Add(new ItemNo { Title = "REAR_WHEEL", Id = "E6", Type = "Herren", Cost = "4", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL", Id = "E7", Type = "Kinder", Cost = "4", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL", Id = "E8", Type = "Damen", Cost = "4", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL", Id = "E9", Type = "Herren", Cost = "4", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork11()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "REAR_WHEEL", Id = "E4", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "REAR_WHEEL", Id = "E5", Type = "Damen", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "REAR_WHEEL", Id = "E6", Type = "Herren", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL", Id = "E7", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL", Id = "E8", Type = "Damen", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "FRONT_WHEEL", Id = "E9", Type = "Herren", Cost = "3", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork12()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E10", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E11", Type = "Damen", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E12", Type = "Herren", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E13", Type = "Kinder", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E14", Type = "Damen", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E15", Type = "Herren", Cost = "3", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork13()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E10", Type = "Kinder", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E11", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_REAR", Id = "E12", Type = "Herren", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E13", Type = "Kinder", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E14", Type = "Damen", Cost = "2", CostSum = "" });
            itemno.Add(new ItemNo { Title = "MUDGUARD_FRONT", Id = "E15", Type = "Herren", Cost = "2", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork14()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "HANDLE_BAR", Id = "E16", Type = "KDH", Cost = "3", CostSum = "" });
            return itemno;
        }

        private ObservableCollection<ItemNo> CreateWork15()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Title = "SEAT", Id = "E17", Type = "KDH", Cost = "3", CostSum = "" });
            itemno.Add(new ItemNo { Title = "Pedal", Id = "E26", Type = "KDH", Cost = "3", CostSum = "" });
            return itemno;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                int tag = -1;

                if (int.TryParse((e.AddedItems[0] as ComboBoxItem).Tag.ToString(), out tag))
                {
                    this.kapaProdList.ItemsSource = _workItems[tag].Item1;
                    this.kapaKpiList.ItemsSource = _workItems[tag].Item2;
                }
            }
        }
    }
}
