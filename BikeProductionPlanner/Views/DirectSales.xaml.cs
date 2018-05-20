using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class DirectSales : UserControl
    {
        public DirectSales()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //Speichern & Zurück

        }

        private void Forecast1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Int32 directsum1 = 0;

                if (directProduct1 != null)
                    directsum1 += Convert.ToInt32(directProduct1.Text);
                if (directProduct2 != null)
                    directsum1 += Convert.ToInt32(directProduct2.Text);
                if (directProduct3 != null)
                    directsum1 += Convert.ToInt32(directProduct3.Text);

                if (directSum != null)
                    directSum.Text = directsum1.ToString();
            }
            catch
            {

            }
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
