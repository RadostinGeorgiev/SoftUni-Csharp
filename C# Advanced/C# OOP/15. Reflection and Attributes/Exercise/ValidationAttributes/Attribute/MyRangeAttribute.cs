using System;

namespace ValidationAttributes.Attribute
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue, maxValue);

            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            var value = (int)obj;
            return value >= minValue && value <= maxValue;
        }

        public void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}