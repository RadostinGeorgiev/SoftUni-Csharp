namespace OnlineShop.Models.Products
{
    using System;
    using static Common.Constants.ExceptionMessages;
    using static Common.Constants.SuccessMessages;

    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => this.id;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidProductId);
                }

                this.id = value;
            }
        }

        public string Manufacturer
        {
            get => this.manufacturer;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidManufacturer);
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidModel);
                }

                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidPrice);
                }

                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => this.overallPerformance;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidOverallPerformance);
                }

                this.overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return string.Format(ProductToString, 
                OverallPerformance.ToString("F2"), 
                Price.ToString("F2"), 
                this.GetType().Name, 
                Manufacturer, 
                Model, 
                Id);
        }
    }
}