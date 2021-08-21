using System;

namespace _04._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTribonacci(number);
        }

        static void PrintTribonacci(int input)
        {
            int[] output = new int[input];

            output[0] = 1;
            if (input >= 2)
            {
                output[1] = 1;
            }

            if (input >= 3)
            {
                output[2] = 2;
            }

            if (input >= 3)
            {
                for (int i = 3; i < output.Length; i++)
                {
                    output[i] = output[i - 3] + output[i - 2] + output[i - 1];
                }
            }

            Console.WriteLine(string.Join(' ', output));
        }
    }
}
