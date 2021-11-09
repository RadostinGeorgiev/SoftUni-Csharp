using System;

namespace MilitaryElite.Exeptions
{
    public class InvalidStateException : Exception
    {
        private const string InvalidStateMessage = "Invalid mission state!";

        public InvalidStateException()
        : base(InvalidStateMessage)
        {
        }

        public InvalidStateException(string? message) 
            : base(message)
        {
        }
    }
}