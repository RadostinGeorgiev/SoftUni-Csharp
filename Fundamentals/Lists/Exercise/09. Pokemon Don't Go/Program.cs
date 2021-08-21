using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int currentValue = 0;
            int sum = 0;

            while (sequence.Count != 0)
            {
                int currentIndex = int.Parse(Console.ReadLine());

                if (currentIndex < 0)
                {
                    currentIndex = 0;
                    sequence.Insert(1, sequence[sequence.Count - 1]);
                }
                else if (currentIndex > sequence.Count - 1)
                {
                    currentIndex = sequence.Count - 1;
                    sequence.Add(sequence[0]);
                }

                currentValue = sequence[currentIndex];
                sum += currentValue;
                sequence.RemoveAt(currentIndex);

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (currentValue >= sequence[i])
                    {
                        sequence[i] += currentValue;
                    }
                    else
                    {
                        sequence[i] -= currentValue;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
