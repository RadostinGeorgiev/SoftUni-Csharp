using System;

namespace _01._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number1; i++)
            {
                for (int j = 2; j <= number2; j++)
                {
                    bool jIsPrime = true;

                    for (int k1 = 2; k1 * k1 <= j; k1++)
                    {
                        if (j % k1 == 0)
                        {
                            jIsPrime = false;
                        }
                    }

                    for (int k2 = 1; k2 <= number3; k2++)
                    {
                        if ((i % 2 == 0) && jIsPrime && (k2 % 2 == 0))
                        {
                            Console.WriteLine($"{i} {j} {k2}");
                        }
                    }
                }
            }
        }
    }
}