using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Console.WriteLine(GetMiddle(text));
        }

        static string GetMiddle(string input)
        {
            int middle = input.Length / 2;
            if (input.Length % 2 == 0)
            {
               return input[middle - 1].ToString() + input[middle].ToString(); 
            }
            else
            {
                return input[middle].ToString();
            }

        }
    }
}
