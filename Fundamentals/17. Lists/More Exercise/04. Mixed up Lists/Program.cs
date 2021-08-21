using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int startRange = 0;
            int endRange = 0;
            int iterations = 0;

            if (firstList.Count > secondList.Count)
            {
                startRange = Math.Min(firstList[firstList.Count - 2], firstList[firstList.Count - 1]);
                endRange = Math.Max(firstList[firstList.Count - 2], firstList[firstList.Count - 1]);
                iterations = secondList.Count;
            }
            else
            {
                startRange = Math.Min(secondList[0], secondList[1]);
                endRange = Math.Max(secondList[0], secondList[1]);
                iterations = firstList.Count;

            }

            List<int> result = new List<int>();

            for (int i = 0; i < iterations; i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[secondList.Count - 1 - i]);
            }

            List<int> output = result.Where(x => x > startRange & x < endRange).OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(' ', output));
        }
    }
}
