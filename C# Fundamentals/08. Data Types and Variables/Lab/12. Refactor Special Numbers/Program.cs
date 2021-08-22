using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int currentNumber = 1; currentNumber <= number; currentNumber++)
            {
                int sum = 0;
                bool isSpecial = false;
                int digit = currentNumber;

                while (digit > 0)
                {
                    sum += digit % 10;
                    digit = digit / 10;
                }

                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", currentNumber, isSpecial);
            }
        }
    }
}
