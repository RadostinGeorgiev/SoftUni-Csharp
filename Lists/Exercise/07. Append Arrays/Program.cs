using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            List<int> output = new List<int>();

            foreach (var item in arrays)
            {
                int[] currentArray = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach (var num in currentArray)
                {
                    output.Add(num);
                }
            }

            Console.WriteLine(string.Join(' ', output));
        }
    }
}
