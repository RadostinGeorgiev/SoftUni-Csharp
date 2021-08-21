using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiencyEmploye1 = int.Parse(Console.ReadLine());
            int efficiencyEmploye2 = int.Parse(Console.ReadLine());
            int efficiencyEmploye3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int efficiencyTotalEmploye = efficiencyEmploye1 + efficiencyEmploye2 + efficiencyEmploye3;
            int time = 0;

            while (studentsCount > 0)
            {
                time++;
                if (time % 4 == 0)
                {
                    continue;
                }

                studentsCount -= efficiencyTotalEmploye;
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
