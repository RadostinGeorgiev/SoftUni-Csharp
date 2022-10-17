namespace _03._Longest_String_Chain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int[] length;
        private static int[] prevs;

        static void Main(string[] args)
        {
            string[] stringsSequence = Console.ReadLine()
                                              .Split()
                                              .ToArray();

            int[] lengthsSequence = new int[stringsSequence.Length];
            for (int i = 0; i < stringsSequence.Length; i++)
            {
                lengthsSequence[i] = stringsSequence[i].Length;
            }

            length = new int[lengthsSequence.Length];
            prevs = new int[lengthsSequence.Length];

            int bestLength = 0;
            int bestIndex = -1;

            for (int current = 0; current < lengthsSequence.Length; current++)
            {
                int currentLength = 1;
                int prevIndex = -1;

                int currentNumber = lengthsSequence[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    int prevNumber = lengthsSequence[prev];
                    int prevLength = length[prev];

                    if (currentNumber > prevNumber &&
                        currentLength <= prevLength + 1)
                    {
                        currentLength = prevLength + 1;
                        prevIndex = prev;
                    }
                }

                length[current] = currentLength;
                prevs[current] = prevIndex;

                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                    bestIndex = current;
                }
            }

            Console.WriteLine(string.Join(' ', GetLIS(stringsSequence, prevs, bestIndex)));
        }

        private static Stack<string> GetLIS(string[] sequence, int[] prevs, int index)
        {
            Stack<string> lis = new Stack<string>();

            while (index != -1)
            {
                lis.Push(sequence[index]);
                index = prevs[index];
            }

            return lis;
        }
    }
}