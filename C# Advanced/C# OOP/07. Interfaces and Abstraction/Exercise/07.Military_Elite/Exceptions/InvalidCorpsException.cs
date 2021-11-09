using System;

namespace MilitaryElite.Exeptions
{
    public class InvalidCorpsException : Exception
    {
        private const string InvalidCorpsMessage = "Invalid corps!";

        public InvalidCorpsException()
         : base(InvalidCorpsMessage)
        {
        }

        public InvalidCorpsException(string? message) 
            : base(message)
        {
        }
    }
}