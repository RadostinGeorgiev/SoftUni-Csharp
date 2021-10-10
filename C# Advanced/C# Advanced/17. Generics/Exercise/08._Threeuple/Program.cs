using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split(' ', 4, StringSplitOptions.RemoveEmptyEntries);
            var threeuple = new Threeuple<string, string, string>($"{info[0]} {info[1]}", info[2], info[3]);
            Console.WriteLine(threeuple);

            info = Console.ReadLine().Split();
            var threeuple2 = new Threeuple<string, int, bool>(info[0], int.Parse(info[1]), info[2] == "drunk");
            Console.WriteLine(threeuple2);

            info = Console.ReadLine().Split();
            var threeuple3 = new Threeuple<string, double, string>(info[0], double.Parse(info[1]), info[2]);
            Console.WriteLine(threeuple3);
        }
    }
}