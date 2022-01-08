using System;

namespace _03._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int necessaryResult = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int number1 = 0; number1 <= necessaryResult; number1++)
            {
                for (int number2 = 0; number2 <= necessaryResult; number2++)
                {
                    for (int number3 = 0; number3 <= necessaryResult; number3++)
                    {
                        if (number1 + number2 + number3 == necessaryResult)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}