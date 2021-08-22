using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (input != "find")
            {
                int keyIndex = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (keyIndex == key.Length)
                    {
                        keyIndex = 0;
                    }

                    sb.Append((char)(input[i] - key[keyIndex]));
                    keyIndex++;
                }

                string typePattern = @"&(?<type>\w+)&";
                string coordinatesPattern = @"<(?<coordinates>\w+)>";

                var type = Regex.Match(sb.ToString(), typePattern).Groups["type"].Value;
                var coordinates = Regex.Match(sb.ToString(), coordinatesPattern).Groups["coordinates"].Value;

                Console.WriteLine($"Found {type} at {coordinates}");
                sb.Clear();

                input = Console.ReadLine();
            }
        }
    }
}
