using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                var array = input.ToCharArray();
                Array.Reverse(array);
                var result = new string(array);
                Console.WriteLine($"{input} = {result}");
            }

        }
    }
}
