using System.Windows.Controls;

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
        }
    }
}
