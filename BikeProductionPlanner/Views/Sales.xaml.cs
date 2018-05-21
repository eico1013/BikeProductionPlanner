using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BikeProductionPlanner.Logic.Database;

using BikeProductionPlanner.Logic;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaction logic for SafetyStock.xaml
    /// </summary>
    /// 


    public partial class Sales : UserControl
    {
        public static int periode0produkt1;
        public static int periode0produkt2;
        public static int periode0produkt3;

        public static int periode1produkt1;
        public static int periode1produkt2;
        public static int periode1produkt3;

        public static int periode2produkt1;
        public static int periode2produkt2;
        public static int periode2produkt3;

        public static int periode3produkt1;
        public static int periode3produkt2;
        public static int periode3produkt3;

        public Sales()
        {
            InitializeComponent();
        }



        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool AllFilled()
        {
            if (period0product1.Text == "" || period0product2.Text == "" || period0product3.Text == ""
                || period1product1.Text == "" || period1product2.Text == "" || period1product3.Text == ""
                || period2product1.Text == "" || period2product2.Text == "" || period2product3.Text == "")
            {
                return false;
            }
            return true;
        }

        private void UpdateSummeFromForcast(object sender, TextChangedEventArgs e)
        {
            try
            {
                int p0sum = 0;
                int p1sum = 0;
                int p2sum = 0;
                int p3sum = 0;
                if (period0product1 != null)
                    p0sum += Convert.ToInt32(period0product1.Text);
                if (period0product2 != null)
                    p0sum += Convert.ToInt32(period0product2.Text);
                if (period0product3 != null)
                    p0sum += Convert.ToInt32(period0product3.Text);

                if (period1product1 != null)
                    p1sum += Convert.ToInt32(period1product1.Text);
                if (period1product2 != null)
                    p1sum += Convert.ToInt32(period1product2.Text);
                if (period1product3 != null)
                    p1sum += Convert.ToInt32(period1product3.Text);

                if (period2product1 != null)
                    p2sum += Convert.ToInt32(period2product1.Text);
                if (period2product2 != null)
                    p2sum += Convert.ToInt32(period2product2.Text);
                if (period2product3 != null)
                    p2sum += Convert.ToInt32(period2product3.Text);

                if (period3product1 != null)
                    p3sum += Convert.ToInt32(period3product1.Text);
                if (period3product2 != null)
                    p3sum += Convert.ToInt32(period3product2.Text);
                if (period3product3 != null)
                    p3sum += Convert.ToInt32(period3product3.Text);

                if (period0sum != null)
                    period0sum.Text = p0sum.ToString();

                if (period1sum != null)
                    period1sum.Text = p1sum.ToString();

                if (period2sum != null)
                    period2sum.Text = p2sum.ToString();

                if (period3sum != null)
                    period3sum.Text = p3sum.ToString();
            }
            catch { }
        }
     
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //Direktvertrieb
            
            ContentControl.Content = new DirectSales();


        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            //Speichern
            Int32 maxValue = 1050;

            try
            {
                StorageService.Instance.vertriebswunschP1 = Convert.ToInt32(period0product1.Text);
                StorageService.Instance.vertriebswunschP2 = Convert.ToInt32(period0product2.Text);
                StorageService.Instance.vertriebswunschP3 = Convert.ToInt32(period0product3.Text);

                StorageService.Instance.prognose1P1 = Convert.ToInt32(period1product1.Text);
                StorageService.Instance.prognose1P2 = Convert.ToInt32(period1product2.Text);
                StorageService.Instance.prognose1P3 = Convert.ToInt32(period1product3.Text);

                StorageService.Instance.prognose2P1 = Convert.ToInt32(period2product1.Text);
                StorageService.Instance.prognose2P2 = Convert.ToInt32(period2product2.Text);
                StorageService.Instance.prognose2P3 = Convert.ToInt32(period2product3.Text);

                StorageService.Instance.prognose3P1 = Convert.ToInt32(period3product1.Text);
                StorageService.Instance.prognose3P2 = Convert.ToInt32(period3product2.Text);
                StorageService.Instance.prognose3P3 = Convert.ToInt32(period3product3.Text);
                /*
                periode0produkt1 = Convert.ToInt32(period0product1.Text);
                periode0produkt2 = Convert.ToInt32(period0product2.Text);
                periode0produkt3 = Convert.ToInt32(period0product3.Text);

                periode1produkt1 = Convert.ToInt32(period1product1.Text);
                periode1produkt2 = Convert.ToInt32(period1product2.Text);
                periode1produkt3 = Convert.ToInt32(period1product3.Text);

                periode2produkt1 = Convert.ToInt32(period2product1.Text);
                periode2produkt2 = Convert.ToInt32(period2product2.Text);
                periode2produkt3 = Convert.ToInt32(period2product3.Text);

                periode3produkt1 = Convert.ToInt32(period3product1.Text);
                periode3produkt2 = Convert.ToInt32(period3product2.Text);
                periode3produkt3 = Convert.ToInt32(period3product3.Text);

                */
            }
            catch
            {
if (Convert.ToInt32(period0sum.Text) > maxValue || Convert.ToInt32(period1sum.Text) > maxValue
                    || Convert.ToInt32(period2sum.Text) > maxValue || Convert.ToInt32(period3sum.Text) > maxValue)
                {
                    MessageBox.Show("Fehler: Die Summe muss kleiner 1050 sein.");
                    return;
                }

                if (Convert.ToInt32(period0product1.Text) % 10 != 0 || Convert.ToInt32(period0product2.Text) % 10 != 0
                    || Convert.ToInt32(period0product3.Text) % 10 != 0 || Convert.ToInt32(period1product1.Text) % 10 != 0
                    || Convert.ToInt32(period1product2.Text) % 10 != 0 || Convert.ToInt32(period1product3.Text) % 10 != 0
                    || Convert.ToInt32(period2product1.Text) % 10 != 0 || Convert.ToInt32(period2product2.Text) % 10 != 0
                    || Convert.ToInt32(period2product3.Text) % 10 != 0 || Convert.ToInt32(period3product1.Text) % 10 != 0
                    || Convert.ToInt32(period3product2.Text) % 10 != 0 || Convert.ToInt32(period3product3.Text) % 10 != 0)
                {
                    MessageBox.Show("Fehler: Nur ganzzahlige Werte in 10er Schritten erlaubt.");
                    return;
                }
            }

            

            if (AllFilled())
            {
                try
                {
                    StorageService.Instance.vertriebswunschP1 = Convert.ToInt32(period0product1.Text);

                    periode0produkt1 = Convert.ToInt32(period0product1.Text);
                    periode0produkt2 = Convert.ToInt32(period0product2.Text);
                    periode0produkt3 = Convert.ToInt32(period0product3.Text);

                    periode1produkt1 = Convert.ToInt32(period1product1.Text);
                    periode1produkt2 = Convert.ToInt32(period1product2.Text);
                    periode1produkt3 = Convert.ToInt32(period1product3.Text);

                    periode2produkt1 = Convert.ToInt32(period2product1.Text);
                    periode2produkt2 = Convert.ToInt32(period2product2.Text);
                    periode2produkt3 = Convert.ToInt32(period2product3.Text);

                    periode3produkt1 = Convert.ToInt32(period3product1.Text);
                    periode3produkt2 = Convert.ToInt32(period3product2.Text);
                    periode3produkt3 = Convert.ToInt32(period3product3.Text);
        
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Fehler: Nur ganzzahlige Werte erlaubt.");
                }
            }
            else
            {
                MessageBox.Show("Fehler: Alle Felder müssen ausgefüllt werden.");
                return;
            }
        }

    }

 }
    

