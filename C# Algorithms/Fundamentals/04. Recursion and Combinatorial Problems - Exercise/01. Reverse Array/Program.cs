namespace Reverse_Array
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[] array;

        static void Main(string[] args)
        {
            array = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            Reverse(0);
        }

        private static void Reverse(int index)
        {
            if (index == array.Length / 2)
            {
                Console.WriteLine(string.Join(' ', array));
                return;
            }

            Swap(index, array.Length - index - 1);
            Reverse(index + 1);
        }

        private static void Swap(int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}