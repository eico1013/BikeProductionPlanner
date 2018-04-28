using BikeProductionPlanner.Logic.Database;
using BikeProductionPlanner.Logic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            kind32.Text = storageService.sicherheitsbestandP1.ToString();
            kind42.Text = (storageService.GetWarehouseArticleById(26).Amount / 3).ToString();
            kind52.Text = (storageService.GetWorkplaceArticleAmountById(26) / 3).ToString();
            kind62.Text = (storageService.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            kind72.Text = ProductionPlan.e26K.ToString();

            kind13.Text = ProductionPlan.p1.ToString();
            kind23.Text = storageService.GetWorkplaceArticleAmountById(1).ToString();
            kind33.Text = storageService.sicherheitsbestandP1.ToString();
            kind43.Text = storageService.GetWarehouseArticleById(51).Amount.ToString();
            kind53.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind63.Text = storageService.GetOrderInWorkArticleAmountById(51).ToString();
            kind73.Text = ProductionPlan.e51.ToString();

            kind14.Text = ProductionPlan.e51.ToString();
            kind24.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind34.Text = storageService.sicherheitsbestandP1.ToString();
            kind44.Text = (storageService.GetWarehouseArticleById(16).Amount / 3).ToString();
            kind54.Text = (storageService.GetWorkplaceArticleAmountById(16) / 3).ToString();
            kind64.Text = (storageService.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            kind74.Text = ProductionPlan.e16K.ToString();

            kind15.Text = ProductionPlan.e51.ToString();
            kind25.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind35.Text = storageService.sicherheitsbestandP1.ToString();
            kind45.Text = (storageService.GetWarehouseArticleById(17).Amount / 3).ToString();
            kind55.Text = (storageService.GetWorkplaceArticleAmountById(17) / 3).ToString();
            kind65.Text = (storageService.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            kind75.Text = ProductionPlan.e17K.ToString();

            kind16.Text = ProductionPlan.e51.ToString();
            kind26.Text = storageService.GetWorkplaceArticleAmountById(51).ToString();
            kind36.Text = storageService.sicherheitsbestandP1.ToString();
            kind46.Text = storageService.GetWarehouseArticleById(50).Amount.ToString();
            kind56.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind66.Text = storageService.GetOrderInWorkArticleAmountById(50).ToString();
            kind76.Text = ProductionPlan.e50.ToString();

            kind17.Text = ProductionPlan.e50.ToString();
            kind27.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind37.Text = storageService.sicherheitsbestandP1.ToString();
            kind47.Text = storageService.GetWarehouseArticleById(4).Amount.ToString();
            kind57.Text = storageService.GetWorkplaceArticleAmountById(4).ToString();
            kind67.Text = storageService.GetOrderInWorkArticleAmountById(4).ToString();
            kind77.Text = ProductionPlan.e4.ToString();

            kind18.Text = ProductionPlan.e50.ToString();
            kind28.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind38.Text = storageService.sicherheitsbestandP1.ToString();
            kind48.Text = storageService.GetWarehouseArticleById(10).Amount.ToString();
            kind58.Text = storageService.GetWorkplaceArticleAmountById(10).ToString();
            kind68.Text = storageService.GetOrderInWorkArticleAmountById(10).ToString();
            kind78.Text = ProductionPlan.e10.ToString();

            kind19.Text = ProductionPlan.e50.ToString();
            kind29.Text = storageService.GetWorkplaceArticleAmountById(50).ToString();
            kind39.Text = storageService.sicherheitsbestandP1.ToString();
            kind49.Text = storageService.GetWarehouseArticleById(49).Amount.ToString();
            kind59.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind69.Text = storageService.GetOrderInWorkArticleAmountById(49).ToString();
            kind79.Text = ProductionPlan.e49.ToString();

            kind110.Text = ProductionPlan.e49.ToString();
            kind210.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind310.Text = storageService.sicherheitsbestandP1.ToString();
            kind410.Text = storageService.GetWarehouseArticleById(7).Amount.ToString();
            kind510.Text = storageService.GetWorkplaceArticleAmountById(7).ToString();
            kind610.Text = storageService.GetOrderInWorkArticleAmountById(7).ToString();
            kind710.Text = ProductionPlan.e7.ToString();

            kind111.Text = ProductionPlan.e49.ToString();
            kind211.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind311.Text = storageService.sicherheitsbestandP1.ToString();
            kind411.Text = storageService.GetWarehouseArticleById(13).Amount.ToString();
            kind511.Text = storageService.GetWorkplaceArticleAmountById(13).ToString();
            kind611.Text = storageService.GetOrderInWorkArticleAmountById(13).ToString();
            kind711.Text = ProductionPlan.e13.ToString();

            kind112.Text = ProductionPlan.e49.ToString();
            kind212.Text = storageService.GetWorkplaceArticleAmountById(49).ToString();
            kind312.Text = storageService.sicherheitsbestandP1.ToString();
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
            damen32.Text = storageService.sicherheitsbestandP2.ToString();
            damen42.Text = (storageService.GetWarehouseArticleById(26).Amount / 3).ToString();
            damen52.Text = (storageService.GetWorkplaceArticleAmountById(26) / 3).ToString();
            damen62.Text = (storageService.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            damen72.Text = ProductionPlan.e26D.ToString();

            damen13.Text = ProductionPlan.p2.ToString();
            damen23.Text = storageService.GetWorkplaceArticleAmountById(2).ToString();
            damen33.Text = storageService.sicherheitsbestandP2.ToString();
            damen43.Text = storageService.GetWarehouseArticleById(56).Amount.ToString();
            damen53.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen63.Text = storageService.GetOrderInWorkArticleAmountById(56).ToString();
            damen73.Text = ProductionPlan.e56.ToString();

            damen14.Text = ProductionPlan.e56.ToString();
            damen24.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen34.Text = storageService.sicherheitsbestandP2.ToString();
            damen44.Text = (storageService.GetWarehouseArticleById(16).Amount / 3).ToString();
            damen54.Text = (storageService.GetWorkplaceArticleAmountById(16) / 3).ToString();
            damen64.Text = (storageService.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            damen74.Text = ProductionPlan.e16D.ToString();

            damen15.Text = ProductionPlan.e56.ToString();
            damen25.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen35.Text = storageService.sicherheitsbestandP2.ToString();
            damen45.Text = (storageService.GetWarehouseArticleById(17).Amount / 3).ToString();
            damen55.Text = (storageService.GetWorkplaceArticleAmountById(17) / 3).ToString();
            damen65.Text = (storageService.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            damen75.Text = ProductionPlan.e17D.ToString();

            damen16.Text = ProductionPlan.e56.ToString();
            damen26.Text = storageService.GetWorkplaceArticleAmountById(56).ToString();
            damen36.Text = storageService.sicherheitsbestandP2.ToString();
            damen46.Text = storageService.GetWarehouseArticleById(55).Amount.ToString();
            damen56.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen66.Text = storageService.GetOrderInWorkArticleAmountById(55).ToString();
            damen76.Text = ProductionPlan.e55.ToString();

            damen17.Text = ProductionPlan.e55.ToString();
            damen27.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen37.Text = storageService.sicherheitsbestandP2.ToString();
            damen47.Text = storageService.GetWarehouseArticleById(5).Amount.ToString();
            damen57.Text = storageService.GetWorkplaceArticleAmountById(5).ToString();
            damen67.Text = storageService.GetOrderInWorkArticleAmountById(5).ToString();
            damen77.Text = ProductionPlan.e5.ToString();

            damen18.Text = ProductionPlan.e55.ToString();
            damen28.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen38.Text = storageService.sicherheitsbestandP2.ToString();
            damen48.Text = storageService.GetWarehouseArticleById(11).Amount.ToString();
            damen58.Text = storageService.GetWorkplaceArticleAmountById(11).ToString();
            damen68.Text = storageService.GetOrderInWorkArticleAmountById(11).ToString();
            damen78.Text = ProductionPlan.e11.ToString();

            damen19.Text = ProductionPlan.e55.ToString();
            damen29.Text = storageService.GetWorkplaceArticleAmountById(55).ToString();
            damen39.Text = storageService.sicherheitsbestandP2.ToString();
            damen49.Text = storageService.GetWarehouseArticleById(54).Amount.ToString();
            damen59.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen69.Text = storageService.GetOrderInWorkArticleAmountById(54).ToString();
            damen79.Text = ProductionPlan.e54.ToString();

            damen110.Text = ProductionPlan.e54.ToString();
            damen210.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen310.Text = storageService.sicherheitsbestandP2.ToString();
            damen410.Text = storageService.GetWarehouseArticleById(8).Amount.ToString();
            damen510.Text = storageService.GetWorkplaceArticleAmountById(8).ToString();
            damen610.Text = storageService.GetOrderInWorkArticleAmountById(8).ToString();
            damen710.Text = ProductionPlan.e8.ToString();

            damen111.Text = ProductionPlan.e54.ToString();
            damen211.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen311.Text = storageService.sicherheitsbestandP2.ToString();
            damen411.Text = storageService.GetWarehouseArticleById(14).Amount.ToString();
            damen511.Text = storageService.GetWorkplaceArticleAmountById(14).ToString();
            damen611.Text = storageService.GetOrderInWorkArticleAmountById(14).ToString();
            damen711.Text = ProductionPlan.e14.ToString();

            damen112.Text = ProductionPlan.e54.ToString();
            damen212.Text = storageService.GetWorkplaceArticleAmountById(54).ToString();
            damen312.Text = storageService.sicherheitsbestandP2.ToString();
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
            herren32.Text = storageService.sicherheitsbestandP2.ToString();
            herren42.Text = (storageService.GetWarehouseArticleById(26).Amount / 3).ToString();
            herren52.Text = (storageService.GetWorkplaceArticleAmountById(26) / 3).ToString();
            herren62.Text = (storageService.GetOrderInWorkArticleAmountById(26) / 3).ToString();
            herren72.Text = ProductionPlan.e26H.ToString();

            herren13.Text = ProductionPlan.p3.ToString();
            herren23.Text = storageService.GetWorkplaceArticleAmountById(3).ToString();
            herren33.Text = storageService.sicherheitsbestandP2.ToString();
            herren43.Text = storageService.GetWarehouseArticleById(31).Amount.ToString();
            herren53.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren63.Text = storageService.GetOrderInWorkArticleAmountById(31).ToString();
            herren73.Text = ProductionPlan.e31.ToString();

            herren14.Text = ProductionPlan.e31.ToString();
            herren24.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren34.Text = storageService.sicherheitsbestandP2.ToString();
            herren44.Text = (storageService.GetWarehouseArticleById(16).Amount / 3).ToString();
            herren54.Text = (storageService.GetWorkplaceArticleAmountById(16) / 3).ToString();
            herren64.Text = (storageService.GetOrderInWorkArticleAmountById(16) / 3).ToString();
            herren74.Text = ProductionPlan.e16H.ToString();

            herren15.Text = ProductionPlan.e31.ToString();
            herren25.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren35.Text = storageService.sicherheitsbestandP2.ToString();
            herren45.Text = (storageService.GetWarehouseArticleById(17).Amount / 3).ToString();
            herren55.Text = (storageService.GetWorkplaceArticleAmountById(17) / 3).ToString();
            herren65.Text = (storageService.GetOrderInWorkArticleAmountById(17) / 3).ToString();
            herren75.Text = ProductionPlan.e17H.ToString();

            herren16.Text = ProductionPlan.e31.ToString();
            herren26.Text = storageService.GetWorkplaceArticleAmountById(31).ToString();
            herren36.Text = storageService.sicherheitsbestandP2.ToString();
            herren46.Text = storageService.GetWarehouseArticleById(30).Amount.ToString();
            herren56.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren66.Text = storageService.GetOrderInWorkArticleAmountById(30).ToString();
            herren76.Text = ProductionPlan.e30.ToString();

            herren17.Text = ProductionPlan.e30.ToString();
            herren27.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren37.Text = storageService.sicherheitsbestandP2.ToString();
            herren47.Text = storageService.GetWarehouseArticleById(6).Amount.ToString();
            herren57.Text = storageService.GetWorkplaceArticleAmountById(6).ToString();
            herren67.Text = storageService.GetOrderInWorkArticleAmountById(6).ToString();
            herren77.Text = ProductionPlan.e6.ToString();

            herren18.Text = ProductionPlan.e30.ToString();
            herren28.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren38.Text = storageService.sicherheitsbestandP2.ToString();
            herren48.Text = storageService.GetWarehouseArticleById(12).Amount.ToString();
            herren58.Text = storageService.GetWorkplaceArticleAmountById(12).ToString();
            herren68.Text = storageService.GetOrderInWorkArticleAmountById(12).ToString();
            herren78.Text = ProductionPlan.e12.ToString();

            herren19.Text = ProductionPlan.e30.ToString();
            herren29.Text = storageService.GetWorkplaceArticleAmountById(30).ToString();
            herren39.Text = storageService.sicherheitsbestandP2.ToString();
            herren49.Text = storageService.GetWarehouseArticleById(29).Amount.ToString();
            herren59.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren69.Text = storageService.GetOrderInWorkArticleAmountById(29).ToString();
            herren79.Text = ProductionPlan.e29.ToString();

            herren110.Text = ProductionPlan.e29.ToString();
            herren210.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren310.Text = storageService.sicherheitsbestandP2.ToString();
            herren410.Text = storageService.GetWarehouseArticleById(9).Amount.ToString();
            herren510.Text = storageService.GetWorkplaceArticleAmountById(9).ToString();
            herren610.Text = storageService.GetOrderInWorkArticleAmountById(9).ToString();
            herren710.Text = ProductionPlan.e9.ToString();

            herren111.Text = ProductionPlan.e29.ToString();
            herren211.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren311.Text = storageService.sicherheitsbestandP2.ToString();
            herren411.Text = storageService.GetWarehouseArticleById(15).Amount.ToString();
            herren511.Text = storageService.GetWorkplaceArticleAmountById(15).ToString();
            herren611.Text = storageService.GetOrderInWorkArticleAmountById(15).ToString();
            herren711.Text = ProductionPlan.e15.ToString();

            herren112.Text = ProductionPlan.e29.ToString();
            herren212.Text = storageService.GetWorkplaceArticleAmountById(29).ToString();
            herren312.Text = storageService.sicherheitsbestandP2.ToString();
            herren412.Text = storageService.GetWarehouseArticleById(20).Amount.ToString();
            herren512.Text = storageService.GetWorkplaceArticleAmountById(20).ToString();
            herren612.Text = storageService.GetOrderInWorkArticleAmountById(20).ToString();
            herren712.Text = ProductionPlan.e20.ToString();

        }
    }
}
