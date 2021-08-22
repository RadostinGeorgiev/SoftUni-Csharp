using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string customer = String.Empty;
            Queue<string> customers = new Queue<string>();
            while ((customer = Console.ReadLine()) != "End")
            {
                if (customer.Equals("Paid"))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, customers));
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(customer);
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
