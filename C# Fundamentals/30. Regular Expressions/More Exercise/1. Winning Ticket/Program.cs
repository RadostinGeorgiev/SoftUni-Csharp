using System;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"^.*?(?<win>[@#$^]{6,10}).*?(?<=.{10})(\k<win>).*$";

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    if (Regex.IsMatch(ticket, pattern))
                    {
                        string winning = Regex.Match(ticket, pattern).Groups["win"].Value;
                        if ((winning.Length >= 6) && (winning.Length <= 9))
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {winning.Length}{winning[0]}");
                        }
                        else if (winning.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {winning.Length}{winning[0]} Jackpot!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}
