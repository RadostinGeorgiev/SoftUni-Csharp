using System;

namespace _11._HappyCat_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double total = 0.00;

            for (int i = 1; i <= days; i++)
            {
                double taxPerDay = 0.00;
                for (int j = 1; j <= hours; j++)
                {
                    double tax = 0.00;
                    if (i % 2 == 0 && j %2 != 0)
                        tax = 2.50;
                    else if (i % 2 != 0 && j % 2 == 0)
                        tax = 1.25;
                    else
                        tax = 1;

                    taxPerDay += tax;
                }
                Console.WriteLine($"Day: {i} - {taxPerDay:F2} leva");
                total += taxPerDay;
            }

            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}