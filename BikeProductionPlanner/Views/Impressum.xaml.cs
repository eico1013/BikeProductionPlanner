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
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class Impressum : UserControl
    {
        public Impressum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Copyright

            

            button1.Visibility = Visibility.Collapsed;
            TextCopyright.Visibility = Visibility.Visible;
            //System.Threading.Thread.Sleep(5000);
            //System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(5000);
            //TextCopyright.Visibility = Visibility.Collapsed;
            //button1.Visibility = Visibility.Visible;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Haftung
            button2.Visibility = Visibility.Collapsed;
            TextHaftung.Visibility = Visibility.Visible;
            //System.Threading.Thread.Sleep(1000);
            //TextHaftung.Visibility = Visibility.Collapsed;

        }
    }
}
