using System;

namespace SquareRoot
{
    public class SquareRootCalculator
    {
        public static double SquareRootCalc(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number");
            }

            return Math.Sqrt(number);
        }
    }
}