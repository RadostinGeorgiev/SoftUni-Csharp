using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

class Box
{
    public int Width { get; set; }
    public int Depth { get; set; }
    public int Height { get; set; }

    public override string ToString()
    {
        return string.Format($"{this.Width} {this.Depth} {this.Height}");
    }
}

namespace _02._Boxes
{
    internal class Program
    {
        private static int[] length;
        private static int[] prevs;

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Box[] boxes = new Box[number];

            for (int i = 0; i < boxes.Length; i++)
            {
                int[] boxData = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

                boxes[i] = new Box
                {
                    Width = boxData[0],
                    Depth = boxData[1],
                    Height = boxData[2],
                };
            }

            length = new int[boxes.Length];
            prevs = new int[boxes.Length];

            int bestLength = 0;
            int bestIndex = -1;

            for (int current = 0; current < boxes.Length; current++)
            {
                int currentLength = 1;
                int prevIndex = -1;

                Box currentNumber = boxes[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    Box prevNumber = boxes[prev];
                    int prevLength = length[prev];

                    if (currentNumber.Width > prevNumber.Width &&
                        currentNumber.Depth > prevNumber.Depth &&
                        currentNumber.Height > prevNumber.Height &&
                        currentLength <= prevLength + 1)
                    {
                        currentLength = prevLength + 1;
                        prevIndex = prev;
                    }
                }

                length[current] = currentLength;
                prevs[current] = prevIndex;

                if (currentLength > bestLength) //> for left-most; >= for right-most
                {
                    bestLength = currentLength;
                    bestIndex = current;
                }
            }

            //Console.WriteLine(bestLength);
            //Console.WriteLine(bestIndex);
            Console.WriteLine(string.Join(Environment.NewLine, GetLIS(boxes, prevs, bestIndex)));
        }

        private static Stack<Box> GetLIS(Box[] sequence, int[] prevs, int index)
        {
            Stack<Box> lis = new Stack<Box>();

            while (index != -1)
            {
                lis.Push(sequence[index]);
                index = prevs[index];
            }

            return lis;
        }
    }
}