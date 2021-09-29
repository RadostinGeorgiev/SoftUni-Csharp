using System;

namespace _05._Date_Modifier
{
    public class DateModifier
    {
        public static int DaysDifference(DateTime firstDate, DateTime secondDate)
        {
            return (int)Math.Abs((firstDate - secondDate).TotalDays);
        }
    }
}