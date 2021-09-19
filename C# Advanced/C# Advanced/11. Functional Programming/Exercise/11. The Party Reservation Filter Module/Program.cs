using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            List<(string, string)> filters = new List<(string, string)>();
            string filterType = string.Empty;
            string filterParams = string.Empty;

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] commandParams = input.Split(';');
                string command = commandParams[0];
                filterType = commandParams[1];
                filterParams = commandParams[2];

                switch (command)
                {
                    case "Add filter":
                        if (!filters.Contains((filterType, filterParams)))
                        {
                            filters.Add((filterType, filterParams));
                        }
                        break;
                    case "Remove filter":
                        if (filters.Contains((filterType, filterParams)))
                        {
                            filters.Remove((filterType, filterParams));
                        }
                        break;
                }
            }

            foreach (var valueTuple in filters)
            {
                var predicate = GetPredicate(valueTuple.Item1, valueTuple.Item2);

                guests = guests.Where(x =>!predicate(x)).ToList();
            }

            Console.WriteLine(string.Join(' ', guests));
        }

        static Func<string, bool> GetPredicate(string filterType, string filterParams)
        {
            switch (filterType)
            {
                case "Starts with": return s => s.StartsWith(filterParams);
                case "Ends with": return s => s.StartsWith(filterParams);
                case "Length": return s => (s.Length == int.Parse(filterParams));
                case "Contains": return s => s.Contains(filterParams);
                default: return null;
            }
        }
    }
}
