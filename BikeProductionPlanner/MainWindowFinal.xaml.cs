using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BikeProductionPlanner.Logic.Logic;
using BikeProductionPlanner.Logic.UI;
using BikeProductionPlanner.Views;
using BikeProductionPlanner.WPF.Views;
using DynamicLocalization;

namespace BikeProductionPlanner
{
    /// <summary>
    /// Interaction logic for MainWindowFinal.xaml
    /// </summary>
    public partial class MainWindowFinal : Window
    {

        private State uiState;
        private Dictionary<string, Button> menuButtonMap;
        private Dictionary<MenuItems.MenuItemsEnum, UserControl> pageMap;

        public static MainWindowFinal Instance;

        public MainWindowFinal()
        {
            InitializeComponent();

            InitializeUI();



            LocUtil.SetDefaultLanguage(this);
            

            // Adjust checked language menu item
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                if (item.Tag.ToString().Equals(LocUtil.GetCurrentCultureName(this)))
                    item.IsChecked = true;
            }
        }

        private void InitializeUI()
        {
            MainWindowFinal.Instance = this;

            //menuButtonList = new List<Button>()
            //{
            //    this.DatenImportButton,
            //    this.VertriebButton,
            //    this.SicherheitsbestandButton,
            //    this.ProduktionsplanButton,
            //    this.ArbeitsplaetzeButton,
            //    this.EinkaufButton,
            //    this.AnpassungenButton,
            //    this.DatenExportButton
            //};

            //menuButtonMap = new Dictionary<string, Button>()
            //{
            //    { MenuItems, this.UserSettingsButton },
            //    { MenuItems.DataImport, this.DatenImportButton },
            //    { MenuItems.Sales, this.VertriebButton },
            //    { MenuItems.SafetyStock, this.SicherheitsbestandButton },
            //    { MenuItems.ProductionPlan, this.ProduktionsplanButton },
            //    { MenuItems.Capacity, this.ArbeitsplaetzeButton },
            //    { MenuItems.Purchase, this.EinkaufButton },
            //    { MenuItems.DataExport, this.DatenExportButton },
            //    { MenuItems.Customisation, this.AnpassungenButton }
            //};

            pageMap = new Dictionary<MenuItems.MenuItemsEnum, UserControl>()
            {
                { MenuItems.MenuItemsEnum.Dashboard, new Dashboard() },
                { MenuItems.MenuItemsEnum.DataImport, new XMLImportPage() },
                { MenuItems.MenuItemsEnum.Sales, new Sales() },
                { MenuItems.MenuItemsEnum.SafetyStock, new SafetyStock() },
                //{ MenuItems.MenuItemsEnum.ProductionPlan, new ProductionPlanPage() },
                { MenuItems.MenuItemsEnum.Capacity, new CapacityPlanningPage() },
                //{ MenuItems.Purchase, new PurchasePage() },
                { MenuItems.MenuItemsEnum.DataExport, new XMLExportPage() },
                //{ MenuItems.Customisation, new CustomizePage() }
            };

            UpdateUI(State.DataImport);
            NavigateTo(MenuItems.MenuItemsEnum.DataImport);
        }

        public void NavigateTo(MenuItems.MenuItemsEnum tag)
        {
            if (pageMap.ContainsKey(tag))
            {
                
                ContentControl.Content = pageMap[tag];

                this.Title = "ZODABA Bikes SCM - " + tag;
            }
        }

        public void UpdateUI(State newState)
        {
            if (this.uiState == newState)
            {
                return;
            }

            this.uiState = newState;

            //foreach (var button in menuButtonList)
            //{
            //    button.IsEnabled = false;
            //}

            switch (uiState)
            {
                //case State.DataImport:
                //    this.DatenImportButton.IsEnabled = true;
                //    break;
                //case State.Input:
                //    this.DatenImportButton.IsEnabled = true;
                //    this.VertriebButton.IsEnabled = true;
                //    this.SicherheitsbestandButton.IsEnabled = true;
                //    break;
                case State.Result:
                    //foreach (var button in menuButtonList)
                    //{
                    //    button.IsEnabled = true;
                    //}

                    PlanCalculations.Calculate();

                    //(pageMap[MenuItems.MenuItemsEnum.ProductionPlan] as ProductionPlan).UpdatePlanningFields();
                    (pageMap[MenuItems.MenuItemsEnum.Capacity] as CapacityPlanningPage).UpdateKapaFields();

                    //(pageMap[MenuItems.MenuItemsEnum.Purchase] as PurchasePage).UpdatePurchase();
                    //(pageMap[MenuItems.MenuItemsEnum.Purchase] as PurchasePage).UpdateWarehouseStock();

                    //(pageMap[MenuItems.MenuItemsEnum.Customisation] as CustomizePage).UpdatePrioFields();
                    break;
                default:
                    break;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Adjust checked language menu item
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                if (item.Tag.ToString().Equals(LocUtil.GetCurrentCultureName(this)))
                    item.IsChecked = true;
            }

            MenuItem mi = sender as MenuItem;
            mi.IsChecked = true;
            LocUtil.SwitchLanguage(this, mi.Tag.ToString());
        }

        private void ListViewMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            //MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    NavigateTo(MenuItems.MenuItemsEnum.Dashboard);
                    break;
                case 1:
                    NavigateTo(MenuItems.MenuItemsEnum.DataImport);
                    break;
                case 2:
                    NavigateTo(MenuItems.MenuItemsEnum.Sales);
                    break;
                case 3:
                    NavigateTo(MenuItems.MenuItemsEnum.SafetyStock);
                    break;
                case 5:
                    NavigateTo(MenuItems.MenuItemsEnum.Capacity);
                    break;
                case 8:
                    NavigateTo(MenuItems.MenuItemsEnum.DataExport);
                    break;
                default:
                    break;
            }
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
