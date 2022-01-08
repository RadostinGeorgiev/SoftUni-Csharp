using System;

namespace _07._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int total = 0;

            for (int i = 0; i < number; i++)
            {
                total += int.Parse(Console.ReadLine());;
            }

            Console.WriteLine(total);
        }
    }
}