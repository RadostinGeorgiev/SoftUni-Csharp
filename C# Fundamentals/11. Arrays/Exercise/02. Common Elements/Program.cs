using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] firstString = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .ToArray();
            //string[] secondString = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .ToArray();

            //for (int i = 0; i < secondString.Length; i++)
            //{
            //    for (int j = 0; j < firstString.Length; j++)
            //    {
            //        if (secondString[i] == firstString[j])
            //        {
            //            Console.Write(firstString[j] + ' ');
            //        }
            //    }
            //}

            string[] array1 = Console.ReadLine().Split();
            string[] array2 = Console.ReadLine().Split();

            foreach (var item2 in array2)
            {
                foreach (var item1 in array1)
                {
                    if (item1 == item2)
                    {
                        Console.Write(item1 + ' ');
                    }
                }
            }
        }
    }
}
