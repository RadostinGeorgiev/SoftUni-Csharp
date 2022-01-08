namespace LunchBreak
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int restDuration = int.Parse(Console.ReadLine());

            double lunchTime = (double)restDuration / 8;
            double restTime = (double)restDuration / 4;

            double timeForMovie = restDuration - lunchTime - restTime;

            Console.WriteLine(timeForMovie >= episodeDuration
                ? $"You have enough time to watch {movieName} and left with {Math.Ceiling(timeForMovie - episodeDuration)} minutes free time."
                : $"You don't have enough time to watch {movieName}, you need {Math.Ceiling(episodeDuration - timeForMovie)} more minutes.");
        }
    }
}