using System.ComponentModel;

namespace BikeProductionPlanner.Logic.Database.Model
{
    public class ItemNo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        private string type;
        private string id;
        private string amount;
        private string cost;
        private string costSum;

        public string Title
        {
            get { return title; }
            set
            {
                title = value; OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value; OnPropertyChanged(new PropertyChangedEventArgs("Type"));
            }
        }
        public string Id
        {
            get { return id; }
            set
            {
                id = value; OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }
        public string Amount
        {
            get { return amount; }
            set
            {
                amount = value; OnPropertyChanged(new PropertyChangedEventArgs("Amount"));
            }
        }
        public string Cost
        {
            get { return cost; }
            set
            {
                cost = value; OnPropertyChanged(new PropertyChangedEventArgs("Cost"));
            }
        }
        public string CostSum
        {
            get { return costSum; }
            set
            {
                costSum = value; OnPropertyChanged(new PropertyChangedEventArgs("CostSum"));
            }
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, e); }
        }
    }
}
