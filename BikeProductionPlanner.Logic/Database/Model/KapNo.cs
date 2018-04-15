using System.ComponentModel;

namespace BikeProductionPlanner.Logic.Database.Model
{
    public class KapNo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        private string calculation;

        public string Title
        {
            get { return title; }
            set
            {
                title = value; OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }
        public string Calculation
        {
            get { return calculation; }
            set
            {
                calculation = value; OnPropertyChanged(new PropertyChangedEventArgs("Calculation"));
            }
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, e); }
        }
    }
}
