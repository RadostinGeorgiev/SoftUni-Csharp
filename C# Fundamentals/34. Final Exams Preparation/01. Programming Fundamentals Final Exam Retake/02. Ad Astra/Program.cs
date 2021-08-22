using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {

        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern =
                @"([#|])(?<item>[A-Za-z\s]+)\1(?<expirationDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]{1,5})\1";

            var matches = Regex.Matches(text, pattern);

            int totalCalories = 0;
            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine(
                    $"Item: {match.Groups["item"].Value}, Best before: {match.Groups["expirationDate"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }

    }
}
