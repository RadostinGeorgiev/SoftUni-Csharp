using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int minNumber = int.MaxValue;

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                int currentNumber = int.Parse(input);

                if (currentNumber < minNumber)
                {
                    minNumber = currentNumber;
                }
            }

            Console.WriteLine(minNumber);
        }
    }
}