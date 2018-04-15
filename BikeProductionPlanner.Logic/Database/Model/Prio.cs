using System.ComponentModel;

namespace BikeProductionPlanner.Logic.Database.Model
{
    public class Prio : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string position;
        private string teilenr;
        private string anzahl;


        public Prio(string id, string teilenr, string anzahl)
        {
            this.Position = id;
            this.Teilenr = teilenr;
            this.Anzahl = anzahl;
        }

        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ID"));
            }
        }

        public string Teilenr
        {
            get { return teilenr; }
            set
            {
                teilenr = value; OnPropertyChanged(new PropertyChangedEventArgs("Teilenr"));
            }
        }
        public string Anzahl
        {
            get { return anzahl; }
            set
            {
                anzahl = value; OnPropertyChanged(new PropertyChangedEventArgs("Anzahl"));
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, e); }
        }
    }
}
