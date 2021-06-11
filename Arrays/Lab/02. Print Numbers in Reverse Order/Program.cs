using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            int[] array = new int[numbers];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            array = array.Reverse().ToArray();

            foreach (var i in array)
            {
                Console.Write(i + " ");
            }
        }
    }
}
