using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            StringBuilder sb = new StringBuilder();

            foreach (var s in input)
            {
                for (int i = 1; i <= s.Length; i++)
                {
                    sb.Append(s);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
