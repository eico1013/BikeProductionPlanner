using System;

namespace BikeProductionPlanner.Logic.Database.Model
{
    public class ForecastPeriod
    {
        private int _product1;
        private int _product2;
        private int _product3;

        public ForecastPeriod(int _product1, int _product2, int _product3)
        {
            this.Product1 = _product1;
            this.Product2 = _product2;
            this.Product3 = _product3;
        }

        public int Product1
        {
            get
            {
                return _product1;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _product1 = value;
            }
        }

        public int Product2
        {
            get
            {
                return _product2;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _product2 = value;
            }
        }

        public int Product3
        {
            get
            {
                return _product3;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _product3 = value;
            }
        }
    }
}
