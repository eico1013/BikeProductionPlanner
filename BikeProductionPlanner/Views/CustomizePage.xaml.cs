using BikeProductionPlanner.Logic.Database;
using BikeProductionPlanner.Logic.Database.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BikeProductionPlanner.WPF.Views
{
    /// <summary>
    /// Interaction logic for CustomizePage.xaml
    /// </summary>
    public partial class CustomizePage : UserControl
    {
        public CustomizePage()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.prio.ItemsSource = new ObservableCollection<Prio>();
        }

        public void UpdatePrioFields()
        {
            var fields = (ObservableCollection<Prio>)prio.ItemsSource;
            fields.Clear();
            int i = 0;
            foreach (var product in StorageService.Instance.GetAllProductionItems())
            {
                fields.Add(new Prio(i.ToString(), product.Article.ToString(), product.Quantity.ToString()));
                i++;
            }

        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);
                if (position > 0)
                {
                    StorageService.Instance.MoveProductionItemToSpecialIndex(position - 1, position);
                    grid.Clear();

                    UpdatePrioFields();
                }
            }
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);
                if (position + 1 < StorageService.Instance.GetAllProductionItems().Count)
                {
                    StorageService.Instance.MoveProductionItemToSpecialIndex(position + 2, position);
                    grid.Clear();
                    UpdatePrioFields();
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);
                StorageService.Instance.GetAllProductionItems().RemoveAt(position);
                grid.Clear();
                UpdatePrioFields();
            }
        }

        private void split_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);

                ProductionList p = StorageService.Instance.GetAllProductionItems()[position];

                int quantity1 = p.Quantity / 2;
                int quantity2 = 0;
                if ((quantity1) % 10 == 0)
                {
                    quantity2 = quantity1;
                }
                else
                {

                    quantity1 = (int)Math.Ceiling((double)p.Quantity / 20) * 10;
                    quantity2 = (int)Math.Floor((double)p.Quantity / 20) * 10;

                    if (quantity2 == 0)
                        return;
                }
                
                p.Quantity = quantity1;
                StorageService.Instance.AddProductionItem(new ProductionList(p.Article, quantity2));
                StorageService.Instance.MoveProductionItemToSpecialIndex(position + 1, StorageService.Instance.GetAllProductionItems().Count - 1);
                grid.Clear();
                UpdatePrioFields();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            int artikel = 0;
            int menge = 0;
            try
            {
                artikel = System.Convert.ToInt32(prioAddItem.Text);
                menge = System.Convert.ToInt32(prioAddAmount.Text);

                if (artikel < 1 || artikel > 59 || menge < 10 || menge % 10 != 0)
                {
                    MessageBox.Show("Bitte eine gültige Artikelnummer eingeben!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }
            }
            catch { MessageBox.Show("Die Eingabe muss eine ganze Zahl und durch 10 teilbar sein!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            StorageService.Instance.AddProductionItem(new ProductionList(artikel, menge));

            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            grid.Clear();
            UpdatePrioFields();
            prioAddAmount.Text = "";
            prioAddItem.Text = "";
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Forecast1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
