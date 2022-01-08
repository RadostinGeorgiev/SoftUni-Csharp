namespace _08._Tennis_Ranklist
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());
            int wonTournaments = 0;
            int points = 0;

            for (int i = 0; i < tournaments; i++)
            {
                string state = Console.ReadLine();

                switch (state)
                {
                    case "W":
                        points += 2000;
                        wonTournaments++;
                        break;
                    case "F":
                        points += 1200;
                        break;
                    case "SF":
                        points += 720;
                        break;
                }
            }

            Console.WriteLine($"Final points: {initialPoints + points}");
            Console.WriteLine($"Average points: {(int)Math.Floor((double)points / tournaments)}");
            Console.WriteLine($"{(double)wonTournaments / tournaments * 100:F2}%");
        }
    }
}