using System;

namespace _04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsOnExam = int.Parse(Console.ReadLine());

            int students3 = 0;
            int students4 = 0;
            int students5 = 0;
            int students6 = 0;
            double total = 0.0;

            for (int i = 0; i < studentsOnExam; i++)
            {
                double studentRating = double.Parse(Console.ReadLine());

                if (studentRating <= 2.99)
                    students3++;
                else if (studentRating <= 3.99)
                    students4++;
                else if (studentRating <= 4.99)
                    students5++;
                else if (studentRating >= 5)
                    students6++;

                total += studentRating;
            }
            Console.WriteLine($"Top students: {(double)students6 / studentsOnExam * 100:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(double)students5 / studentsOnExam * 100:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(double)students4 / studentsOnExam * 100:F2}%");
            Console.WriteLine($"Fail: {(double)students3 / studentsOnExam * 100:F2}%");
            Console.WriteLine($"Average: {total / studentsOnExam:F2}");
        }
    }
}