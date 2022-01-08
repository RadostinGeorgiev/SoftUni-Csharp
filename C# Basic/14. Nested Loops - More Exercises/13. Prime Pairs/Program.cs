using System;

namespace _13._Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int startFirstNumbers = int.Parse(Console.ReadLine());
            int startSecondNumbers = int.Parse(Console.ReadLine());
            int incrementFirstNumbers = int.Parse(Console.ReadLine());
            int incrementSecondNumbers = int.Parse(Console.ReadLine());

            for (int i = startFirstNumbers; i <= startFirstNumbers + incrementFirstNumbers; i++)
            {
                var firstIsPrime = true;

                for (int k = 2; k * k <= i; k++)
                {
                    if (i % k == 0) firstIsPrime = false;
                }

                var firstPrimeNumber = 0;

                if (firstIsPrime)
                {
                    firstPrimeNumber = i;

                    for (int j = startSecondNumbers; j <= startSecondNumbers + incrementSecondNumbers; j++)
                    {
                        var secondIsPrime = true;
                        for (int k = 2; k * k <= j; k++)
                        {
                            if (j % k == 0)
                            {
                                secondIsPrime = false;
                                break;
                            }
                        }

                        if (secondIsPrime)
                        {
                            var secondPrimeNumber = j;
                            Console.WriteLine($"{firstPrimeNumber}{secondPrimeNumber} ");
                            secondPrimeNumber = 0;
                        }
                    }
                }

                firstPrimeNumber = 0;
            }
        }
    }
}