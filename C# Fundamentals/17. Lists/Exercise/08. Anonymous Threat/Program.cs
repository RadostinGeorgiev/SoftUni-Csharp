using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();
            while (input != "3:1")
            {
                string[] commands = input.Split();
                string command = commands[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    startIndex = Math.Max(startIndex, 0);
                    startIndex = Math.Min(startIndex, inputLine.Count - 1);

                    int endIndex = int.Parse(commands[2]);
                    endIndex = Math.Max(endIndex, 0);
                    endIndex = Math.Min(endIndex, inputLine.Count - 1);

                    string mergedString = string.Empty;
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        mergedString += inputLine[i];
                    }

                    inputLine[startIndex] = mergedString;
                    inputLine.RemoveRange(startIndex + 1, endIndex - startIndex);
                }
                else if (command == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);
                    List<string> dividedList = DivideString(inputLine[index], partitions);

                    inputLine.RemoveAt(index);
                    inputLine.InsertRange(index, dividedList);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', inputLine));
        }

        static List<string> DivideString(string input, int pieces)
        {
            int pieceLength = input.Length / pieces;
            List<string> outputList = new List<string>();

            for (int i = 0; i < pieces - 1; i++)
            {
                outputList.Add(input.Substring(i * pieceLength, pieceLength));
            }

            outputList.Add(input.Substring((pieces - 1) * pieceLength));

            return outputList;
        }

    }
}
