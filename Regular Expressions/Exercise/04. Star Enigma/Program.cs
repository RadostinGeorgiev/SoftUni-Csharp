using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string lettersPattern = @"[STAR]";
            string messagePattern = @"^[^@!:>\-]*@(?<name>[A-Za-z]+)[^@!:>\-]*:(\d+)[^@!:>\-]*!(?<attack>[AD])![^@!:>\-]*\->(\d+)[^@!:>\-]*$";
            int numberMessages = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 1; i <= numberMessages; i++)
            {
                string input = Console.ReadLine();
                int countLetters = Regex.Matches(input, lettersPattern, RegexOptions.IgnoreCase).Count;
                for (var c = 0; c < input.Length; c++)
                {
                    sb.Append((char)(input[c] - countLetters));
                }

                string decryptedMessage = sb.ToString();
                sb.Clear();

                if (Regex.IsMatch(decryptedMessage, messagePattern))
                {
                    string planet = Regex.Match(decryptedMessage, messagePattern).Groups["name"].Value;
                    string attack = Regex.Match(decryptedMessage, messagePattern).Groups["attack"].Value;
                    if (attack == "A")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var attackedPlanet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {attackedPlanet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var destroyedPlanet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {destroyedPlanet}");
            }
        }
    }
}
