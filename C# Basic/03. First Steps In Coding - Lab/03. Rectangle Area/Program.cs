using System;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int area = length * width;

            Console.WriteLine(area);
        }
    }
}