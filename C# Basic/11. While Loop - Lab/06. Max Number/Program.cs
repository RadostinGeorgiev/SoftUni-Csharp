using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.MinValue;

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                int currentNumber = int.Parse(input);

                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}