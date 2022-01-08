using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());

            int presentationCounter = 0;
            double total = 0.00;

            string presentation;
            while ((presentation = Console.ReadLine()) != "Finish")
            {
                presentationCounter++;
                double averageRating = 0;

                for (int i = 0; i < peoples; i++)
                {
                    averageRating += double.Parse(Console.ReadLine());
                }

                averageRating /= peoples;
                total += averageRating;
                Console.WriteLine($"{presentation} - {averageRating:F2}.");
            }

            Console.WriteLine($"Student's final assessment is {total / presentationCounter:F2}.");
        }
    }
}