using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int currentLength = 1;
            int startIndex = 0;
            int maxLength = 1;
            int maxStartIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    currentLength = 1;
                    startIndex = i;
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxStartIndex = startIndex;
                }
            }

            for (int p = maxStartIndex; p < maxStartIndex + maxLength; p++)
            {
                Console.Write(array[p] + " ");
            }
        }
    }
}
