using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            for (int i = 1; i <= numberOfPieces; i++)
            {
                string[] info = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string piece = info[0];
                string composer = info[1];
                string key = info[2];

                pieces.Add(piece, new List<string>() { composer, key });
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string piece = commands[1];

                switch (command)
                {
                    case "Add":
                        string composer = commands[2];
                        string key = commands[3];

                        if (pieces.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        else
                        {
                            pieces.Add(piece, new List<string>() { composer, key });
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        break;
                    case "Remove":
                        if (pieces.ContainsKey(piece))
                        {
                            pieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = commands[2];

                        if (pieces.ContainsKey(piece))
                        {
                            pieces[piece][1] = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                }
            }

            foreach (var keyValuePair in pieces
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{keyValuePair.Key} -> Composer: {keyValuePair.Value[0]}, Key: {keyValuePair.Value[1]}");
            }
        }
    }
}
