using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInfo = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine()
               .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (var i = 0; i < peopleInfo.Length; i += 2)
                {
                    string name = peopleInfo[i];
                    int money = int.Parse(peopleInfo[i + 1]);

                    Person person = new Person(name, money);
                    peoples.Add(person);
                }

                for (var i = 0; i < productsInfo.Length; i += 2)
                {
                    string name = productsInfo[i];
                    int cost = int.Parse(productsInfo[i + 1]);

                    Product product = new Product(name, cost);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string purchase;
            while ((purchase = Console.ReadLine()) != "END")
            {
                string[] purchaseArgs = purchase.Split();
                string name = purchaseArgs[0];
                string productName = purchaseArgs[1];

                try
                {
                    Person person = peoples.First(x => x.Name == name);
                    Product product = products.First(x => x.Name == productName);

                    person.Buy(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var people in peoples)
            {
                Console.WriteLine(people);
            }
        }
    }
}