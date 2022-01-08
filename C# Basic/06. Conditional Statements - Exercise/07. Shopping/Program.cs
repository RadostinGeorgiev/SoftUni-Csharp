namespace Shopping
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            const double videocardPrice = 250.0;


            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            double cpuPrice = videoCards * videocardPrice * 0.35;
            int cpu = int.Parse(Console.ReadLine());
            double memoryPrice = videoCards * videocardPrice * 0.1;
            int memory = int.Parse(Console.ReadLine());

            double totalPrice = videoCards * videocardPrice + cpu * cpuPrice + memory * memoryPrice;

            if (videoCards > cpu)
            {
                totalPrice -= totalPrice * 0.15;
            }

            Console.WriteLine(budget >= totalPrice
                ? $"You have {budget - totalPrice:F2} leva left!"
                : $"Not enough money! You need {totalPrice - budget:F2} leva more!");
        }
    }
}