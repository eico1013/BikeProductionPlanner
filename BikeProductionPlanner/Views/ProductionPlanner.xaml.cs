using BikeProductionPlanner.Logic.Database;
using BikeProductionPlanner.Logic.Logic;
using BikeProductionPlanner.Logic.UI;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaction logic for ProductionPlanner.xaml
    /// </summary>
    public partial class ProductionPlanner : UserControl
    {
        public ProductionPlanner()
        {
            InitializeComponent();
        }

        public void UpdatePlanningFields()
        {
            StorageService storageService = StorageService.Instance;

            //Kinderfahrrad
            kind11.Text = storageService.vertriebswunschP1.ToString();
            kind31.Text = storageService.sicherheitsbestandP1.ToString();
            kind41.Text = storageService.GetWarehouseArticleById(1).Amount.ToString();
            kind51.Text = storageService.GetWorkplaceArticleAmountById(1).ToString();
            kind61.Text = storageService.GetOrderInWorkArticleAmountById(1).ToString();
            kind71.Text = ProductionPlan.p1.ToString();

            kind12.Text = ProductionPlan.p1.ToString();
            kind22.Text = storageService.GetWorkplaceArticleAmountById(1).ToString();
            kind32.Text = storageService.sicherheitsbestandE26K.ToString();
            kind42.Text = (storageService.GetWarehouseArticleById(26).Amount / 3).ToString();
            kind52.Text = (storageService.GetWorkplaceArticleAmountById(26) / 3).ToString();
            kind62.Text = (storageService.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            kind72.Text = ProductionPlan.e26K.ToString();

            kind13.Text = ProductionPlan.p1.ToString();
            kind23.Text = storageService.GetWorkplaceArticleAmountById(1).ToString();
            kind33.Text = storageService.sicherheitsbestandE51.ToString();
            kind43.Text = storageService.GetWarehouseArticleById(51).Amount.ToString();
            kind53.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind63.Text = storageService.GetOrderInWorkArticleAmountById(51).ToString();
            kind73.Text = ProductionPlan.e51.ToString();

            kind14.Text = ProductionPlan.e51.ToString();
            kind24.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind34.Text = storageService.sicherheitsbestandE16K.ToString();
            kind44.Text = (storageService.GetWarehouseArticleById(16).Amount / 3).ToString();
            kind54.Text = (storageService.GetWorkplaceArticleAmountById(16) / 3).ToString();
            kind64.Text = (storageService.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            kind74.Text = ProductionPlan.e16K.ToString();

            kind15.Text = ProductionPlan.e51.ToString();
            kind25.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind35.Text = storageService.sicherheitsbestandE17K.ToString();
            kind45.Text = (storageService.GetWarehouseArticleById(17).Amount / 3).ToString();
            kind55.Text = (storageService.GetWorkplaceArticleAmountById(17) / 3).ToString();
            kind65.Text = (storageService.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            kind75.Text = ProductionPlan.e17K.ToString();

            kind16.Text = ProductionPlan.e51.ToString();
            kind26.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind36.Text = storageService.sicherheitsbestandE50.ToString();
            kind46.Text = storageService.GetWarehouseArticleById(50).Amount.ToString();
            kind56.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind66.Text = storageService.GetOrderInWorkArticleAmountById(50).ToString();
            kind76.Text = ProductionPlan.e50.ToString();

            kind17.Text = ProductionPlan.e50.ToString();
            kind27.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind37.Text = storageService.sicherheitsbestandE4.ToString();
            kind47.Text = storageService.GetWarehouseArticleById(4).Amount.ToString();
            kind57.Text = storageService.GetWorkplaceArticleAmountById(4).ToString();
            kind67.Text = storageService.GetOrderInWorkArticleAmountById(4).ToString();
            kind77.Text = ProductionPlan.e4.ToString();

            kind18.Text = ProductionPlan.e50.ToString();
            kind28.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind38.Text = storageService.sicherheitsbestandE10.ToString();
            kind48.Text = storageService.GetWarehouseArticleById(10).Amount.ToString();
            kind58.Text = storageService.GetWorkplaceArticleAmountById(10).ToString();
            kind68.Text = storageService.GetOrderInWorkArticleAmountById(10).ToString();
            kind78.Text = ProductionPlan.e10.ToString();

            kind19.Text = ProductionPlan.e50.ToString();
            kind29.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind39.Text = storageService.sicherheitsbestandE49.ToString();
            kind49.Text = storageService.GetWarehouseArticleById(49).Amount.ToString();
            kind59.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind69.Text = storageService.GetOrderInWorkArticleAmountById(49).ToString();
            kind79.Text = ProductionPlan.e49.ToString();

            kind110.Text = ProductionPlan.e49.ToString();
            kind210.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind310.Text = storageService.sicherheitsbestandE7.ToString();
            kind410.Text = storageService.GetWarehouseArticleById(7).Amount.ToString();
            kind510.Text = storageService.GetWorkplaceArticleAmountById(7).ToString();
            kind610.Text = storageService.GetOrderInWorkArticleAmountById(7).ToString();
            kind710.Text = ProductionPlan.e7.ToString();

            kind111.Text = ProductionPlan.e49.ToString();
            kind211.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind311.Text = storageService.sicherheitsbestandE13.ToString();
            kind411.Text = storageService.GetWarehouseArticleById(13).Amount.ToString();
            kind511.Text = storageService.GetWorkplaceArticleAmountById(13).ToString();
            kind611.Text = storageService.GetOrderInWorkArticleAmountById(13).ToString();
            kind711.Text = ProductionPlan.e13.ToString();

            kind112.Text = ProductionPlan.e49.ToString();
            kind212.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind312.Text = storageService.sicherheitsbestandE18.ToString();
            kind412.Text = storageService.GetWarehouseArticleById(18).Amount.ToString();
            kind512.Text = storageService.GetWorkplaceArticleAmountById(18).ToString();
            kind612.Text = storageService.GetOrderInWorkArticleAmountById(18).ToString();
            kind712.Text = ProductionPlan.e18.ToString();


            //Damenfahrrad
            damen11.Text = storageService.vertriebswunschP2.ToString();
            damen31.Text = storageService.sicherheitsbestandP2.ToString();
            damen41.Text = storageService.GetWarehouseArticleById(2).Amount.ToString();
            damen51.Text = storageService.GetWorkplaceArticleAmountById(2).ToString();
            damen61.Text = storageService.GetOrderInWorkArticleAmountById(2).ToString();
            damen71.Text = ProductionPlan.p2.ToString();

            damen12.Text = ProductionPlan.p2.ToString();
            damen22.Text = storageService.GetWorkplaceArticleAmountById(2).ToString();
            damen32.Text = storageService.sicherheitsbestandE26D.ToString();
            damen42.Text = (storageService.GetWarehouseArticleById(26).Amount / 3).ToString();
            damen52.Text = (storageService.GetWorkplaceArticleAmountById(26) / 3).ToString();
            damen62.Text = (storageService.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            damen72.Text = ProductionPlan.e26D.ToString();

            damen13.Text = ProductionPlan.p2.ToString();
            damen23.Text = storageService.GetWorkplaceArticleAmountById(2).ToString();
            damen33.Text = storageService.sicherheitsbestandE56.ToString();
            damen43.Text = storageService.GetWarehouseArticleById(56).Amount.ToString();
            damen53.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen63.Text = storageService.GetOrderInWorkArticleAmountById(56).ToString();
            damen73.Text = ProductionPlan.e56.ToString();

            damen14.Text = ProductionPlan.e56.ToString();
            damen24.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen34.Text = storageService.sicherheitsbestandE16D.ToString();
            damen44.Text = (storageService.GetWarehouseArticleById(16).Amount / 3).ToString();
            damen54.Text = (storageService.GetWorkplaceArticleAmountById(16) / 3).ToString();
            damen64.Text = (storageService.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            damen74.Text = ProductionPlan.e16D.ToString();

            damen15.Text = ProductionPlan.e56.ToString();
            damen25.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen35.Text = storageService.sicherheitsbestandE17D.ToString();
            damen45.Text = (storageService.GetWarehouseArticleById(17).Amount / 3).ToString();
            damen55.Text = (storageService.GetWorkplaceArticleAmountById(17) / 3).ToString();
            damen65.Text = (storageService.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            damen75.Text = ProductionPlan.e17D.ToString();

            damen16.Text = ProductionPlan.e56.ToString();
            damen26.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen36.Text = storageService.sicherheitsbestandE55.ToString();
            damen46.Text = storageService.GetWarehouseArticleById(55).Amount.ToString();
            damen56.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen66.Text = storageService.GetOrderInWorkArticleAmountById(55).ToString();
            damen76.Text = ProductionPlan.e55.ToString();

            damen17.Text = ProductionPlan.e55.ToString();
            damen27.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen37.Text = storageService.sicherheitsbestandE5.ToString();
            damen47.Text = storageService.GetWarehouseArticleById(5).Amount.ToString();
            damen57.Text = storageService.GetWorkplaceArticleAmountById(5).ToString();
            damen67.Text = storageService.GetOrderInWorkArticleAmountById(5).ToString();
            damen77.Text = ProductionPlan.e5.ToString();

            damen18.Text = ProductionPlan.e55.ToString();
            damen28.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen38.Text = storageService.sicherheitsbestandE11.ToString();
            damen48.Text = storageService.GetWarehouseArticleById(11).Amount.ToString();
            damen58.Text = storageService.GetWorkplaceArticleAmountById(11).ToString();
            damen68.Text = storageService.GetOrderInWorkArticleAmountById(11).ToString();
            damen78.Text = ProductionPlan.e11.ToString();

            damen19.Text = ProductionPlan.e55.ToString();
            damen29.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen39.Text = storageService.sicherheitsbestandE54.ToString();
            damen49.Text = storageService.GetWarehouseArticleById(54).Amount.ToString();
            damen59.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen69.Text = storageService.GetOrderInWorkArticleAmountById(54).ToString();
            damen79.Text = ProductionPlan.e54.ToString();

            damen110.Text = ProductionPlan.e54.ToString();
            damen210.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen310.Text = storageService.sicherheitsbestandE8.ToString();
            damen410.Text = storageService.GetWarehouseArticleById(8).Amount.ToString();
            damen510.Text = storageService.GetWorkplaceArticleAmountById(8).ToString();
            damen610.Text = storageService.GetOrderInWorkArticleAmountById(8).ToString();
            damen710.Text = ProductionPlan.e8.ToString();

            damen111.Text = ProductionPlan.e54.ToString();
            damen211.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen311.Text = storageService.sicherheitsbestandE14.ToString();
            damen411.Text = storageService.GetWarehouseArticleById(14).Amount.ToString();
            damen511.Text = storageService.GetWorkplaceArticleAmountById(14).ToString();
            damen611.Text = storageService.GetOrderInWorkArticleAmountById(14).ToString();
            damen711.Text = ProductionPlan.e14.ToString();

            damen112.Text = ProductionPlan.e54.ToString();
            damen212.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen312.Text = storageService.sicherheitsbestandE19.ToString();
            damen412.Text = storageService.GetWarehouseArticleById(19).Amount.ToString();
            damen512.Text = storageService.GetWorkplaceArticleAmountById(19).ToString();
            damen612.Text = storageService.GetOrderInWorkArticleAmountById(19).ToString();
            damen712.Text = ProductionPlan.e19.ToString();


            //Herrenfahrrad
            herren11.Text = storageService.vertriebswunschP3.ToString();
            herren31.Text = storageService.sicherheitsbestandP3.ToString();
            herren41.Text = storageService.GetWarehouseArticleById(3).Amount.ToString();
            herren51.Text = storageService.GetWorkplaceArticleAmountById(3).ToString();
            herren61.Text = storageService.GetOrderInWorkArticleAmountById(3).ToString();
            herren71.Text = ProductionPlan.p3.ToString();

            herren12.Text = ProductionPlan.p3.ToString();
            herren22.Text = storageService.GetWorkplaceArticleAmountById(3).ToString();
            herren32.Text = storageService.sicherheitsbestandE26H.ToString();
            herren42.Text = (storageService.GetWarehouseArticleById(26).Amount / 3).ToString();
            herren52.Text = (storageService.GetWorkplaceArticleAmountById(26) / 3).ToString();
            herren62.Text = (storageService.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            herren72.Text = ProductionPlan.e26H.ToString();

            herren13.Text = ProductionPlan.p3.ToString();
            herren23.Text = storageService.GetWorkplaceArticleAmountById(3).ToString();
            herren33.Text = storageService.sicherheitsbestandE31.ToString();
            herren43.Text = storageService.GetWarehouseArticleById(31).Amount.ToString();
            herren53.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren63.Text = storageService.GetOrderInWorkArticleAmountById(31).ToString();
            herren73.Text = ProductionPlan.e31.ToString();

            herren14.Text = ProductionPlan.e31.ToString();
            herren24.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren34.Text = storageService.sicherheitsbestandE16H.ToString();
            herren44.Text = (storageService.GetWarehouseArticleById(16).Amount / 3).ToString();
            herren54.Text = (storageService.GetWorkplaceArticleAmountById(16) / 3).ToString();
            herren64.Text = (storageService.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            herren74.Text = ProductionPlan.e16H.ToString();

            herren15.Text = ProductionPlan.e31.ToString();
            herren25.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren35.Text = storageService.sicherheitsbestandE17H.ToString();
            herren45.Text = (storageService.GetWarehouseArticleById(17).Amount / 3).ToString();
            herren55.Text = (storageService.GetWorkplaceArticleAmountById(17) / 3).ToString();
            herren65.Text = (storageService.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            herren75.Text = ProductionPlan.e17H.ToString();

            herren16.Text = ProductionPlan.e31.ToString();
            herren26.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren36.Text = storageService.sicherheitsbestandE30.ToString();
            herren46.Text = storageService.GetWarehouseArticleById(30).Amount.ToString();
            herren56.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren66.Text = storageService.GetOrderInWorkArticleAmountById(30).ToString();
            herren76.Text = ProductionPlan.e30.ToString();

            herren17.Text = ProductionPlan.e30.ToString();
            herren27.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren37.Text = storageService.sicherheitsbestandE6.ToString();
            herren47.Text = storageService.GetWarehouseArticleById(6).Amount.ToString();
            herren57.Text = storageService.GetWorkplaceArticleAmountById(6).ToString();
            herren67.Text = storageService.GetOrderInWorkArticleAmountById(6).ToString();
            herren77.Text = ProductionPlan.e6.ToString();

            herren18.Text = ProductionPlan.e30.ToString();
            herren28.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren38.Text = storageService.sicherheitsbestandE12.ToString();
            herren48.Text = storageService.GetWarehouseArticleById(12).Amount.ToString();
            herren58.Text = storageService.GetWorkplaceArticleAmountById(12).ToString();
            herren68.Text = storageService.GetOrderInWorkArticleAmountById(12).ToString();
            herren78.Text = ProductionPlan.e12.ToString();

            herren19.Text = ProductionPlan.e30.ToString();
            herren29.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren39.Text = storageService.sicherheitsbestandE29.ToString();
            herren49.Text = storageService.GetWarehouseArticleById(29).Amount.ToString();
            herren59.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren69.Text = storageService.GetOrderInWorkArticleAmountById(29).ToString();
            herren79.Text = ProductionPlan.e29.ToString();

            herren110.Text = ProductionPlan.e29.ToString();
            herren210.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren310.Text = storageService.sicherheitsbestandE9.ToString();
            herren410.Text = storageService.GetWarehouseArticleById(9).Amount.ToString();
            herren510.Text = storageService.GetWorkplaceArticleAmountById(9).ToString();
            herren610.Text = storageService.GetOrderInWorkArticleAmountById(9).ToString();
            herren710.Text = ProductionPlan.e9.ToString();

            herren111.Text = ProductionPlan.e29.ToString();
            herren211.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren311.Text = storageService.sicherheitsbestandE15.ToString();
            herren411.Text = storageService.GetWarehouseArticleById(15).Amount.ToString();
            herren511.Text = storageService.GetWorkplaceArticleAmountById(15).ToString();
            herren611.Text = storageService.GetOrderInWorkArticleAmountById(15).ToString();
            herren711.Text = ProductionPlan.e15.ToString();

            herren112.Text = ProductionPlan.e29.ToString();
            herren212.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren312.Text = storageService.sicherheitsbestandE20.ToString();
            herren412.Text = storageService.GetWarehouseArticleById(20).Amount.ToString();
            herren512.Text = storageService.GetWorkplaceArticleAmountById(20).ToString();
            herren612.Text = storageService.GetOrderInWorkArticleAmountById(20).ToString();
            herren712.Text = ProductionPlan.e20.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageService vs = StorageService.Instance;

            StorageService.Instance.sicherheitsbestandP1 = Convert.ToInt32(kind31.Text);
            StorageService.Instance.sicherheitsbestandE26K = Convert.ToInt32(kind32.Text);
            StorageService.Instance.sicherheitsbestandE51 = Convert.ToInt32(kind33.Text);
            StorageService.Instance.sicherheitsbestandE16K = Convert.ToInt32(kind34.Text);
            StorageService.Instance.sicherheitsbestandE17K = Convert.ToInt32(kind35.Text);
            StorageService.Instance.sicherheitsbestandE50 = Convert.ToInt32(kind36.Text);
            StorageService.Instance.sicherheitsbestandE4 = Convert.ToInt32(kind37.Text);
            StorageService.Instance.sicherheitsbestandE10 = Convert.ToInt32(kind38.Text);
            StorageService.Instance.sicherheitsbestandE49 = Convert.ToInt32(kind39.Text);
            StorageService.Instance.sicherheitsbestandE7 = Convert.ToInt32(kind310.Text);
            StorageService.Instance.sicherheitsbestandE13 = Convert.ToInt32(kind311.Text);
            StorageService.Instance.sicherheitsbestandE18 = Convert.ToInt32(kind312.Text);

            StorageService.Instance.sicherheitsbestandP2 = Convert.ToInt32(damen31.Text);
            StorageService.Instance.sicherheitsbestandE26D = Convert.ToInt32(damen32.Text);
            StorageService.Instance.sicherheitsbestandE56 = Convert.ToInt32(damen33.Text);
            StorageService.Instance.sicherheitsbestandE16D = Convert.ToInt32(damen34.Text);
            StorageService.Instance.sicherheitsbestandE17D = Convert.ToInt32(damen35.Text);
            StorageService.Instance.sicherheitsbestandE55 = Convert.ToInt32(damen36.Text);
            StorageService.Instance.sicherheitsbestandE5 = Convert.ToInt32(damen37.Text);
            StorageService.Instance.sicherheitsbestandE11 = Convert.ToInt32(damen38.Text);
            StorageService.Instance.sicherheitsbestandE54 = Convert.ToInt32(damen39.Text);
            StorageService.Instance.sicherheitsbestandE8 = Convert.ToInt32(damen310.Text);
            StorageService.Instance.sicherheitsbestandE14 = Convert.ToInt32(damen311.Text);
            StorageService.Instance.sicherheitsbestandE19 = Convert.ToInt32(damen312.Text);

            StorageService.Instance.sicherheitsbestandP3 = Convert.ToInt32(herren31.Text);
            StorageService.Instance.sicherheitsbestandE26H = Convert.ToInt32(herren32.Text);
            StorageService.Instance.sicherheitsbestandE31 = Convert.ToInt32(herren33.Text);
            StorageService.Instance.sicherheitsbestandE16H = Convert.ToInt32(herren34.Text);
            StorageService.Instance.sicherheitsbestandE17H = Convert.ToInt32(herren35.Text);
            StorageService.Instance.sicherheitsbestandE30 = Convert.ToInt32(herren36.Text);
            StorageService.Instance.sicherheitsbestandE6 = Convert.ToInt32(herren37.Text);
            StorageService.Instance.sicherheitsbestandE12 = Convert.ToInt32(herren38.Text);
            StorageService.Instance.sicherheitsbestandE29 = Convert.ToInt32(herren39.Text);
            StorageService.Instance.sicherheitsbestandE9 = Convert.ToInt32(herren310.Text);
            StorageService.Instance.sicherheitsbestandE15 = Convert.ToInt32(herren311.Text);
            StorageService.Instance.sicherheitsbestandE20 = Convert.ToInt32(herren312.Text);

            #region Verbindliche Aufträge
            // Kinderfahrrad
            ProductionPlan.p1 = vs.vertriebswunschP1 + vs.sicherheitsbestandP1 - vs.GetWarehouseArticleById(1).Amount - vs.GetWorkplaceArticleAmountById(1) - vs.GetOrderInWorkArticleAmountById(1);
            ProductionPlan.p1 = ProductionPlan.p1 + ((10 - (ProductionPlan.p1 % 10)) % 10);
            if (ProductionPlan.p1 < 0) ProductionPlan.p1 = 0;

            ProductionPlan.e26K = ProductionPlan.p1 + vs.GetWorkplaceArticleAmountById(1) + vs.sicherheitsbestandE26K - (vs.GetWarehouseArticleById(26).Amount / 3 + vs.GetWorkplaceArticleAmountById(26) / 3 + vs.GetOrderInWorkArticleAmountById(26) / 3);
            ProductionPlan.e26K = ProductionPlan.e26K + ((10 - (ProductionPlan.e26K % 10)) % 10);
            if (ProductionPlan.e26K < 0) ProductionPlan.e26K = 0;
            ProductionPlan.e51 = ProductionPlan.p1 + vs.GetWorkplaceArticleAmountById(1) + vs.sicherheitsbestandE51 - (vs.GetWarehouseArticleById(51).Amount + vs.GetWorkplaceArticleAmountById(51) + vs.GetOrderInWorkArticleAmountById(51));
            ProductionPlan.e51 = ProductionPlan.e51 + ((10 - (ProductionPlan.e51 % 10)) % 10);
            if (ProductionPlan.e51 < 0) ProductionPlan.e51 = 0;

            ProductionPlan.e16K = ProductionPlan.e51 + vs.GetWorkplaceArticleAmountById(51) + vs.sicherheitsbestandE16K - (vs.GetWarehouseArticleById(16).Amount / 3 + vs.GetWorkplaceArticleAmountById(16) / 3 + vs.GetOrderInWorkArticleAmountById(16) / 3);
            ProductionPlan.e16K = ProductionPlan.e16K + ((10 - (ProductionPlan.e16K % 10)) % 10);
            if (ProductionPlan.e16K < 0) ProductionPlan.e16K = 0;
            ProductionPlan.e17K = ProductionPlan.e51 + vs.GetWorkplaceArticleAmountById(51) + vs.sicherheitsbestandE17K - (vs.GetWarehouseArticleById(17).Amount / 3 + vs.GetWorkplaceArticleAmountById(17) / 3 + vs.GetOrderInWorkArticleAmountById(17) / 3);
            ProductionPlan.e17K = ProductionPlan.e17K + ((10 - (ProductionPlan.e17K % 10)) % 10);
            if (ProductionPlan.e17K < 0) ProductionPlan.e17K = 0;
            ProductionPlan.e50 = ProductionPlan.e51 + vs.GetWorkplaceArticleAmountById(51) + vs.sicherheitsbestandE50 - (vs.GetWarehouseArticleById(50).Amount + vs.GetWorkplaceArticleAmountById(50) + vs.GetOrderInWorkArticleAmountById(50));
            ProductionPlan.e50 = ProductionPlan.e50 + ((10 - (ProductionPlan.e50 % 10)) % 10);
            if (ProductionPlan.e50 < 0) ProductionPlan.e50 = 0;

            ProductionPlan.e4 = ProductionPlan.e50 + vs.GetWorkplaceArticleAmountById(50) + vs.sicherheitsbestandE4 - (vs.GetWarehouseArticleById(4).Amount + vs.GetWorkplaceArticleAmountById(4) + vs.GetOrderInWorkArticleAmountById(4));
            ProductionPlan.e4 = ProductionPlan.e4 + ((10 - (ProductionPlan.e4 % 10)) % 10);
            if (ProductionPlan.e4 < 0) ProductionPlan.e4 = 0;
            ProductionPlan.e10 = ProductionPlan.e50 + vs.GetWorkplaceArticleAmountById(50) + vs.sicherheitsbestandE10 - (vs.GetWarehouseArticleById(10).Amount + vs.GetWorkplaceArticleAmountById(10) + vs.GetOrderInWorkArticleAmountById(10));
            ProductionPlan.e10 = ProductionPlan.e10 + ((10 - (ProductionPlan.e10 % 10)) % 10);
            if (ProductionPlan.e10 < 0) ProductionPlan.e10 = 0;
            ProductionPlan.e49 = ProductionPlan.e50 + vs.GetWorkplaceArticleAmountById(50) + vs.sicherheitsbestandE49 - (vs.GetWarehouseArticleById(49).Amount + vs.GetWorkplaceArticleAmountById(49) + vs.GetOrderInWorkArticleAmountById(49));
            ProductionPlan.e49 = ProductionPlan.e49 + ((10 - (ProductionPlan.e49 % 10)) % 10);
            if (ProductionPlan.e49 < 0) ProductionPlan.e49 = 0;

            ProductionPlan.e7 = ProductionPlan.e49 + vs.GetWorkplaceArticleAmountById(49) + vs.sicherheitsbestandE7 - (vs.GetWarehouseArticleById(7).Amount + vs.GetWorkplaceArticleAmountById(7) + vs.GetOrderInWorkArticleAmountById(7));
            ProductionPlan.e7 = ProductionPlan.e7 + ((10 - (ProductionPlan.e7 % 10)) % 10);
            if (ProductionPlan.e7 < 0) ProductionPlan.e7 = 0;
            ProductionPlan.e13 = ProductionPlan.e49 + vs.GetWorkplaceArticleAmountById(49) + vs.sicherheitsbestandE13 - (vs.GetWarehouseArticleById(13).Amount + vs.GetWorkplaceArticleAmountById(13) + vs.GetOrderInWorkArticleAmountById(13));
            ProductionPlan.e13 = ProductionPlan.e13 + ((10 - (ProductionPlan.e13 % 10)) % 10);
            if (ProductionPlan.e13 < 0) ProductionPlan.e13 = 0;
            ProductionPlan.e18 = ProductionPlan.e49 + vs.GetWorkplaceArticleAmountById(49) + vs.sicherheitsbestandE18 - (vs.GetWarehouseArticleById(18).Amount + vs.GetWorkplaceArticleAmountById(18) + vs.GetOrderInWorkArticleAmountById(18));
            ProductionPlan.e18 = ProductionPlan.e18 + ((10 - (ProductionPlan.e18 % 10)) % 10);
            if (ProductionPlan.e18 < 0) ProductionPlan.e18 = 0;

            // Damenfahrrad
            ProductionPlan.p2 = vs.vertriebswunschP2 + vs.sicherheitsbestandP2 - vs.GetWarehouseArticleById(2).Amount - vs.GetWorkplaceArticleAmountById(2) - vs.GetOrderInWorkArticleAmountById(2);
            ProductionPlan.p2 = ProductionPlan.p2 + ((10 - (ProductionPlan.p2 % 10)) % 10);
            if (ProductionPlan.p2 < 0) ProductionPlan.p2 = 0;

            ProductionPlan.e26D = ProductionPlan.p2 + vs.GetWorkplaceArticleAmountById(2) + vs.sicherheitsbestandE26D - (vs.GetWarehouseArticleById(26).Amount / 3 + vs.GetWorkplaceArticleAmountById(26) / 3 + vs.GetOrderInWorkArticleAmountById(26) / 3);
            ProductionPlan.e26D = ProductionPlan.e26D + ((10 - (ProductionPlan.e26D % 10)) % 10);
            if (ProductionPlan.e26D < 0) ProductionPlan.e26D = 0;
            ProductionPlan.e56 = ProductionPlan.p2 + vs.GetWorkplaceArticleAmountById(2) + vs.sicherheitsbestandE56 - (vs.GetWarehouseArticleById(56).Amount + vs.GetWorkplaceArticleAmountById(56) + vs.GetOrderInWorkArticleAmountById(56));
            ProductionPlan.e56 = ProductionPlan.e56 + ((10 - (ProductionPlan.e56 % 10)) % 10);
            if (ProductionPlan.e56 < 0) ProductionPlan.e56 = 0;

            ProductionPlan.e16D = ProductionPlan.e56 + vs.GetWorkplaceArticleAmountById(56) + vs.sicherheitsbestandE16D - (vs.GetWarehouseArticleById(16).Amount / 3 + vs.GetWorkplaceArticleAmountById(16) / 3 + vs.GetOrderInWorkArticleAmountById(16) / 3);
            ProductionPlan.e16D = ProductionPlan.e16D + ((10 - (ProductionPlan.e16D % 10)) % 10);
            if (ProductionPlan.e16D < 0) ProductionPlan.e16D = 0;
            ProductionPlan.e17D = ProductionPlan.e56 + vs.GetWorkplaceArticleAmountById(56) + vs.sicherheitsbestandE17D - (vs.GetWarehouseArticleById(17).Amount / 3 + vs.GetWorkplaceArticleAmountById(17) / 3 + vs.GetOrderInWorkArticleAmountById(17) / 3);
            ProductionPlan.e17D = ProductionPlan.e17D + ((10 - (ProductionPlan.e17D % 10)) % 10);
            if (ProductionPlan.e17D < 0) ProductionPlan.e17D = 0;
            ProductionPlan.e55 = ProductionPlan.e56 + vs.GetWorkplaceArticleAmountById(56) + vs.sicherheitsbestandE55 - (vs.GetWarehouseArticleById(55).Amount + vs.GetWorkplaceArticleAmountById(55) + vs.GetOrderInWorkArticleAmountById(55));
            ProductionPlan.e55 = ProductionPlan.e55 + ((10 - (ProductionPlan.e55 % 10)) % 10);
            if (ProductionPlan.e55 < 0) ProductionPlan.e55 = 0;

            ProductionPlan.e5 = ProductionPlan.e55 + vs.GetWorkplaceArticleAmountById(55) + vs.sicherheitsbestandE5 - (vs.GetWarehouseArticleById(5).Amount + vs.GetWorkplaceArticleAmountById(5) + vs.GetOrderInWorkArticleAmountById(5));
            ProductionPlan.e5 = ProductionPlan.e5 + ((10 - (ProductionPlan.e5 % 10)) % 10);
            if (ProductionPlan.e5 < 0) ProductionPlan.e5 = 0;
            ProductionPlan.e11 = ProductionPlan.e55 + vs.GetWorkplaceArticleAmountById(55) + vs.sicherheitsbestandE11 - (vs.GetWarehouseArticleById(11).Amount + vs.GetWorkplaceArticleAmountById(11) + vs.GetOrderInWorkArticleAmountById(11));
            ProductionPlan.e11 = ProductionPlan.e11 + ((10 - (ProductionPlan.e11 % 10)) % 10);
            if (ProductionPlan.e11 < 0) ProductionPlan.e11 = 0;
            ProductionPlan.e54 = ProductionPlan.e55 + vs.GetWorkplaceArticleAmountById(55) + vs.sicherheitsbestandE54 - (vs.GetWarehouseArticleById(54).Amount + vs.GetWorkplaceArticleAmountById(54) + vs.GetOrderInWorkArticleAmountById(54));
            ProductionPlan.e54 = ProductionPlan.e54 + ((10 - (ProductionPlan.e54 % 10)) % 10);
            if (ProductionPlan.e54 < 0) ProductionPlan.e54 = 0;

            ProductionPlan.e8 = ProductionPlan.e54 + vs.GetWorkplaceArticleAmountById(54) + vs.sicherheitsbestandE8 - (vs.GetWarehouseArticleById(8).Amount + vs.GetWorkplaceArticleAmountById(8) + vs.GetOrderInWorkArticleAmountById(8));
            ProductionPlan.e8 = ProductionPlan.e8 + ((10 - (ProductionPlan.e8 % 10)) % 10);
            if (ProductionPlan.e8 < 0) ProductionPlan.e8 = 0;
            ProductionPlan.e14 = ProductionPlan.e54 + vs.GetWorkplaceArticleAmountById(54) + vs.sicherheitsbestandE14 - (vs.GetWarehouseArticleById(14).Amount + vs.GetWorkplaceArticleAmountById(14) + vs.GetOrderInWorkArticleAmountById(14));
            ProductionPlan.e14 = ProductionPlan.e14 + ((10 - (ProductionPlan.e14 % 10)) % 10);
            if (ProductionPlan.e14 < 0) ProductionPlan.e14 = 0;
            ProductionPlan.e19 = ProductionPlan.e54 + vs.GetWorkplaceArticleAmountById(54) + vs.sicherheitsbestandE19 - (vs.GetWarehouseArticleById(19).Amount + vs.GetWorkplaceArticleAmountById(19) + vs.GetOrderInWorkArticleAmountById(19));
            ProductionPlan.e19 = ProductionPlan.e19 + ((10 - (ProductionPlan.e19 % 10)) % 10);
            if (ProductionPlan.e19 < 0) ProductionPlan.e19 = 0;

            // Herrenfahrrad
            ProductionPlan.p3 = vs.vertriebswunschP3 + vs.sicherheitsbestandP3 - vs.GetWarehouseArticleById(3).Amount - vs.GetWorkplaceArticleAmountById(3) - vs.GetOrderInWorkArticleAmountById(3);
            ProductionPlan.p3 = ProductionPlan.p3 + ((10 - (ProductionPlan.p3 % 10)) % 10);
            if (ProductionPlan.p3 < 0) ProductionPlan.p3 = 0;

            ProductionPlan.e26H = ProductionPlan.p3 + vs.GetWorkplaceArticleAmountById(3) + vs.sicherheitsbestandE26H - (vs.GetWarehouseArticleById(26).Amount / 3 + vs.GetWorkplaceArticleAmountById(26) / 3 + vs.GetOrderInWorkArticleAmountById(26) / 3);
            ProductionPlan.e26H = ProductionPlan.e26H + ((10 - (ProductionPlan.e26H % 10)) % 10);
            if (ProductionPlan.e26H < 0) ProductionPlan.e26H = 0;
            ProductionPlan.e31 = ProductionPlan.p3 + vs.GetWorkplaceArticleAmountById(3) + vs.sicherheitsbestandE31 - (vs.GetWarehouseArticleById(31).Amount + vs.GetWorkplaceArticleAmountById(31) + vs.GetOrderInWorkArticleAmountById(31));
            ProductionPlan.e31 = ProductionPlan.e31 + ((10 - (ProductionPlan.e31 % 10)) % 10);
            if (ProductionPlan.e31 < 0) ProductionPlan.e31 = 0;

            ProductionPlan.e16H = ProductionPlan.e31 + vs.GetWorkplaceArticleAmountById(31) + vs.sicherheitsbestandE16H - (vs.GetWarehouseArticleById(16).Amount / 3 + vs.GetWorkplaceArticleAmountById(16) / 3 + vs.GetOrderInWorkArticleAmountById(16) / 3);
            ProductionPlan.e16H = ProductionPlan.e16H + ((10 - (ProductionPlan.e16H % 10)) % 10);
            if (ProductionPlan.e16H < 0) ProductionPlan.e16H = 0;
            //System.Windows.MessageBox.Show(e31 + " + " + vs.GetWorkplaceArticleAmountById(31) + " + " + vs.sicherheitsbestandP3 + " - (" + (vs.GetWarehouseArticleById(17).Amount / 3 + " + "  + vs.GetWorkplaceArticleAmountById(17) / 3 + " + " + vs.GetOrderInWorkArticleAmountById(17) / 3) + ")");
            ProductionPlan.e17H = ProductionPlan.e31 + vs.GetWorkplaceArticleAmountById(31) + vs.sicherheitsbestandE17H - (vs.GetWarehouseArticleById(17).Amount / 3 + vs.GetWorkplaceArticleAmountById(17) / 3 + vs.GetOrderInWorkArticleAmountById(17) / 3);
            ProductionPlan.e17H = ProductionPlan.e17H + ((10 - (ProductionPlan.e17H % 10)) % 10);
            if (ProductionPlan.e17H < 0) ProductionPlan.e17H = 0;
            ProductionPlan.e30 = ProductionPlan.e31 + vs.GetWorkplaceArticleAmountById(31) + vs.sicherheitsbestandE30 - (vs.GetWarehouseArticleById(30).Amount + vs.GetWorkplaceArticleAmountById(30) + vs.GetOrderInWorkArticleAmountById(30));
            ProductionPlan.e30 = ProductionPlan.e30 + ((10 - (ProductionPlan.e30 % 10)) % 10);
            if (ProductionPlan.e30 < 0) ProductionPlan.e30 = 0;

            ProductionPlan.e6 = ProductionPlan.e30 + vs.GetWorkplaceArticleAmountById(30) + vs.sicherheitsbestandE6 - (vs.GetWarehouseArticleById(6).Amount + vs.GetWorkplaceArticleAmountById(6) + vs.GetOrderInWorkArticleAmountById(6));
            ProductionPlan.e6 = ProductionPlan.e6 + ((10 - (ProductionPlan.e6 % 10)) % 10);
            if (ProductionPlan.e6 < 0) ProductionPlan.e6 = 0;
            ProductionPlan.e12 = ProductionPlan.e30 + vs.GetWorkplaceArticleAmountById(30) + vs.sicherheitsbestandE12 - (vs.GetWarehouseArticleById(12).Amount + vs.GetWorkplaceArticleAmountById(12) + vs.GetOrderInWorkArticleAmountById(12));
            ProductionPlan.e12 = ProductionPlan.e12 + ((10 - (ProductionPlan.e12 % 10)) % 10);
            if (ProductionPlan.e12 < 0) ProductionPlan.e12 = 0;
            ProductionPlan.e29 = ProductionPlan.e30 + vs.GetWorkplaceArticleAmountById(30) + vs.sicherheitsbestandE29 - (vs.GetWarehouseArticleById(29).Amount + vs.GetWorkplaceArticleAmountById(29) + vs.GetOrderInWorkArticleAmountById(29));
            ProductionPlan.e29 = ProductionPlan.e29 + ((10 - (ProductionPlan.e29 % 10)) % 10);
            if (ProductionPlan.e29 < 0) ProductionPlan.e29 = 0;

            ProductionPlan.e9 = ProductionPlan.e29 + vs.GetWorkplaceArticleAmountById(29) + vs.sicherheitsbestandE9 - (vs.GetWarehouseArticleById(9).Amount + vs.GetWorkplaceArticleAmountById(9) + vs.GetOrderInWorkArticleAmountById(9));
            ProductionPlan.e9 = ProductionPlan.e9 + ((10 - (ProductionPlan.e9 % 10)) % 10);
            if (ProductionPlan.e9 < 0) ProductionPlan.e9 = 0;
            ProductionPlan.e15 = ProductionPlan.e29 + vs.GetWorkplaceArticleAmountById(29) + vs.sicherheitsbestandE15 - (vs.GetWarehouseArticleById(15).Amount + vs.GetWorkplaceArticleAmountById(15) + vs.GetOrderInWorkArticleAmountById(15));
            ProductionPlan.e15 = ProductionPlan.e15 + ((10 - (ProductionPlan.e15 % 10)) % 10);
            if (ProductionPlan.e15 < 0) ProductionPlan.e15 = 0;
            ProductionPlan.e20 = ProductionPlan.e29 + vs.GetWorkplaceArticleAmountById(29) + vs.sicherheitsbestandE20 - (vs.GetWarehouseArticleById(20).Amount + vs.GetWorkplaceArticleAmountById(20) + vs.GetOrderInWorkArticleAmountById(20));
            ProductionPlan.e20 = ProductionPlan.e20 + ((10 - (ProductionPlan.e20 % 10)) % 10);
            if (ProductionPlan.e20 < 0) ProductionPlan.e20 = 0;

            #endregion

            #region Kaufteile

            ProductionPlan.k21 = ProductionPlan.p1;
            ProductionPlan.k22 = ProductionPlan.p2;
            ProductionPlan.k23 = ProductionPlan.p3;
            ProductionPlan.k24 = ProductionPlan.p3 + ProductionPlan.e31 + ProductionPlan.e16H + ProductionPlan.e16D + ProductionPlan.e16K + 2 * ProductionPlan.e30 + 2 * ProductionPlan.e29 + ProductionPlan.p1 + ProductionPlan.e51 + 2 * ProductionPlan.e50 + 2 * ProductionPlan.e49 + ProductionPlan.p2 + ProductionPlan.e56 + 2 * ProductionPlan.e55 + 2 * ProductionPlan.e54;
            ProductionPlan.k25 = 2 * ProductionPlan.e50 + 2 * ProductionPlan.e49 + 2 * ProductionPlan.e55 + 2 * ProductionPlan.e54 + 2 * ProductionPlan.e30 + 2 * ProductionPlan.e29;
            ProductionPlan.k27 = ProductionPlan.p1 + ProductionPlan.e51 + ProductionPlan.p2 + ProductionPlan.e56 + ProductionPlan.p3 + ProductionPlan.e31;
            ProductionPlan.k28 = ProductionPlan.e16D + ProductionPlan.e16H + ProductionPlan.e16K + 3 * ProductionPlan.e18 + 4 * ProductionPlan.e19 + 5 * ProductionPlan.e20;
            ProductionPlan.k32 = ProductionPlan.e10 + ProductionPlan.e13 + ProductionPlan.e18 + ProductionPlan.e11 + ProductionPlan.e14 + ProductionPlan.e19 + ProductionPlan.e12 + ProductionPlan.e15 + ProductionPlan.e20;
            ProductionPlan.k33 = ProductionPlan.e6 + ProductionPlan.e9;
            ProductionPlan.k34 = 36 * ProductionPlan.e6 + 36 * ProductionPlan.e9;
            ProductionPlan.k35 = 2 * ProductionPlan.e4 + 2 * ProductionPlan.e7 + 2 * ProductionPlan.e5 + 2 * ProductionPlan.e8 + 2 * ProductionPlan.e6 + 2 * ProductionPlan.e9;
            ProductionPlan.k36 = ProductionPlan.e4 + ProductionPlan.e5 + ProductionPlan.e6;
            ProductionPlan.k37 = ProductionPlan.e7 + ProductionPlan.e8 + ProductionPlan.e9;
            ProductionPlan.k38 = ProductionPlan.e7 + ProductionPlan.e8 + ProductionPlan.e9;
            ProductionPlan.k39 = ProductionPlan.e10 + ProductionPlan.e13 + ProductionPlan.e11 + ProductionPlan.e14 + ProductionPlan.e12 + ProductionPlan.e15;
            ProductionPlan.k40 = ProductionPlan.e16K + ProductionPlan.e16H + ProductionPlan.e16D;
            ProductionPlan.k41 = ProductionPlan.e16K + ProductionPlan.e16H + ProductionPlan.e16D;
            ProductionPlan.k42 = 2 * ProductionPlan.e16K + 2 * ProductionPlan.e16H + 2 * ProductionPlan.e16D;
            ProductionPlan.k43 = ProductionPlan.e17K + ProductionPlan.e17H + ProductionPlan.e17D;
            ProductionPlan.k44 = 2 * ProductionPlan.e26K + 2 * ProductionPlan.e26H + 2 * ProductionPlan.e26D + ProductionPlan.e17K + ProductionPlan.e17H + ProductionPlan.e17D;
            ProductionPlan.k45 = ProductionPlan.e17K + ProductionPlan.e17H + ProductionPlan.e17D;
            ProductionPlan.k46 = ProductionPlan.e17K + ProductionPlan.e17H + ProductionPlan.e17D;
            ProductionPlan.k47 = ProductionPlan.e26K + ProductionPlan.e26H + ProductionPlan.e26D;
            ProductionPlan.k48 = 2 * ProductionPlan.e26K + 2 * ProductionPlan.e26H + 2 * ProductionPlan.e26D;
            ProductionPlan.k52 = ProductionPlan.e4 + ProductionPlan.e7;
            ProductionPlan.k53 = 36 * ProductionPlan.e4 + 36 * ProductionPlan.e7;
            ProductionPlan.k57 = ProductionPlan.e5 + ProductionPlan.e8;
            ProductionPlan.k58 = 36 * ProductionPlan.e5 + 36 * ProductionPlan.e8;
            ProductionPlan.k59 = 2 * ProductionPlan.e18 + 2 * ProductionPlan.e19 + 2 * ProductionPlan.e20;

            #endregion

            //Kinderfahrrad
            kind11.Text = vs.vertriebswunschP1.ToString();
            kind31.Text = vs.sicherheitsbestandP1.ToString();
            kind41.Text = vs.GetWarehouseArticleById(1).Amount.ToString();
            kind51.Text = vs.GetWorkplaceArticleAmountById(1).ToString();
            kind61.Text = vs.GetOrderInWorkArticleAmountById(1).ToString();
            kind71.Text = ProductionPlan.p1.ToString();

            kind12.Text = ProductionPlan.p1.ToString();
            kind22.Text = vs.GetWorkplaceArticleAmountById(1).ToString();
            kind32.Text = vs.sicherheitsbestandE26K.ToString();
            kind42.Text = (vs.GetWarehouseArticleById(26).Amount / 3).ToString();
            kind52.Text = (vs.GetWorkplaceArticleAmountById(26) / 3).ToString();
            kind62.Text = (vs.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            kind72.Text = ProductionPlan.e26K.ToString();

            kind13.Text = ProductionPlan.p1.ToString();
            kind23.Text = vs.GetWorkplaceArticleAmountById(1).ToString();
            kind33.Text = vs.sicherheitsbestandE51.ToString();
            kind43.Text = vs.GetWarehouseArticleById(51).Amount.ToString();
            kind53.Text = vs.GetWorkplaceArticleAmountById(51).ToString();
            kind63.Text = vs.GetOrderInWorkArticleAmountById(51).ToString();
            kind73.Text = ProductionPlan.e51.ToString();

            kind14.Text = ProductionPlan.e51.ToString();
            kind24.Text = vs.GetWorkplaceArticleAmountById(51).ToString();
            kind34.Text = vs.sicherheitsbestandE16K.ToString();
            kind44.Text = (vs.GetWarehouseArticleById(16).Amount / 3).ToString();
            kind54.Text = (vs.GetWorkplaceArticleAmountById(16) / 3).ToString();
            kind64.Text = (vs.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            kind74.Text = ProductionPlan.e16K.ToString();

            kind15.Text = ProductionPlan.e51.ToString();
            kind25.Text = vs.GetWorkplaceArticleAmountById(51).ToString();
            kind35.Text = vs.sicherheitsbestandE17K.ToString();
            kind45.Text = (vs.GetWarehouseArticleById(17).Amount / 3).ToString();
            kind55.Text = (vs.GetWorkplaceArticleAmountById(17) / 3).ToString();
            kind65.Text = (vs.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            kind75.Text = ProductionPlan.e17K.ToString();

            kind16.Text = ProductionPlan.e51.ToString();
            kind26.Text = vs.GetWorkplaceArticleAmountById(51).ToString();
            kind36.Text = vs.sicherheitsbestandE50.ToString();
            kind46.Text = vs.GetWarehouseArticleById(50).Amount.ToString();
            kind56.Text = vs.GetWorkplaceArticleAmountById(50).ToString();
            kind66.Text = vs.GetOrderInWorkArticleAmountById(50).ToString();
            kind76.Text = ProductionPlan.e50.ToString();

            kind17.Text = ProductionPlan.e50.ToString();
            kind27.Text = vs.GetWorkplaceArticleAmountById(50).ToString();
            kind37.Text = vs.sicherheitsbestandE4.ToString();
            kind47.Text = vs.GetWarehouseArticleById(4).Amount.ToString();
            kind57.Text = vs.GetWorkplaceArticleAmountById(4).ToString();
            kind67.Text = vs.GetOrderInWorkArticleAmountById(4).ToString();
            kind77.Text = ProductionPlan.e4.ToString();

            kind18.Text = ProductionPlan.e50.ToString();
            kind28.Text = vs.GetWorkplaceArticleAmountById(50).ToString();
            kind38.Text = vs.sicherheitsbestandE10.ToString();
            kind48.Text = vs.GetWarehouseArticleById(10).Amount.ToString();
            kind58.Text = vs.GetWorkplaceArticleAmountById(10).ToString();
            kind68.Text = vs.GetOrderInWorkArticleAmountById(10).ToString();
            kind78.Text = ProductionPlan.e10.ToString();

            kind19.Text = ProductionPlan.e50.ToString();
            kind29.Text = vs.GetWorkplaceArticleAmountById(50).ToString();
            kind39.Text = vs.sicherheitsbestandE49.ToString();
            kind49.Text = vs.GetWarehouseArticleById(49).Amount.ToString();
            kind59.Text = vs.GetWorkplaceArticleAmountById(49).ToString();
            kind69.Text = vs.GetOrderInWorkArticleAmountById(49).ToString();
            kind79.Text = ProductionPlan.e49.ToString();

            kind110.Text = ProductionPlan.e49.ToString();
            kind210.Text = vs.GetWorkplaceArticleAmountById(49).ToString();
            kind310.Text = vs.sicherheitsbestandE7.ToString();
            kind410.Text = vs.GetWarehouseArticleById(7).Amount.ToString();
            kind510.Text = vs.GetWorkplaceArticleAmountById(7).ToString();
            kind610.Text = vs.GetOrderInWorkArticleAmountById(7).ToString();
            kind710.Text = ProductionPlan.e7.ToString();

            kind111.Text = ProductionPlan.e49.ToString();
            kind211.Text = vs.GetWorkplaceArticleAmountById(49).ToString();
            kind311.Text = vs.sicherheitsbestandE13.ToString();
            kind411.Text = vs.GetWarehouseArticleById(13).Amount.ToString();
            kind511.Text = vs.GetWorkplaceArticleAmountById(13).ToString();
            kind611.Text = vs.GetOrderInWorkArticleAmountById(13).ToString();
            kind711.Text = ProductionPlan.e13.ToString();

            kind112.Text = ProductionPlan.e49.ToString();
            kind212.Text = vs.GetWorkplaceArticleAmountById(49).ToString();
            kind312.Text = vs.sicherheitsbestandE18.ToString();
            kind412.Text = vs.GetWarehouseArticleById(18).Amount.ToString();
            kind512.Text = vs.GetWorkplaceArticleAmountById(18).ToString();
            kind612.Text = vs.GetOrderInWorkArticleAmountById(18).ToString();
            kind712.Text = ProductionPlan.e18.ToString();


            //Damenfahrrad
            damen11.Text = vs.vertriebswunschP2.ToString();
            damen31.Text = vs.sicherheitsbestandP2.ToString();
            damen41.Text = vs.GetWarehouseArticleById(2).Amount.ToString();
            damen51.Text = vs.GetWorkplaceArticleAmountById(2).ToString();
            damen61.Text = vs.GetOrderInWorkArticleAmountById(2).ToString();
            damen71.Text = ProductionPlan.p2.ToString();

            damen12.Text = ProductionPlan.p2.ToString();
            damen22.Text = vs.GetWorkplaceArticleAmountById(2).ToString();
            damen32.Text = vs.sicherheitsbestandE26D.ToString();
            damen42.Text = (vs.GetWarehouseArticleById(26).Amount / 3).ToString();
            damen52.Text = (vs.GetWorkplaceArticleAmountById(26) / 3).ToString();
            damen62.Text = (vs.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            damen72.Text = ProductionPlan.e26D.ToString();

            damen13.Text = ProductionPlan.p2.ToString();
            damen23.Text = vs.GetWorkplaceArticleAmountById(2).ToString();
            damen33.Text = vs.sicherheitsbestandE56.ToString();
            damen43.Text = vs.GetWarehouseArticleById(56).Amount.ToString();
            damen53.Text = vs.GetWorkplaceArticleAmountById(56).ToString();
            damen63.Text = vs.GetOrderInWorkArticleAmountById(56).ToString();
            damen73.Text = ProductionPlan.e56.ToString();

            damen14.Text = ProductionPlan.e56.ToString();
            damen24.Text = vs.GetWorkplaceArticleAmountById(56).ToString();
            damen34.Text = vs.sicherheitsbestandE16D.ToString();
            damen44.Text = (vs.GetWarehouseArticleById(16).Amount / 3).ToString();
            damen54.Text = (vs.GetWorkplaceArticleAmountById(16) / 3).ToString();
            damen64.Text = (vs.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            damen74.Text = ProductionPlan.e16D.ToString();

            damen15.Text = ProductionPlan.e56.ToString();
            damen25.Text = vs.GetWorkplaceArticleAmountById(56).ToString();
            damen35.Text = vs.sicherheitsbestandE17D.ToString();
            damen45.Text = (vs.GetWarehouseArticleById(17).Amount / 3).ToString();
            damen55.Text = (vs.GetWorkplaceArticleAmountById(17) / 3).ToString();
            damen65.Text = (vs.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            damen75.Text = ProductionPlan.e17D.ToString();

            damen16.Text = ProductionPlan.e56.ToString();
            damen26.Text = vs.GetWorkplaceArticleAmountById(56).ToString();
            damen36.Text = vs.sicherheitsbestandE55.ToString();
            damen46.Text = vs.GetWarehouseArticleById(55).Amount.ToString();
            damen56.Text = vs.GetWorkplaceArticleAmountById(55).ToString();
            damen66.Text = vs.GetOrderInWorkArticleAmountById(55).ToString();
            damen76.Text = ProductionPlan.e55.ToString();

            damen17.Text = ProductionPlan.e55.ToString();
            damen27.Text = vs.GetWorkplaceArticleAmountById(55).ToString();
            damen37.Text = vs.sicherheitsbestandE5.ToString();
            damen47.Text = vs.GetWarehouseArticleById(5).Amount.ToString();
            damen57.Text = vs.GetWorkplaceArticleAmountById(5).ToString();
            damen67.Text = vs.GetOrderInWorkArticleAmountById(5).ToString();
            damen77.Text = ProductionPlan.e5.ToString();

            damen18.Text = ProductionPlan.e55.ToString();
            damen28.Text = vs.GetWorkplaceArticleAmountById(55).ToString();
            damen38.Text = vs.sicherheitsbestandE11.ToString();
            damen48.Text = vs.GetWarehouseArticleById(11).Amount.ToString();
            damen58.Text = vs.GetWorkplaceArticleAmountById(11).ToString();
            damen68.Text = vs.GetOrderInWorkArticleAmountById(11).ToString();
            damen78.Text = ProductionPlan.e11.ToString();

            damen19.Text = ProductionPlan.e55.ToString();
            damen29.Text = vs.GetWorkplaceArticleAmountById(55).ToString();
            damen39.Text = vs.sicherheitsbestandE54.ToString();
            damen49.Text = vs.GetWarehouseArticleById(54).Amount.ToString();
            damen59.Text = vs.GetWorkplaceArticleAmountById(54).ToString();
            damen69.Text = vs.GetOrderInWorkArticleAmountById(54).ToString();
            damen79.Text = ProductionPlan.e54.ToString();

            damen110.Text = ProductionPlan.e54.ToString();
            damen210.Text = vs.GetWorkplaceArticleAmountById(54).ToString();
            damen310.Text = vs.sicherheitsbestandE8.ToString();
            damen410.Text = vs.GetWarehouseArticleById(8).Amount.ToString();
            damen510.Text = vs.GetWorkplaceArticleAmountById(8).ToString();
            damen610.Text = vs.GetOrderInWorkArticleAmountById(8).ToString();
            damen710.Text = ProductionPlan.e8.ToString();

            damen111.Text = ProductionPlan.e54.ToString();
            damen211.Text = vs.GetWorkplaceArticleAmountById(54).ToString();
            damen311.Text = vs.sicherheitsbestandE14.ToString();
            damen411.Text = vs.GetWarehouseArticleById(14).Amount.ToString();
            damen511.Text = vs.GetWorkplaceArticleAmountById(14).ToString();
            damen611.Text = vs.GetOrderInWorkArticleAmountById(14).ToString();
            damen711.Text = ProductionPlan.e14.ToString();

            damen112.Text = ProductionPlan.e54.ToString();
            damen212.Text = vs.GetWorkplaceArticleAmountById(54).ToString();
            damen312.Text = vs.sicherheitsbestandE19.ToString();
            damen412.Text = vs.GetWarehouseArticleById(19).Amount.ToString();
            damen512.Text = vs.GetWorkplaceArticleAmountById(19).ToString();
            damen612.Text = vs.GetOrderInWorkArticleAmountById(19).ToString();
            damen712.Text = ProductionPlan.e19.ToString();


            //Herrenfahrrad
            herren11.Text = vs.vertriebswunschP3.ToString();
            herren31.Text = vs.sicherheitsbestandP3.ToString();
            herren41.Text = vs.GetWarehouseArticleById(3).Amount.ToString();
            herren51.Text = vs.GetWorkplaceArticleAmountById(3).ToString();
            herren61.Text = vs.GetOrderInWorkArticleAmountById(3).ToString();
            herren71.Text = ProductionPlan.p3.ToString();

            herren12.Text = ProductionPlan.p3.ToString();
            herren22.Text = vs.GetWorkplaceArticleAmountById(3).ToString();
            herren32.Text = vs.sicherheitsbestandE26H.ToString();
            herren42.Text = (vs.GetWarehouseArticleById(26).Amount / 3).ToString();
            herren52.Text = (vs.GetWorkplaceArticleAmountById(26) / 3).ToString();
            herren62.Text = (vs.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            herren72.Text = ProductionPlan.e26H.ToString();

            herren13.Text = ProductionPlan.p3.ToString();
            herren23.Text = vs.GetWorkplaceArticleAmountById(3).ToString();
            herren33.Text = vs.sicherheitsbestandE31.ToString();
            herren43.Text = vs.GetWarehouseArticleById(31).Amount.ToString();
            herren53.Text = vs.GetWorkplaceArticleAmountById(31).ToString();
            herren63.Text = vs.GetOrderInWorkArticleAmountById(31).ToString();
            herren73.Text = ProductionPlan.e31.ToString();

            herren14.Text = ProductionPlan.e31.ToString();
            herren24.Text = vs.GetWorkplaceArticleAmountById(31).ToString();
            herren34.Text = vs.sicherheitsbestandE16H.ToString();
            herren44.Text = (vs.GetWarehouseArticleById(16).Amount / 3).ToString();
            herren54.Text = (vs.GetWorkplaceArticleAmountById(16) / 3).ToString();
            herren64.Text = (vs.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            herren74.Text = ProductionPlan.e16H.ToString();

            herren15.Text = ProductionPlan.e31.ToString();
            herren25.Text = vs.GetWorkplaceArticleAmountById(31).ToString();
            herren35.Text = vs.sicherheitsbestandE17H.ToString();
            herren45.Text = (vs.GetWarehouseArticleById(17).Amount / 3).ToString();
            herren55.Text = (vs.GetWorkplaceArticleAmountById(17) / 3).ToString();
            herren65.Text = (vs.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            herren75.Text = ProductionPlan.e17H.ToString();

            herren16.Text = ProductionPlan.e31.ToString();
            herren26.Text = vs.GetWorkplaceArticleAmountById(31).ToString();
            herren36.Text = vs.sicherheitsbestandE30.ToString();
            herren46.Text = vs.GetWarehouseArticleById(30).Amount.ToString();
            herren56.Text = vs.GetWorkplaceArticleAmountById(30).ToString();
            herren66.Text = vs.GetOrderInWorkArticleAmountById(30).ToString();
            herren76.Text = ProductionPlan.e30.ToString();

            herren17.Text = ProductionPlan.e30.ToString();
            herren27.Text = vs.GetWorkplaceArticleAmountById(30).ToString();
            herren37.Text = vs.sicherheitsbestandE6.ToString();
            herren47.Text = vs.GetWarehouseArticleById(6).Amount.ToString();
            herren57.Text = vs.GetWorkplaceArticleAmountById(6).ToString();
            herren67.Text = vs.GetOrderInWorkArticleAmountById(6).ToString();
            herren77.Text = ProductionPlan.e6.ToString();

            herren18.Text = ProductionPlan.e30.ToString();
            herren28.Text = vs.GetWorkplaceArticleAmountById(30).ToString();
            herren38.Text = vs.sicherheitsbestandE12.ToString();
            herren48.Text = vs.GetWarehouseArticleById(12).Amount.ToString();
            herren58.Text = vs.GetWorkplaceArticleAmountById(12).ToString();
            herren68.Text = vs.GetOrderInWorkArticleAmountById(12).ToString();
            herren78.Text = ProductionPlan.e12.ToString();

            herren19.Text = ProductionPlan.e30.ToString();
            herren29.Text = vs.GetWorkplaceArticleAmountById(30).ToString();
            herren39.Text = vs.sicherheitsbestandE29.ToString();
            herren49.Text = vs.GetWarehouseArticleById(29).Amount.ToString();
            herren59.Text = vs.GetWorkplaceArticleAmountById(29).ToString();
            herren69.Text = vs.GetOrderInWorkArticleAmountById(29).ToString();
            herren79.Text = ProductionPlan.e29.ToString();

            herren110.Text = ProductionPlan.e29.ToString();
            herren210.Text = vs.GetWorkplaceArticleAmountById(29).ToString();
            herren310.Text = vs.sicherheitsbestandE9.ToString();
            herren410.Text = vs.GetWarehouseArticleById(9).Amount.ToString();
            herren510.Text = vs.GetWorkplaceArticleAmountById(9).ToString();
            herren610.Text = vs.GetOrderInWorkArticleAmountById(9).ToString();
            herren710.Text = ProductionPlan.e9.ToString();

            herren111.Text = ProductionPlan.e29.ToString();
            herren211.Text = vs.GetWorkplaceArticleAmountById(29).ToString();
            herren311.Text = vs.sicherheitsbestandE15.ToString();
            herren411.Text = vs.GetWarehouseArticleById(15).Amount.ToString();
            herren511.Text = vs.GetWorkplaceArticleAmountById(15).ToString();
            herren611.Text = vs.GetOrderInWorkArticleAmountById(15).ToString();
            herren711.Text = ProductionPlan.e15.ToString();

            herren112.Text = ProductionPlan.e29.ToString();
            herren212.Text = vs.GetWorkplaceArticleAmountById(29).ToString();
            herren312.Text = vs.sicherheitsbestandE20.ToString();
            herren412.Text = vs.GetWarehouseArticleById(20).Amount.ToString();
            herren512.Text = vs.GetWorkplaceArticleAmountById(20).ToString();
            herren612.Text = vs.GetOrderInWorkArticleAmountById(20).ToString();
            herren712.Text = ProductionPlan.e20.ToString();

            MainWindowFinal.Instance.UpdateUI(State.Result);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindowFinal.Instance.NavigateTo(Logic.UI.MenuItems.MenuItemsEnum.Capacity);
            ListView lvMenu = (ListView)MainWindowFinal.Instance.FindName("ListViewMenu");
            lvMenu.SelectedIndex = 5;
        }
    }
}

