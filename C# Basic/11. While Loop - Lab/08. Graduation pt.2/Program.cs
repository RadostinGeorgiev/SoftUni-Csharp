using System;

namespace _08._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameStudent = Console.ReadLine();
            int currentClass = 1;
            double total = 0.00;
            bool tornOnExam = false;

            while (currentClass <= 12)
            {
                double currentRating = double.Parse(Console.ReadLine());

                if (currentRating >= 4.0)
                {
                    total += currentRating;
                    currentClass++;
                }
                else if (tornOnExam)
                {
                    Console.WriteLine($"{nameStudent} has been excluded at {currentClass} grade");
                    break;
                }
                else
                {
                    tornOnExam = true;
                }
            }

            if (!tornOnExam)
            {
                Console.WriteLine($"{nameStudent} graduated. Average grade: {total / 12:F2}");
            }
        }
    }
}