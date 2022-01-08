using System;

namespace _08._Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int previousSum = 0;
            int difference = 0;
            int maxDifference = 0;

            for (int i = 0; i < number; i++)
            {
                int numberOdd = int.Parse(Console.ReadLine());
                int numberEven = int.Parse(Console.ReadLine());

                int currentSum = numberOdd + numberEven;

                if (i != 0)
                {
                    difference = Math.Abs(previousSum - currentSum);
                }

                previousSum = currentSum;

                if (difference > maxDifference)
                {
                    maxDifference = difference;
                }
            }

            Console.WriteLine(maxDifference == 0 ? $"Yes, value={previousSum}" : $"No, maxdiff={maxDifference}");
        }
    }
}