using System;

namespace _06._Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            double totalElectricity = 0.00;
            double totalWater = 0.00;
            double totalInternet = 0.00;
            double totalOther = 0.00;

            for (int i = 0; i < months; i++)
            {
                double billElectricity = double.Parse(Console.ReadLine());

                totalElectricity += billElectricity;
                totalWater += 20.00;
                totalInternet += 15.00;
                totalOther += (billElectricity+20+15)*1.20;
            }

            Console.WriteLine($"Electricity: {totalElectricity:F2} lv");
            Console.WriteLine($"Water: {totalWater:F2} lv");
            Console.WriteLine($"Internet: {totalInternet:F2} lv");
            Console.WriteLine($"Other: {totalOther:F2} lv");
            Console.WriteLine($"Average: {(totalElectricity+totalWater+totalInternet+totalOther)/months:F2} lv");
        }
    }
}