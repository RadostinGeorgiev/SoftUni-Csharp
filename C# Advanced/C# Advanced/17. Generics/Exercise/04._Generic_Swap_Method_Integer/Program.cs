using System;
using System.Linq;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var data = new Box<int>();
            for (int i = 0; i < lines; i++)
            {
                data.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            data.Swap(indexes[0], indexes[1]);

            Console.WriteLine(data);
        }
    }
}