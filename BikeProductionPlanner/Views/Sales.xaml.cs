using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaction logic for SafetyStock.xaml
    /// </summary>
    public partial class Sales : UserControl
    {

        public Sales()
        {
            InitializeComponent();
        }



        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            ContentControl.Content = null;
            ContentControl.Content = new DirectSales();


        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            //Planung durchführen
            Int32 maxValue = 1050;

            try
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
            catch
            {

            }

        }

        }
    }

