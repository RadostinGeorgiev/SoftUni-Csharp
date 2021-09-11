using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .Select(x => x * 1.2)
                    .Select(x => $"{x:F2}")
                    .ToList()
                    .ForEach(Console.WriteLine);
        }
    }
}
