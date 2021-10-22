using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            int wreaths = 0;
            int sum = 0;
            int storedFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                sum = lilies.Peek() + roses.Peek();

                if (sum < 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    storedFlowers += sum;
                }
                else if (sum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else //(sum == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            wreaths += storedFlowers / 15;
            Console.WriteLine(wreaths >= 5
                ? $"You made it, you are going to the competition with {wreaths} wreaths!"
                : $"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}