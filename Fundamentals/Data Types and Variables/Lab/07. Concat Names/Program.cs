using System;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[3];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Console.ReadLine();
            }

            Console.WriteLine($"{arr[0]}{arr[2]}{arr[1]}");
        }
    }
}
