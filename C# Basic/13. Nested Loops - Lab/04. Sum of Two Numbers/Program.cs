using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            bool isFounded = false;

            for (int i = number1; i <= number2; i++)
            {
                for (int j = number1; j <= number2; j++)
                {
                    counter++;

                    if (i + j != magicalNumber) continue;

                    Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicalNumber})");
                    isFounded = true;
                    break;
                }

                if (isFounded)
                {
                    break;
                }
            }

            if (!isFounded)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicalNumber}");
            }

        }
    }
}