using System;
using System.Linq;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            //char char1 = char.Parse(Console.ReadLine());
            //char char2 = char.Parse(Console.ReadLine());
            //char char3 = char.Parse(Console.ReadLine());
            //Console.WriteLine($"{char3} {char2} {char1}");

            char[] arr = new char[3];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = char.Parse(Console.ReadLine());
            }

            arr = arr.Reverse().ToArray();

            foreach (var t in arr)
            {
                Console.Write(t + " ");
            }
        }
    }
}
