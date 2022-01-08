namespace _06._Oscars
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            const double nominationPoints = 1250.5;

            string actor = Console.ReadLine();
            double initialPoints = double.Parse(Console.ReadLine());
            int jury = int.Parse(Console.ReadLine());

            double totalPoints = initialPoints;

            for (int i = 0; i < jury; i++)
            {
                string name = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());

                totalPoints += name.Length * points / 2;

                if (totalPoints >= nominationPoints)
                {
                    break;
                }
            }

            Console.WriteLine(totalPoints >= nominationPoints
                ? $"Congratulations, {actor} got a nominee for leading role with {totalPoints:F1}!"
                : $"Sorry, {actor} you need {nominationPoints - totalPoints:F1} more!");
        }
    }
}