using BikeProductionPlanner.Logic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BikeProductionPlanner.WPF.Views
{
    /// <summary>
    /// Interaction logic for WebServiceImportWindow.xaml
    /// </summary>
    public partial class WebServiceImportWindow : Window
    {
        public WebServiceImportWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            uint i = 0;
            if (PasswordTextBox.Password != "quatro" || UsernameTextBox.Text != "kass18d4")
            {
                MessageBox.Show("Login failed!\nInvalid Username or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(uint.TryParse(PeriodTextBox.Text,out i))
            {
                var lastPeriod = i - 1;
                var link = "http://www.scm-planspiel.de/start/downloadFile?folderName=output&fileName=200_5_" +
                           lastPeriod + "result.xml";
                var xmlfile = file_get_contents(link);
                var path = System.IO.Path.GetTempPath() + @"XMLInputFile" + lastPeriod + ".xml";
                File.WriteAllText(path, xmlfile);
                XmlInputParser.Instance.ParseXml(path);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Period Format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        protected string file_get_contents(string fileName)
        {

            string sContents = string.Empty;
            if (fileName.ToLower().IndexOf("http:") > -1)
            {
                // URL 
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] response = wc.DownloadData(fileName);
                sContents = System.Text.Encoding.ASCII.GetString(response);
            }
            else
            {
                // Regular Filename 
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                sContents = sr.ReadToEnd();
                sr.Close();
            }
            return sContents;
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
