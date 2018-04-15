using System.ComponentModel;

namespace BikeProductionPlanner.Logic.Database.Model
{
    public class Delivery : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string lieferfrist;
        private string abweichung;
        public string kaufteileno;
        public string kaufteil;
        public string bestellkosten;
        public string diskontmenge;
        public string teilewert;
        public string verwendung;

        public string Kaufteileno
        {
            get { return kaufteileno; }
            set
            {
                kaufteileno = value; OnPropertyChanged(new PropertyChangedEventArgs("KaufteileNo"));
            }
        }

        public string Kaufteil
        {
            get { return kaufteil; }
            set
            {
                kaufteil = value; OnPropertyChanged(new PropertyChangedEventArgs("Kaufteils"));
            }
        }
        public string Verwendung
        {
            get { return verwendung; }
            set
            {
                verwendung = value; OnPropertyChanged(new PropertyChangedEventArgs("Verwendung"));
            }
        }

        public string Bestellkosten
        {
            get { return bestellkosten; }
            set
            {
                bestellkosten = value; OnPropertyChanged(new PropertyChangedEventArgs("Bestellkosten"));
            }
        }

        public string Diskontmenge
        {
            get { return diskontmenge; }
            set
            {
                diskontmenge = value; OnPropertyChanged(new PropertyChangedEventArgs("Diskontmenge"));
            }
        }

        public string Teilewert
        {
            get { return teilewert; }
            set
            {
                teilewert = value; OnPropertyChanged(new PropertyChangedEventArgs("Teilewert"));
            }
        }

        public string Lieferfrist
        {
            get { return lieferfrist; }
            set
            {
                lieferfrist = value; OnPropertyChanged(new PropertyChangedEventArgs("Lieferfrist"));
            }
        }

        public string Abweichung
        {
            get { return abweichung; }
            set
            {
                abweichung = value; OnPropertyChanged(new PropertyChangedEventArgs("Abweichung"));
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, e); }
        }
    }
}
