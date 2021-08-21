using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split()
                .ToArray();
            array = array.Reverse().ToArray();

            foreach (var s in array)
            {
                Console.Write(s + " ");
            }
        }
    }
}
