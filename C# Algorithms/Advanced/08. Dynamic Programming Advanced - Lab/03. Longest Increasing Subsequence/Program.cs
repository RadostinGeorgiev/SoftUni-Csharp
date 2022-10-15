namespace _03._Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        public static int[] length;
        public static int[] prevs;
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            length = new int[sequence.Length];
            prevs = new int[sequence.Length];

            int bestLength = 0;
            int bestIndex = -1;

            for (int current = 0; current < sequence.Length; current++)
            {
                var currentLength = 1;
                var prevIndex = -1;

                int currentNumber = sequence[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevNumber = sequence[prev];
                    var prevLength = length[prev];

                    if (currentNumber > prevNumber &&
                        currentLength <= prevLength + 1)
                    {
                        currentLength = prevLength + 1;
                        prevIndex = prev;
                    }
                }

                length[current] = currentLength;
                prevs[current] = prevIndex;

                if (currentLength > bestLength)             //> for left-most; >= for right-most
                {
                    bestLength = currentLength;
                    bestIndex = current;
                }
            }

            //Console.WriteLine(bestLength);
            //Console.WriteLine(bestIndex);
            Console.WriteLine(String.Join(' ', GetLIS(sequence, prevs, bestIndex))); 
        }

        private static Stack<int> GetLIS(int[] sequence, int[] prevs, int index)
        {
            Stack<int> lis = new Stack<int>();

            while (index != -1)
            {
                lis.Push(sequence[index]);
                index = prevs[index];
            }

            return lis;
        }
    }
}
