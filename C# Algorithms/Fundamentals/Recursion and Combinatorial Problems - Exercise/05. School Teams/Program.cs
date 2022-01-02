namespace _05._School_Teams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Channels;

    class Program
    {
        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine().Split(", ");
            var girlsCombinations = new string[3];
            var listOfGirlsCombinations = new List<string[]>();

            string[] boys = Console.ReadLine().Split(", ");
            var boysCombinations = new string[2];
            var listOfBoysCombinations = new List<string[]>();

            GetCombinations(listOfGirlsCombinations, girlsCombinations, girls, 0, 0);
            GetCombinations(listOfBoysCombinations, boysCombinations, boys, 0, 0);

            PrintResult(listOfGirlsCombinations, listOfBoysCombinations);
        }

        private static void PrintResult(List<string[]> listOfGirlsCombinations, List<string[]> listOfBoysCombinations)
        {
            foreach (var girls in listOfGirlsCombinations)
            {
                foreach (var boys in listOfBoysCombinations)
                {
                    Console.WriteLine($"{string.Join(", ", girls)}, {string.Join(", ", boys)}");
                }
            }
        }

        private static void GetCombinations(List<string[]> result, string[] combinations, string[] names, int index, int namesIndex)
        {
            if (index == combinations.Length)
            {
                result.Add(combinations.ToArray());
                return;
            }

            for (int i = namesIndex; i < names.Length; i++)
            {
                combinations[index] = names[i];
                GetCombinations(result, combinations, names, index + 1, i + 1);
            }
        }
    }
}