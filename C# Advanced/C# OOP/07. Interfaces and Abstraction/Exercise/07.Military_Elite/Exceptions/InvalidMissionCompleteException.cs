using System;

namespace MilitaryElite.Exeptions
{
    class InvalidMissionCompleteException : Exception
    {
        private const string InvalidCompleteMissionMessage = "Mission already completed!";

        public InvalidMissionCompleteException()
        : base(InvalidCompleteMissionMessage)
        {
        }

        public InvalidMissionCompleteException(string? message) 
            : base(message)
        {
        }
    }
}