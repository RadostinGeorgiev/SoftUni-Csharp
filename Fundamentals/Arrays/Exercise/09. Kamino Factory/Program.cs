using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthSequences = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int sequenceIndex = 0;
            int bestSequenceIndex = 1;
            int bestSequenceLength = 1;
            int bestSequencePosition = 0;
            int bestSequenceSum = 0;
            int[] bestSequence = new int[lengthSequences];

            while (command != "Clone them!")
            {

// ----------------------------------- CURRENT SAMPLE ----------------------------------               
                int[] sequenceDNA = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                bool isBetterSample = false;
                sequenceIndex++;

                int currentLength = 1;
                int bestCurrentLength = 1;
                int currentPosition = 0;
                int bestCurrentPosition = 0;
                int currentSum = 0;

                for (int i = 0; i < sequenceDNA.Length - 1; i++)
                {
                    if (sequenceDNA[i] == 1 && sequenceDNA[i] == sequenceDNA[i + 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        currentLength = 1;
                        currentPosition = i + 1;
                    }

                    if (currentLength > bestCurrentLength)
                    {
                        bestCurrentLength = currentLength;
                        bestCurrentPosition = currentPosition;
                    }

                    currentSum += sequenceDNA[i];
                }
                currentSum += sequenceDNA[lengthSequences - 1];

// ----------------------------------- SEQUENCE ----------------------------------               

                if (bestCurrentLength > bestSequenceLength)
                {
                    isBetterSample = true;
                }
                else if (bestCurrentLength == bestSequenceLength)
                {
                    if (bestCurrentPosition < bestSequencePosition)
                    {
                        isBetterSample = true;
                    }
                    else if (bestCurrentPosition == bestSequencePosition)
                    {
                        if (currentSum > bestSequenceSum)
                        {
                            isBetterSample = true;
                        }
                    }
                }

                if (isBetterSample)
                {
                    bestSequenceLength = bestCurrentLength;
                    bestSequencePosition = bestCurrentPosition;
                    bestSequenceIndex = sequenceIndex;
                    bestSequenceSum = currentSum;
                    bestSequence = sequenceDNA.ToArray();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(String.Join(' ', bestSequence));
        }
    }
}
