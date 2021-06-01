using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char currentSymbol = char.Parse(Console.ReadLine());

            if (currentSymbol >= 65 && currentSymbol <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (currentSymbol >= 97 && currentSymbol <= 122)
            {
                Console.WriteLine("lower-case");
            }

        }
    }
}
