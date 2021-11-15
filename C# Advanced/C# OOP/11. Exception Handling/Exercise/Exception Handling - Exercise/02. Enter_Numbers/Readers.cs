using System;

namespace _02._Enter_Numbers
{
    class Readers
    {
        public static int ReadNumber(int start, int end)
        {
            string number = Console.ReadLine();

            if (!int.TryParse(number, out var result))
            {
                throw new ArgumentException("Please insert a number");
            }

            if (result < start || result > end)
            {
                throw new ArgumentException($"The number not in the range [{start}, {end}]");
            }

            return result;
        }
    }
}