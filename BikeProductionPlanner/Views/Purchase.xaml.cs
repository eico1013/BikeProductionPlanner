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
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaktionslogik für Purchasing.xaml
    /// </summary>
    public partial class Purchase : UserControl
    {
        public Purchase()
        {
            InitializeComponent();
            
            //Hole Kaufteilliste aus StorageService
            List<WarehouseStock> purchasePartsList = StorageService.Instance.GetPurchaseParts();

            //Iteriere Kaufteilliste durch
            foreach (WarehouseStock purchasePart in purchasePartsList)
            {
                // Kaufteil ID als String
                String id = Convert.ToString(purchasePart.Id);
                // Kaufteil Menge als String
                String amount = Convert.ToString(purchasePart.Amount);
                String mergeOfCurrentStock = "currentStockK" + id;

                TextBox tb = (TextBox)this.FindName(mergeOfCurrentStock);

                // Anfangsbestände befüllen
                tb.Text = amount;    
            }
        }

        // Zeige Spalte an oder schließe Spalte
        private void titlePurchase_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            if (!spPurchasePart.Visibility.Equals(Visibility.Visible))
            {
                spPurchasePart.Visibility = Visibility.Visible;
            }

            else
            {
                spPurchasePart.Visibility = Visibility.Collapsed;
            }        

        }

        // Zeige Detail-Ansicht
        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            if (btnShowDetails.Content.Equals("Details einblenden"))
            {
                btnShowDetails.Content = "Details ausblenden";
                gridDetail.Visibility = Visibility.Visible;

            }

            else
            {
                btnShowDetails.Content = "Details einblenden";
                gridDetail.Visibility = Visibility.Hidden;
            }
        }

        /*
       
        private void currentStockP0D1K21_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Amount:" + Convert.ToString(StorageService.Instance.GetFutureInwardStockMovment(21).Amount));
        }

        */
    }
}
