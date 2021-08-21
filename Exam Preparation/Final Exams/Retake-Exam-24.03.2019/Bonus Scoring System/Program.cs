using System;

namespace _1.Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int maxAttendance = 0;

            for (int i = 1; i <= studentsCount; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());
                double totalBonus = (double)studentAttendances / lecturesCount * (5 + initialBonus);
                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendance = studentAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {(int)Math.Ceiling(maxAttendance * 1.0)} lectures.");
        }

    }
}
