using System;

namespace _03.Shopping_Spree
{
    public class Product
    {
        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        private string name;
        private int cost;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Cost
        {
            get => cost;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                cost = value;
            }
        }

        public override string ToString() => this.Name;
    }
}