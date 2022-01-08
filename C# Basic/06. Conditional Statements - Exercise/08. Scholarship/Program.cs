using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double payment = double.Parse(Console.ReadLine());
            double rating = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarshipAmount = 0.00;
            double schoolScholarshipAmount = 0.00;

            if ((rating <= 4.5) || ((payment > minSalary) && (rating < 5.5)))
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else
            {
                if (payment < minSalary)
                {
                    socialScholarshipAmount = minSalary * 0.35;
                }

                if (rating >= 5.5)
                {
                    schoolScholarshipAmount = rating * 25;
                }

                Console.WriteLine(socialScholarshipAmount > schoolScholarshipAmount
                    ? $"You get a Social scholarship {Math.Floor(socialScholarshipAmount)} BGN"
                    : $"You get a scholarship for excellent results {Math.Floor(schoolScholarshipAmount)} BGN");
            }
        }
    }
}