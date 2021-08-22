using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiencyFirstEmploye = int.Parse(Console.ReadLine());
            int efficiencySecondEmploye = int.Parse(Console.ReadLine());
            int efficiencyThirdEmploye = int.Parse(Console.ReadLine());
            int totalPeoples = int.Parse(Console.ReadLine());

            int efficiencyTotal = efficiencyFirstEmploye + efficiencySecondEmploye + efficiencyThirdEmploye;
            int time = 0;
            while (totalPeoples > 0)
            {
                time++;
                if (time % 4 == 0)
                {
                    continue;
                }
                totalPeoples -= efficiencyTotal;
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
