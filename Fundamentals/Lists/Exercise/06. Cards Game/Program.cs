using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int winnerCard = 0;
            int losingCard = 0;

            while (firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0)
            {
                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    winnerCard = firstPlayerCards[0];
                    losingCard = secondPlayerCards[0];
                    firstPlayerCards.Add(winnerCard);
                    firstPlayerCards.Add(losingCard);
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);

                }
                else if (firstPlayerCards[0] < secondPlayerCards[0])
                {
                    winnerCard = secondPlayerCards[0];
                    losingCard = firstPlayerCards[0];
                    secondPlayerCards.Add(winnerCard);
                    secondPlayerCards.Add(losingCard);
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);

                }
                else
                {
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
            }

            int sum = 0;
            if (firstPlayerCards.Count != 0)
            {
                foreach (var item in firstPlayerCards)
                {
                    sum += item;
                }

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                foreach (var item in secondPlayerCards)
                {
                    sum += item;
                }

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
