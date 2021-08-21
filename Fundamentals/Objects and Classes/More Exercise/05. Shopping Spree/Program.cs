using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();

            string[] peoplesInfo = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peoplesInfo.Length; i += 2)
            {
                string name = peoplesInfo[i];
                decimal money = decimal.Parse(peoplesInfo[i + 1]);
                Person person = new Person(name, money);
                peoples.Add(person);
            }

            List<Product> products = new List<Product>();

            string[] productsInfo = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInfo.Length; i += 2)
            {
                string name = productsInfo[i];
                decimal cost = decimal.Parse(productsInfo[i + 1]);
                Product product = new Product(name, cost);
                products.Add(product);
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] purchase = input.Split();
                string personName = purchase[0];
                string productName = purchase[1];

                peoples.First(x => x.Name == personName).AffordProduct(products.First(x => x.Name == productName));

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, peoples));
        }
    }

    class Person
    {
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        private List<Product> BagOfProducts;

        public void AffordProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                BagOfProducts.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (BagOfProducts.Count > 0)
            {
                return $"{Name} - {string.Join(", ", BagOfProducts)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }

        }
    }

    class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
