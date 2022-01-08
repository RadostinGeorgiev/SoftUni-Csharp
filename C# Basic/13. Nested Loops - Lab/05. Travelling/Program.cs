using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination;
            while ((destination = Console.ReadLine()) != "End")
            {
                double minimalBudget = double.Parse(Console.ReadLine());
                double totalSum = 0;

                while (totalSum < minimalBudget)
                {
                    totalSum += double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}