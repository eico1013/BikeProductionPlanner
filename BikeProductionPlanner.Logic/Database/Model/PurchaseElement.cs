using System.ComponentModel;

namespace BikeProductionPlanner.Logic.Database.Model
{
    public class PurchaseElement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string purchasePart;
        private string purchaseOrderAmount;
        private string purchaseOrderType;
        private string purchaseStartAmount;
        private string purchaseEndAmountP0D1;
        private string purchaseEndAmountP0D2;
        private string purchaseEndAmountP0D3;
        private string purchaseEndAmountP0D4;
        private string purchaseEndAmountP0D5;
        private string purchaseEndAmountP1D1;
        private string purchaseEndAmountP1D2;
        private string purchaseEndAmountP1D3;
        private string purchaseEndAmountP1D4;
        private string purchaseEndAmountP1D5;
        private string purchaseEndAmountP2D1;
        private string purchaseEndAmountP2D2;
        private string purchaseEndAmountP2D3;
        private string purchaseEndAmountP2D4;
        private string purchaseEndAmountP2D5;
        private string purchaseEndAmountP3D1;
        private string purchaseEndAmountP3D2;
        private string purchaseEndAmountP3D3;
        private string purchaseEndAmountP3D4;
        private string purchaseEndAmountP3D5;

        public PurchaseElement(string purchasePart, string purchaseOrderAmount, string purchaseOrderType,
                                string purchaseStartAmount, string purchaseEndAmountP0D1, string purchaseEndAmountP0D2,
                                string purchaseEndAmountP0D3, string purchaseEndAmountP0D4, string purchaseEndAmountP0D5,
                                string purchaseEndAmountP1D1, string purchaseEndAmountP1D2, string purchaseEndAmountP1D3,
                                string purchaseEndAmountP1D4, string purchaseEndAmountP1D5, string purchaseEndAmountP2D1,
                                string purchaseEndAmountP2D2, string purchaseEndAmountP2D3, string purchaseEndAmountP2D4,
                                string purchaseEndAmountP2D5, string purchaseEndAmountP3D1, string purchaseEndAmountP3D2,
                                string purchaseEndAmountP3D3, string purchaseEndAmountP3D4, string purchaseEndAmountP3D5)
        {
            this.Kaufteil = purchasePart;
            this.Bestellmenge = purchaseOrderAmount;
            this.Bestellart = purchaseOrderType;
            this.Anfangsbestand = purchaseStartAmount;
            this.EndbestandP0D1 = purchaseEndAmountP0D1;
            this.EndbestandP0D2 = purchaseEndAmountP0D2;
            this.EndbestandP0D3 = purchaseEndAmountP0D3;
            this.EndbestandP0D4 = purchaseEndAmountP0D4;
            this.EndbestandP0D5 = purchaseEndAmountP0D5;
            this.EndbestandP1D1 = purchaseEndAmountP1D1;
            this.EndbestandP1D2 = purchaseEndAmountP1D2;
            this.EndbestandP1D3 = purchaseEndAmountP1D3;
            this.EndbestandP1D4 = purchaseEndAmountP1D4;
            this.EndbestandP1D5 = purchaseEndAmountP1D5;
            this.EndbestandP2D1 = purchaseEndAmountP2D1;
            this.EndbestandP2D2 = purchaseEndAmountP2D2;
            this.EndbestandP2D3 = purchaseEndAmountP2D3;
            this.EndbestandP2D4 = purchaseEndAmountP2D4;
            this.EndbestandP2D5 = purchaseEndAmountP2D5;
            this.EndbestandP3D1 = purchaseEndAmountP3D1;
            this.EndbestandP3D2 = purchaseEndAmountP3D2;
            this.EndbestandP3D3 = purchaseEndAmountP3D3;
            this.EndbestandP3D4 = purchaseEndAmountP3D4;
            this.EndbestandP3D5 = purchaseEndAmountP3D5;
        }

        public string Kaufteil
        {
            get { return purchasePart; }
            set
            {
                purchasePart = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Kaufteil"));
            }
        }

        public string Bestellmenge
        {
            get { return purchaseOrderAmount; }
            set
            {
                purchaseOrderAmount = value; OnPropertyChanged(new PropertyChangedEventArgs("Bestellmenge"));
            }
        }

        public string Bestellart
        {
            get { return purchaseOrderType; }
            set
            {
                purchaseOrderType = value; OnPropertyChanged(new PropertyChangedEventArgs("Bestellart"));
            }
        }

        public string Anfangsbestand
        {
            get { return purchaseStartAmount; }
            set
            {
                purchaseStartAmount = value; OnPropertyChanged(new PropertyChangedEventArgs("Anfangsbestand"));
            }
        }

        public string EndbestandP0D1
        {
            get { return purchaseEndAmountP0D1; }
            set
            {
                purchaseEndAmountP0D1 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP0D1"));
            }
        }

        public string EndbestandP0D2
        {
            get { return purchaseEndAmountP0D2; }
            set
            {
                purchaseEndAmountP0D2 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP0D2"));
            }
        }

        public string EndbestandP0D3
        {
            get { return purchaseEndAmountP0D3; }
            set
            {
                purchaseEndAmountP0D3 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP0D3"));
            }
        }

        public string EndbestandP0D4
        {
            get { return purchaseEndAmountP0D4; }
            set
            {
                purchaseEndAmountP0D4 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP0D4"));
            }
        }

        public string EndbestandP0D5
        {
            get { return purchaseEndAmountP0D5; }
            set
            {
                purchaseEndAmountP0D5 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP0D5"));
            }
        }

        public string EndbestandP1D1
        {
            get { return purchaseEndAmountP1D1; }
            set
            {
                purchaseEndAmountP1D1 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP1D1"));
            }
        }

        public string EndbestandP1D2
        {
            get { return purchaseEndAmountP1D2; }
            set
            {
                purchaseEndAmountP1D2 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP1D2"));
            }
        }

        public string EndbestandP1D3
        {
            get { return purchaseEndAmountP1D3; }
            set
            {
                purchaseEndAmountP1D3 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP1D3"));
            }
        }

        public string EndbestandP1D4
        {
            get { return purchaseEndAmountP1D4; }
            set
            {
                purchaseEndAmountP1D4 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP1D4"));
            }
        }

        public string EndbestandP1D5
        {
            get { return purchaseEndAmountP1D5; }
            set
            {
                purchaseEndAmountP1D5 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP1D5"));
            }
        }

        public string EndbestandP2D1
        {
            get { return purchaseEndAmountP2D1; }
            set
            {
                purchaseEndAmountP2D1 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP2D1"));
            }
        }

        public string EndbestandP2D2
        {
            get { return purchaseEndAmountP2D2; }
            set
            {
                purchaseEndAmountP2D2 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP2D2"));
            }
        }

        public string EndbestandP2D3
        {
            get { return purchaseEndAmountP2D3; }
            set
            {
                purchaseEndAmountP2D3 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP2D3"));
            }
        }

        public string EndbestandP2D4
        {
            get { return purchaseEndAmountP2D4; }
            set
            {
                purchaseEndAmountP2D4 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP2D4"));
            }
        }

        public string EndbestandP2D5
        {
            get { return purchaseEndAmountP2D5; }
            set
            {
                purchaseEndAmountP2D5 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP2D5"));
            }
        }

        public string EndbestandP3D1
        {
            get { return purchaseEndAmountP3D1; }
            set
            {
                purchaseEndAmountP3D1 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP3D1"));
            }
        }

        public string EndbestandP3D2
        {
            get { return purchaseEndAmountP3D2; }
            set
            {
                purchaseEndAmountP3D2 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP3D2"));
            }
        }

        public string EndbestandP3D3
        {
            get { return purchaseEndAmountP3D3; }
            set
            {
                purchaseEndAmountP3D3 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP3D3"));
            }
        }

        public string EndbestandP3D4
        {
            get { return purchaseEndAmountP3D4; }
            set
            {
                purchaseEndAmountP3D4 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP3D4"));
            }
        }

        public string EndbestandP3D5
        {
            get { return purchaseEndAmountP3D5; }
            set
            {
                purchaseEndAmountP3D5 = value; OnPropertyChanged(new PropertyChangedEventArgs("EndbestandP3D5"));
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, e); }
        }
    }
}
