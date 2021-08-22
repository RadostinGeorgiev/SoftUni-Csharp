using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            Console.WriteLine(GradeByWords(grade));
        }

        static string GradeByWords(double input)
        {
            if (input >= 2.0 && input < 3.0)
            {
                return "Fail";
            }
            else if (input >= 3.0 && input < 3.50)
            {
                return "Poor";
            }
            else if (input >= 3.50 && input < 4.50)
            {
                return "Good";
            }
            else if (input >= 4.50 && input < 5.50)
            {
                return "Very good";
            }
            else
            {
                return "Excellent";
            }
        }
    }
}
