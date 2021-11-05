using System;
using System.Collections.Generic;

namespace _03.Shopping_Spree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bagOfProducts;

        public Person()
        {
            bagOfProducts = new List<Product>();
        }
        public Person(string name, int money)
        : base()
        {
            Name = name;
            Money = money;
        }

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

        public int Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyList<Product> Bag => bagOfProducts.AsReadOnly();

        public void Buy(Product product)
        {
            if (Money < product.Cost)
            {
                throw new InvalidOperationException($"{Name} can't afford {product.Name}");
            }

            bagOfProducts.Add(product);
            Money -= product.Cost;
            Console.WriteLine($"{Name} bought {product.Name}");
        }

        public override string ToString() 
            => $"{Name} - {(Bag.Count > 0 ? string.Join(", ", Bag) : "Nothing bought")}";
    }
}