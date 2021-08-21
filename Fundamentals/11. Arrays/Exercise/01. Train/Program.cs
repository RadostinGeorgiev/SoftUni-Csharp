using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWagons = int.Parse(Console.ReadLine());

            int[] passengers = new int[numberWagons];
            int sum = 0;

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = int.Parse(Console.ReadLine());
                sum += passengers[i];
            }

            Console.WriteLine(String.Join(' ', passengers));
            Console.WriteLine(sum);
        }
    }
}