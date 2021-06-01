using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string currentNumber = i.ToString();
                int currentSum = 0;

                for (int j = 0; j < currentNumber.Length; j++)
                {
                    currentSum += int.Parse(currentNumber[j].ToString());
                }

                if (currentSum == 5 || currentSum == 7 || currentSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
