using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(number);
            for (int i = 0; i < number; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"{i}.{products[i-1]}");
            }
        }
    }
}
