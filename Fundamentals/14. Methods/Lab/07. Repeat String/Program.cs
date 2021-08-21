using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(StringMultiplication(inputString, number));
        }

        static string StringMultiplication(string input, int repetitions)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 1; i <= repetitions; i++)
            {
                output.Append(input);
            }

            return output.ToString();
        }
    }
}
