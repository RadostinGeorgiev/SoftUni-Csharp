using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumPrime = 0;
            int sumNonPrime = 0;

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                int currentNumber = int.Parse(command);

                if (currentNumber >= 0)
                {
                    bool isPrime = true;

                    for (int i = 2; i * i <= currentNumber; i++)
                    {
                        if (currentNumber % i == 0) isPrime = false;
                    }

                    if (isPrime)
                        sumPrime += currentNumber;
                    else
                        sumNonPrime += currentNumber;
                }
                else
                {
                    Console.WriteLine("Number is negative.");
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}