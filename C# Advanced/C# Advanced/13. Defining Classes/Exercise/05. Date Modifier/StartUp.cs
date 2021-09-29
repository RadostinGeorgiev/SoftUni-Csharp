using System;
using System.Globalization;

namespace _05._Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);

            Console.WriteLine(DateModifier.DaysDifference(firstDate, secondDate));
        }
    }
}