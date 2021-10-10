using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();
            var tuple = new Tuple<string, string>($"{info[0]} {info[1]}", info[2]);
            Console.WriteLine(tuple);

            info = Console.ReadLine().Split();
            var tuple2 = new Tuple<string, int>(info[0], int.Parse(info[1]));
            Console.WriteLine(tuple2);

            info = Console.ReadLine().Split();
            var tuple3 = new Tuple<int, double>(int.Parse(info[0]), double.Parse(info[1]));
            Console.WriteLine(tuple3);
        }
    }
}