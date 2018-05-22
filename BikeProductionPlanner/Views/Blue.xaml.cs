using System;
using BikeProductionPlanner.Logic;
using System.Windows;
using System.Windows.Controls;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Views
{
    /// <summary>
    /// Interaction logic for Blue.xaml
    /// </summary>
    public partial class Blue : UserControl
    {
        public Blue()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlInputParser.Instance.ParseXml("C:/Wirtschaftsinformatik/7. Semester/Perioden/resultServlet.xml");
            String PeriodevonXML = Convert.ToString(StorageService.Instance.GetPeriodFromXml());
            MessageBox.Show(PeriodevonXML);
        }
    }
}
