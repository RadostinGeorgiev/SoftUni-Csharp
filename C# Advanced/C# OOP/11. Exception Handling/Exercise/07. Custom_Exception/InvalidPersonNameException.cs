using System;

namespace _07._Custom_Exception
{
    public class InvalidPersonNameException : Exception
    {
        private const string InvalidNameMessage = "The name can't contains any special characters or numeric values.";

        public InvalidPersonNameException() 
            : base(InvalidNameMessage)
        {
        }

        public InvalidPersonNameException(string? message)
             : base(message)
        {
        }
    }
}