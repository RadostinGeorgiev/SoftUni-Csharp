using System;

namespace _08._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minutesOfArrival = int.Parse(Console.ReadLine());

            int difference = hourOfExam * 60 + minutesOfExam - (hourOfArrival * 60 + minutesOfArrival);
            string isOnTime;
            string beforeOrAfter;

            if (difference < 0)
            {
                isOnTime = "Late";
                beforeOrAfter = "after";
            }
            else if (difference > 30)
            {
                isOnTime = "Early";
                beforeOrAfter = "before";
            }
            else
            {
                isOnTime = "On time";
                beforeOrAfter = "before";
            }

            Console.WriteLine($"{isOnTime}");

            if (difference == 0) return;
            Console.WriteLine(Math.Abs(difference) < 60
                ? $"{Math.Abs(difference)} minutes {beforeOrAfter} the start"
                : $"{Math.Abs(difference) / 60}:{Math.Abs(difference) % 60:D2} hours {beforeOrAfter} the start");
        }
    }
}
