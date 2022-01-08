using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxBadGrades = int.Parse(Console.ReadLine());

            int badGrades = 0;
            int total = 0;
            int numGrades = 0;
            string lastTask = "";

            string taskName;
            while ((taskName = Console.ReadLine()) != "Enough")
            {
                int currentGrade = int.Parse(Console.ReadLine());

                if (currentGrade <= 4)
                {
                    badGrades++;
                }

                total += currentGrade;
                numGrades++;

                if (badGrades == maxBadGrades)
                {
                    Console.WriteLine($"You need a break, {badGrades} poor grades.");
                    break;
                }

                lastTask = taskName;
            }

            if (taskName == "Enough")
            {
                Console.WriteLine($"Average score: {1.0 * total / numGrades:F2}");
                Console.WriteLine($"Number of problems: {numGrades}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
        }
    }
}