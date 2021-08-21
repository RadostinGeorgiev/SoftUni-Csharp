using System;
using System.Linq;

namespace _05._Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // TESTS
            //string input = "1";
            //string input = "7 3 5 8 -1 0 6 7";
            //string input = "1 2 5 3 5 2 4 1";
            // string input = "0 10 20 30 30 40 1 50 2 3 4 5 6";
            // string input = "11 12 13 3 14 4 15 5 6 7 8 7 16 9 8";
            //string input = "3 14 5 12 15 7 8 9 11 10 1";

            //int[] nums = input
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] len = new int[nums.Length];
            int[] prev = new int[nums.Length];
            int maxLength = 0;
            int maxIndex = -1;

            for (int p = 0; p < nums.Length; p++)
            {
                len[p] = 1;
                prev[p] = -1;

                for (int left = 0; left < p; left++)
                {
                    if ((nums[left] < nums[p]) && (len[left] + 1 > len[p]))
                    {
                        len[p] = len[left] + 1;
                        prev[p] = left;
                    }
                }

                if (len[p] > maxLength)
                {
                    maxLength = len[p];
                    maxIndex = p;
                }
            }

            //Console.WriteLine(string.Join(' ', nums));
            //Console.WriteLine(string.Join(' ', len));
            //Console.WriteLine(string.Join(' ', prev));
            //Console.WriteLine(maxLength);
            //Console.WriteLine(maxIndex);

            int[] output = new int[maxLength];
            int currentIndex = maxIndex;

            for (int i = output.Length - 1; i >= 0; i--)
            {
                output[i] = nums[currentIndex];
                currentIndex = prev[currentIndex];
            }

            Console.WriteLine(string.Join(' ', output));
        }
    }
}
