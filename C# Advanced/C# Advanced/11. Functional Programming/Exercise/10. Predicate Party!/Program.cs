using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {

                string[] commands = input.Split();
                string command = commands[0];
                string criteria = commands[1];
                string condition = commands[2];
                Predicate<string> predicate = GetPredicate(criteria, condition);

                switch (command)
                {
                    case "Remove":
                        guests.RemoveAll(predicate);
                        break;

                    case "Double":
                        for (var i = 0; i < guests.Count; i++)
                        {
                            string guest = guests[i];
                            if (predicate(guest))
                            {
                                guests.Insert(i + 1, guest);
                                i++;
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(guests.Count > 0
                ? $"{string.Join(", ", guests)} are going to the party!"
                : "Nobody is going to the party!");
        }

        private static Predicate<string> GetPredicate(string criteria, string condition)
        {
            switch (criteria)
            {
                case "StartsWith": return s => s.StartsWith(condition);
                case "EndsWith": return s => s.EndsWith(condition);
                case "Length": return s => s.Length == int.Parse(condition);
                default: return null;
            }
        }
    }
}