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
    public partial class SafetyStock : UserControl
    {

        public SafetyStock()
        {
            InitializeComponent();
        }

        //private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}

        //private void Forecast_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    try
        //    {
        //        Int32 forecastsum1 = 0;

        //        if (period0product1 != null)
        //            forecastsum1 += Convert.ToInt32(period0product1.Text);
        //        if (period0product2 != null)
        //            forecastsum1 += Convert.ToInt32(period0product2.Text);
        //        if (period0product3 != null)
        //            forecastsum1 += Convert.ToInt32(period0product3.Text);



        //        if (period0sum != null)
        //            period0sum.Text = forecastsum1.ToString();


        //    }
        //    catch
        //    {

        //    }
        //}

        //private bool AllFilled()
        //{
        //    if (Slider_SafetyStockProduct1..Text == "" || period0product2.Text == "" || period0product3.Text == "")
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(safetyFactor.Text))
        //        {
        //            MessageBox.Show("Fehler: Sicherheitsfaktor muss angegeben werden.");
        //            return;
        //        }

        //        if (Convert.ToInt32(period0product1.Text) % 10 != 0 || Convert.ToInt32(period0product2.Text) % 10 != 0
        //            || Convert.ToInt32(period0product3.Text) % 10 != 0)
        //        {
        //            MessageBox.Show("Fehler: Nur ganzzahlige Werte in 10er Schritten erlaubt.");
        //            return;
        //        }
        //    }
        //    catch
        //    {

        //    }

        //    if (AllFilled())
        //    {
        //        try
        //        {
        //            StorageService.Instance.sicherheitsbestandP1 = Convert.ToInt32(period0product1.Text);
        //            StorageService.Instance.sicherheitsbestandP2 = Convert.ToInt32(period0product2.Text);
        //            StorageService.Instance.sicherheitsbestandP3 = Convert.ToInt32(period0product3.Text);

        //            StorageService.Instance.sicherheitsFaktor = Convert.ToInt32(safetyFactor.Text);

        //            ////Check atuotmatic Import
        //            //if (found == false)
        //            //{
        //            //    customexportpathtextbox.IsEnabled = true;
        //            //}
        //            //if (found == true)
        //            //{
        //            //    xmlexportbutton.IsEnabled = true;
        //            //}

        //            //Ibsys2.Berechnungen.Logic.Berechnungen logic = new Ibsys2.Berechnungen.Logic.Berechnungen();
        //            //logic.berechnen();

        //            //UpdatePlanningFields();
        //            //UpdateKapaFields();
        //            //UpdateEinkauf();
        //            //UpdatePrioFields();
        //            //UpdateLager();

        //            //MainWindow.Instance.UpdateUI(State.Result);
        //            //MainWindow.Instance.NavigateTo(MenuItems.ProductionPlan);
        //        }
        //        catch (FormatException)
        //        {
        //            MessageBox.Show("Fehler: Nur ganzzahlige Werte erlaubt.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Fehler: Alle Felder müssen ausgefüllt werden.");
        //        return;
        //    }
        //}
        private void Slider_SafetyStockProduct2_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider) sender;
            slider.Value = (int) slider.Value;
        }

        private void Slider_SafetyStockProduct1_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider) sender;
            slider.Value = (int) slider.Value;
        }

        private void Slider_SafetyStockProduct3_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider) sender;
            slider.Value = (int) slider.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageService.Instance.sicherheitsbestandP1 = Convert.ToInt32(Slider_SafetyStockProduct1.Value);
                StorageService.Instance.sicherheitsbestandP2 = Convert.ToInt32(Slider_SafetyStockProduct2.Value);
                StorageService.Instance.sicherheitsbestandP3 = Convert.ToInt32(Slider_SafetyStockProduct3.Value);
            }
            catch (FormatException)
            {
                MessageBox.Show("Fehler: Nur ganzzahlige Werte erlaubt.");
            }
        }
    }
}
